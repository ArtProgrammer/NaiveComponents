using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public abstract class FuzzyTerm
    {
        ~FuzzyTerm() { }

        public abstract FuzzyTerm Clone();

        public abstract double GetDOM();

        public abstract void ClearDOM();

        public abstract void ORwithDOM(double val);
    }
}
