using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    //五行--接口
    public abstract class Era : ValuedElement {
        public virtual emEra EraType { get; set; }
    }
}
