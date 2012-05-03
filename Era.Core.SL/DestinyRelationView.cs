using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    //实现布局算法
    public class DestinyRelationView : Destiny
    {
        public DestinyRelationView(Destiny destiny)
        {
            base.Year = destiny.Year;
            Month = destiny.Month;
            Day = destiny.Day;
            Hour = destiny.Hour;
            Init();
        }

        public EraRelation YearStems;
        public List<EraRelation> YearBranchs;
        public EraRelation MouthStems;
        public List<EraRelation> MouthBranchs;
        public EraRelation DayStems;
        public List<EraRelation> DayBranchs;
        public EraRelation HourStems;
        public List<EraRelation> HourBranchs;

        //旬空
        public List<Branch> EmptyBranch;

        public List<string> WeakStrong;//衰旺
        public List<string> Nayin;//纳音

        public void Init()
        {
            YearStems = Year.Stems - Day.Stems;
            DayStems = new EraRelation(Day.Stems, Day.Stems, emEraRelation.日元);
            MouthStems = Month.Stems - Day.Stems;
            HourStems = Hour.Stems - Day.Stems;

            YearBranchs = ConvertAll(Year.Branch.HideStems, Day.Stems);
            MouthBranchs = ConvertAll(Month.Branch.HideStems, Day.Stems);// Month.Branch.HideStems.ConvertAll(e => e - Day.Stems);
            DayBranchs = ConvertAll(Day.Branch.HideStems, Day.Stems); //Day.Branch.HideStems.ConvertAll(e => e - Day.Stems);
            HourBranchs = ConvertAll(Hour.Branch.HideStems, Day.Stems); //Hour.Branch.HideStems.ConvertAll(e => e - Day.Stems);
            //旬空
            EmptyBranch = new List<Branch>();
            int first= (Day.Index/10+1)*10 %12;
            EmptyBranch = new List<Branch>();
            EmptyBranch.Add(new Branch(first));
            EmptyBranch.Add(new Branch(first+1));
            //衰旺
            WeakStrong = new List<string>();
            WeakStrong.Add(EnvironmentHelper.QueryWeakStrong(Day.Stems, Year.Branch));
            WeakStrong.Add(EnvironmentHelper.QueryWeakStrong(Day.Stems, Month.Branch));
            WeakStrong.Add(EnvironmentHelper.QueryWeakStrong(Day.Stems, Day.Branch));
            WeakStrong.Add(EnvironmentHelper.QueryWeakStrong(Day.Stems, Hour.Branch));

            Nayin = new List<string>();
            Nayin.Add(EnvironmentHelper.QueryNayin(Year));
            Nayin.Add(EnvironmentHelper.QueryNayin(Month));
            Nayin.Add(EnvironmentHelper.QueryNayin(Day));
            Nayin.Add(EnvironmentHelper.QueryNayin(Hour));
        }
        public List<EraRelation> ConvertAll(List<Stems> stemses, Stems baseStem)
        {
            List<EraRelation> eraRelations = new List<EraRelation>();
            foreach (Stems stems in stemses)
            {
                eraRelations.Add(stems - baseStem);
            }
            return eraRelations;
        }

    }
   
    public class EraRelation {
        public EraRelation(Stems Foreign, Stems Primary, emEraRelation Value) {
            this.Foreign = Foreign;
            this.Primary = Primary;
            this.Value = Value;
        }
        public EraRelation(Stems Foreign, Stems Primary, string Value) {
            this.Foreign = Foreign;
            this.Primary = Primary;
            this.Value = (emEraRelation)Enum.Parse(typeof(emEraRelation), Value,true);
        }
        public EraRelation(Stems Foreign, Stems Primary, int Value) {
            this.Foreign = Foreign;
            this.Primary = Primary;
            this.Value = (emEraRelation)Value;
        }
        public emEraRelation Value;
        public override string ToString() {
            return Enum.GetName(typeof(emEraRelation), Value);
        }

        public Stems Foreign { get; private set; }
        public Stems Primary { get; private set; }
    }
}
