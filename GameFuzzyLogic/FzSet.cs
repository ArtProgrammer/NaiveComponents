using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FzSet : FuzzyTerm
    {
        private FuzzySet FSet;

        public FzSet(FuzzySet fs) { FSet = fs; }

        public override FuzzyTerm Clone() { return new FzSet(this.FSet); }

        public override double GetDOM() { return FSet.GetDOM(); }

        public override void ClearDOM() { FSet.ClearDOM(); }

        public override void ORwithDOM(double val) { FSet.ORwithDOM(val); }
    }
}
