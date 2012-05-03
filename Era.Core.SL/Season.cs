using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    //时辰
    public class Season {
        public Pillar Year;
        public Pillar Month;
        public Pillar Day;
        public Pillar Hour;
        public Destiny CreateDestiny() {
            return new Destiny(this);

        }
        public DateTime Datetime;
        public override string ToString() {
            return Year.ToString() + '|' + Month.ToString() + '|' + Day.ToString() + '|' + Hour.ToString();
        }
    }
}
