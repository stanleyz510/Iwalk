using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    /// <summary>
    /// 天干
    /// </summary>
    public class Stems : Era {
        public Stems(emStems Element) {
            this.Element = Element;
        }
        public Stems(char Value) {
            this.Element = EnvironmentHelper.GetEmStems(Value);
        }
        public Stems(int Value) {
            this.Element = (emStems)Value;
        }
        public emStems Element;
        public static EraRelation operator -(Stems Other, Stems self) {
            int type = (5 + (int)Other.Element / 2 - (int)self.Element / 2) % 5;
            type *= 2;
            type += ((Other.Element - self.Element) % 2 == 0) ? 0 : 1;
            return new EraRelation(Other, self, type);
        }
        public override string ToString() {
            return EnvironmentHelper.GetChar(Element).ToString();
        }
        public override emEra EraType {
            get {
                return (emEra)((int)this.Element / 2);
            }
            //set {
            //    base.EraType = value;
            //}
        }
    }
}
