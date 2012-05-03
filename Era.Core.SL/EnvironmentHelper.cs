using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    public static class EnvironmentHelper {

        public static Destiny Parser(string input) {
            try {
                string[] ss = input.Trim().Split('|');
                Season env = new Season();
                env.Year = new Pillar(ss[0]);
                env.Month = new Pillar(ss[1]);
                env.Day = new Pillar(ss[2]);
                env.Hour = new Pillar(ss[3]);

                //Destiny.)))
                return env.CreateDestiny();
            } catch (Exception ex) {
                throw;
            }
        }
        //public static Destiny Parser(DateTime time) {
        //    //Destiny.
        //    MultiStar.Common.ChinaCalendar cc = new ChinaCalendar(time);
        //    Destiny destiny = new Destiny();
        //    destiny.Year = new Pillar(cc.EraOfYear);
        //    destiny.Month = new Pillar(cc.EraOfMonth);
        //    destiny.Day = new Pillar(cc.EraOfDay);
        //    destiny.Hour = new Pillar(cc.EraOfHour);

        //    return new Destiny();
        //}
        //Pillar ParserPillar(string pillar)
        //{

        //}
        private static readonly char[] Tiangan = new char[] { '甲', '乙', '丙', '丁', '戊', '己', '庚', '辛', '壬', '癸' };
        private static readonly char[] Branchs = new char[] { '子', '丑', '寅', '卯', '辰', '巳', '午', '未', '申', '酉', '戌', '亥' };
        private static readonly string[] WeakStrongs = new string[]{"长生","沐浴","冠带","临官","帝旺","衰","病","死","墓","绝","胎","养"};

        private static readonly string Nayin =
            "海中金炉中火大林木路旁土剑锋金山头火漳下水城头土白腊金杨柳木泉中水屋上土霹雳火松柏木长流水砂石金山下火平地木壁上土金薄金覆灯火天河水大驿土钗环金桑柘木太溪水沙中土天上火石榴木大海水";
       

        public static Char GetChar(emStems emStems) {
            return Tiangan[(int)emStems];
        }
        public static Char GetChar(emBranch emBranch) {
            return Branchs[(int)emBranch];
        }
        private static readonly string[] MapHideStems
            = new string[]
                  {
                      //"癸", "己癸辛", "甲丙戊", "乙"
                      //, "戊乙癸", "丙戊庚", "丁己", "己丁乙"
                      //, "庚壬戊", "辛", "戊辛丁", "壬甲"
                       "癸", "己癸辛", "甲丙戊", "乙"
                      , "戊乙癸", "丙庚戊", "丁己", "己丁乙"
                      , "庚壬戊", "辛", "戊丁辛", "壬甲"
                  };

        public static emStems GetEmStems(char chr) {
            switch (chr) {
                case '甲': return emStems.甲;
                case '乙': return emStems.乙;
                case '丙': return emStems.丙;
                case '丁': return emStems.丁;
                case '戊': return emStems.戊;
                case '己': return emStems.己;
                case '庚': return emStems.庚;
                case '辛': return emStems.辛;
                case '壬': return emStems.壬;
                case '癸': return emStems.癸;
                default:
                    throw new ArgumentException("No found");
            }
        }
        public static emBranch GetEmBranch(char chr) {
            switch (chr) {
                case '子': return emBranch.子;
                case '丑': return emBranch.丑;
                case '寅': return emBranch.寅;
                case '卯': return emBranch.卯;
                case '辰': return emBranch.辰;
                case '巳': return emBranch.巳;
                case '午': return emBranch.午;
                case '未': return emBranch.未;
                case '申': return emBranch.申;
                case '酉': return emBranch.酉;
                case '戌': return emBranch.戌;
                case '亥': return emBranch.亥;
                default:
                    throw new ArgumentException("No found");
            }
        }
        public static emStems[] GetHideStemsbyBranch(emBranch branch)
        {
            string hidStem = MapHideStems[(int) branch];
            emStems[] emStemss =new emStems[hidStem.Length];
            for(int i=0;i<hidStem.Length;i++)
                emStemss[i] = GetEmStems(hidStem[i]);
            //return Array.ConvertAll(MapHideStems[(int)branch].ToCharArray()
            //                 , delegate(char c) {
            //    return GetEmStems(c);
            //});
            return emStemss;
        }
        public static string QueryWeakStrong(Stems emStems,Branch emBranch)
        {
            int[] startIndex = new int[]{11,4,2,9,2,9,5,0,8,3};
            int start = startIndex[(int) emStems.Element];

            //Math.Sign((int) emStems%2 - 0.5)*(-1) + 
            int index = ((-Math.Sign(((int)emStems.Element) % 2 - 0.5))*
                ((int)emBranch.Element - start) + 12) % 12;
            //return WeakStrongs[(int)emStems +]
            return WeakStrongs[index];
        }
        public static string QueryNayin(Pillar pillar)
        {
            return Nayin.Substring(pillar.Index/2*3, 3);
        }
    }
}
