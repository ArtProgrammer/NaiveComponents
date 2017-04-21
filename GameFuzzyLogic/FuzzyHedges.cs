using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FzVery : FuzzyTerm
    {
        private FuzzySet FSet;

        private FzVery(FzVery fv)
        {
            FSet = fv.FSet;
        }

        public FzVery(FzSet ft)
        {
            FSet = ft.FSet;
        }

        public override double GetDOM()
        {
            return FSet.GetDOM() * FSet.GetDOM();
        }

        public override FuzzyTerm Clone()
        {
            return new FzVery(this);
        }

        public override void ClearDOM()
        {
            FSet.ClearDOM();
        }

        public override void ORwithDOM(double val)
        {
            FSet.ORwithDOM(val * val);
        }
    }

    public class FzFairly : FuzzyTerm
    {
        private FuzzySet FSet;

        private FzFairly(FzFairly fv)
        {
            FSet = fv.FSet;
        }

        public FzFairly(FzSet ft)
        {
            FSet = ft.FSet;
        }

        public override double GetDOM()
        {
            return Math.Sqrt(FSet.GetDOM());
        }

        public override FuzzyTerm Clone()
        {
            return new FzFairly(this);
        }

        public override void ClearDOM()
        {
            FSet.ClearDOM();
        }

        public override void ORwithDOM(double val)
        {
            FSet.ORwithDOM(Math.Sqrt(val));
        }
    }
}
