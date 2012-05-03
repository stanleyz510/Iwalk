using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    /// <summary>
    /// 柱
    /// </summary>
    public class Pillar {
        public Pillar() {
        }
        public Pillar(int value)
            : this(value / 10, value % 12) { }
        public Pillar(string stemBranch) {
            if (stemBranch.Length != 2) return;
            this.Stems = new Stems(stemBranch[0]);
            this.Branch = new Branch(stemBranch[1]);
        }
        public Pillar(int stems, int branch) {
            this.Stems = new Stems(stems);
            this.Branch = new Branch(branch);
        }

        public Stems Stems;
        public Branch Branch;
        public int Index
        {
            get
            {
                if (Stems == null) return -1;
                if (Branch == null) return -1;
                return ((int) Stems.Element - (int) Branch.Element + 12)%12/2*10 + (int) Stems.Element;
            }
        }

        public override string ToString() {
            return Stems.ToString() + Branch.ToString();
        }
    }
}
