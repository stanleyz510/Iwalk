using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    
    public static class CalcAmountHelper {

//子：癸          丑：己、癸、辛       寅：甲、丙、戊
//卯：乙          辰：戊、乙、癸       巳：丙、戊、庚
//午：丁、己      未：己、丁、乙       申：庚、壬、戊
//酉：辛          戌：戊、辛、丁       亥：壬、甲
        static Dictionary<emBranch, emStems[]> dicCangGan
            = new Dictionary<emBranch, emStems[]>();
         static CalcAmountHelper()
        {
            dicCangGan.Add(emBranch.子, new emStems[] { emStems.癸 });
            dicCangGan.Add(emBranch.丑, new emStems[] { emStems.己,emStems.癸,emStems.辛 });
            dicCangGan.Add(emBranch.寅, new emStems[] { emStems.甲,emStems.丙,emStems.戊 });
            dicCangGan.Add(emBranch.卯, new emStems[] { emStems.乙 });
            dicCangGan.Add(emBranch.辰, new emStems[] { emStems.戊,emStems.乙,emStems.癸 });
            dicCangGan.Add(emBranch.巳, new emStems[] { emStems.丙,emStems.戊,emStems.庚 });
            dicCangGan.Add(emBranch.午, new emStems[] { emStems.丁,emStems.己 });
            dicCangGan.Add(emBranch.未, new emStems[] { emStems.己,emStems.丁,emStems.乙 });
            dicCangGan.Add(emBranch.申, new emStems[] { emStems.庚,emStems.壬,emStems.戊 });
            dicCangGan.Add(emBranch.酉, new emStems[] { emStems.辛 });
            dicCangGan.Add(emBranch.戌, new emStems[] { emStems.戊,emStems.辛,emStems.丁 });
            dicCangGan.Add(emBranch.亥, new emStems[] { emStems.壬,emStems.甲 });
        }
        public static void FillStemsAmount(Destiny destiny)
        {
             destiny.Year.Stems.Value=10;
            destiny.Month.Stems.Value = 10;
            destiny.Day.Stems.Value = 10;
            destiny.Hour.Stems.Value = 10;
            FillStemsAmount(destiny.Year.Branch.HideStems);
            FillStemsAmount(destiny.Month.Branch.HideStems);
            FillStemsAmount(destiny.Day.Branch.HideStems);
            FillStemsAmount(destiny.Hour.Branch.HideStems);
        }

        private static void FillStemsAmount(List<Stems> list)
        {
            switch (list.Count)
            {
                case 1:
                    list[0].Value=10;
                    break;
                case 2:
                    list[0].Value = 6;
                    list[1].Value = 4;
                   
                    break;
                case 3:
                    list[0].Value = 6;
                    list[1].Value = 2.5f;
                    list[2].Value = 1.5f;
                    break;
            }
        }

        public static string GetWuxingAmount(Season environment)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<int,float> dictionary = new Dictionary<int, float>();
            dictionary.Add(0,0);
            dictionary.Add(1,0);
            dictionary.Add(2,0);
            dictionary.Add(3,0);
            dictionary.Add(4,0);
            float[] floats  = new float[5];
            string temp = "木火土金水";
            Amount amount = GetAmount(environment.Year.Stems.Element);
            dictionary[amount.Type]+=amount.Value;
            amount = GetAmount(environment.Month.Stems.Element);
            dictionary[amount.Type]+=amount.Value;
            amount = GetAmount(environment.Day.Stems.Element);
            dictionary[amount.Type]+=amount.Value;
            amount = GetAmount(environment.Hour.Stems.Element);
            dictionary[amount.Type]+=amount.Value;

            foreach (Amount amount1 in GetAmount(environment.Year.Branch.Element))
            {
                dictionary[amount1.Type]+=amount1.Value;
            }
            foreach (Amount amount1 in GetAmount(environment.Month.Branch.Element)) {
                dictionary[amount1.Type] += amount1.Value;
            }
            foreach (Amount amount1 in GetAmount(environment.Day.Branch.Element)) {
                dictionary[amount1.Type] += amount1.Value;
            }
            foreach (Amount amount1 in GetAmount(environment.Hour.Branch.Element)) {
                dictionary[amount1.Type] += amount1.Value;
            }

            foreach (KeyValuePair<int, float> keyValuePair in dictionary)
            {
                sb.Append(temp[keyValuePair.Key]);
                sb.Append(" ");
                sb.Append(keyValuePair.Value);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        static Amount GetAmount(emStems stems)
        {
            int type = (int) stems/2;
            float fvalue = 10;
            return new Amount(type, fvalue);
        }
        static Amount[] GetAmount(emBranch emBranch)
        {
            emStems[] stemses = dicCangGan[emBranch];
            Amount[] amounts = new Amount[stemses.Length];
            switch(stemses.Length)
            {
                case 1:
                    amounts[0] = GetAmount(stemses[0]);
                    break;
                case 2:
                     amounts[0] = GetAmount(stemses[0]);
                     amounts[0].Value*=0.6f;
                     amounts[1] = GetAmount(stemses[1]);
                     amounts[1].Value*=0.4f;
                    break;
                case 3:
                     amounts[0] = GetAmount(stemses[0]);
                     amounts[0].Value*=0.6f;
                     amounts[1] = GetAmount(stemses[1]);
                     amounts[1].Value*=0.25f;
                    amounts[2] = GetAmount(stemses[2]);
                     amounts[2].Value*=0.15f;
                    break;
            }
            //Amount[] amounts =Array.ConvertAll(stemses, e=>GetAmount(e));
            //Amount[] amounts = Array.ConvertAll(stemses, delegate(emStems e)
            //                                                 { return GetAmount(e); });
            return amounts;
        }
        struct Amount
        {
            public int Type;
            public float Value;
            public Amount(int type,float fvalue)
            {
                this.Type = type;
                this.Value = fvalue;
            }
        }

        public static string GetEraAmountReport(Destiny destiny) {
            float [] score = new float[5];
            List<Stems> allstems = new List<Stems>();
            allstems.Add(destiny.Year.Stems);
            allstems.Add(destiny.Month.Stems);
            allstems.Add(destiny.Day.Stems);
            allstems.Add(destiny.Hour.Stems);
            allstems.AddRange(destiny.Year.Branch.HideStems);
            allstems.AddRange(destiny.Month.Branch.HideStems);
            allstems.AddRange(destiny.Day.Branch.HideStems);
            allstems.AddRange(destiny.Hour.Branch.HideStems);
            //allstems.ForEach(ste=>score[(int)ste.EraType]+=ste.Value);
            foreach (Stems item in allstems)
            {
                score[(int) item.EraType] += item.Value;
            }
            StringBuilder sb = new StringBuilder();
            string[] names = Enum.GetNames(typeof (emEra));
            for (int i = 0; i < score.Length; i++)
            {
                sb.Append(names[i]).Append(":").Append(score[i]);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string GetStemsAmountReport(Destiny destiny) {
            float[] score = new float[10];
            List<Stems> allstems = new List<Stems>();
            allstems.Add(destiny.Year.Stems);
            allstems.Add(destiny.Month.Stems);
            allstems.Add(destiny.Day.Stems);
            allstems.Add(destiny.Hour.Stems);
            allstems.AddRange(destiny.Year.Branch.HideStems);
            allstems.AddRange(destiny.Month.Branch.HideStems);
            allstems.AddRange(destiny.Day.Branch.HideStems);
            allstems.AddRange(destiny.Hour.Branch.HideStems);
            //allstems.ForEach(ste=>score[(int)ste.EraType]+=ste.Value);
            foreach (Stems item in allstems) {
                score[(int)item.Element] += item.Value;
            }
            StringBuilder sb = new StringBuilder();
            string[] names = Enum.GetNames(typeof(emStems));
            for (int i = 0; i < score.Length; i++) {
                sb.Append(names[i]).Append(":").Append(score[i]);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
