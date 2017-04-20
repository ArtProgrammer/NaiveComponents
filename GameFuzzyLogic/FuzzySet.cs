using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzySet
    {
        protected double DOM;

        protected double RepresentativeValue;

        public FuzzySet(double repval)
        {
            DOM = 0.0;
            RepresentativeValue = repval;
        }

        public virtual double CalculateDOM(double val) { return 0.0; }

        public void ORwithDOM(double val) { if (val > DOM) DOM = val; }

        public double GetRepresentativeVal() { return RepresentativeValue; }

        public void ClearDOM() { DOM = 0.0; }

        public double GetDOM() { return DOM; }

        public void SetDOM(double val)
        {
            if (val <= 1 && val >= 0)
            {
                DOM = val;
            }
        }
    }
}
