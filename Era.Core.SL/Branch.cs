using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    public class Branch : ValuedElement {
        public Branch(emBranch Element) {
            this.Element = Element;
        }
        public Branch(char Value) {
            this.Element = EnvironmentHelper.GetEmBranch(Value);
        }
        public Branch(int Value) {
            this.Element = (emBranch)Value;
        }
        public emBranch Element;
        public List<Stems> HideStems {
            get {
                if (_HideStems == null) {
                    _HideStems = new List<Stems>();
                    //查询系统的藏干力量分配
                    emStems[] emStemses = EnvironmentHelper.GetHideStemsbyBranch(Element);
                    foreach (emStems stem in emStemses) {
                        _HideStems.Add(new Stems(stem));
                    }
                }
                return _HideStems;
            }
        }

        private List<Stems> _HideStems = null;

        public override string ToString() {
            return EnvironmentHelper.GetChar(Element).ToString();
        }
    }
}
