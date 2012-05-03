using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    /// <summary>
    /// 命运
    /// </summary>
    public class Destiny : Season {
        public Destiny() { }
        public Destiny(Season env) {
            this.Year = env.Year;
            this.Month = env.Month;
            this.Day = env.Day;
            this.Hour = env.Hour;
        }
        public Destiny(Season env, bool Gender) {
            this.Year = env.Year;
            this.Month = env.Month;
            this.Day = env.Day;
            this.Hour = env.Hour;
            this.Gender = Gender;
        }
        public List<Pillar> Fortunes = new List<Pillar>();
        public Pillar currFortune;
        public bool Gender = true;//true男 false女

    }
}
