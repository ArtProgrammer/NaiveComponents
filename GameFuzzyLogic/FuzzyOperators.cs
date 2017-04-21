using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    // 
    public class FzAND : FuzzyTerm
    {
        private List<FuzzyTerm> Terms = new List<FuzzyTerm>();

        public FzAND(FzAND fa)
        {
            foreach (var item in fa.Terms)
            {
                Terms.Add(item.Clone());
            }
        }

        public FzAND(FuzzyTerm op1, FuzzyTerm op2)
        {
            Terms.Add(op1.Clone());
            Terms.Add(op2.Clone());
        }

        public FzAND(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3)
        {
            Terms.Add(op1.Clone());
            Terms.Add(op2.Clone());
            Terms.Add(op3.Clone());
        }

        public FzAND(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3, FuzzyTerm op4)
        {
            Terms.Add(op1.Clone());
            Terms.Add(op2.Clone());
            Terms.Add(op3.Clone());
            Terms.Add(op4.Clone());
        }

        ~FzAND()
        {
            Terms.Clear();
        }

        public override FuzzyTerm Clone()
        {
            return new FzAND(this);
        }

        public override double GetDOM()
        {
            double samllest = Double.MaxValue;

            foreach (var item in Terms)
            {
                if (item.GetDOM() < samllest)
                {
                    samllest = item.GetDOM();
                }
            }

            return samllest;
        }

        public override void ClearDOM()
        {
            foreach (var item in Terms)
            {
                item.ClearDOM();
            }
        }

        public override void ORwithDOM(double val)
        {
            foreach (var item in Terms)
            {
                item.ORwithDOM(val);
            }
        }
    }

    // 
    public class FzOR : FuzzyTerm
    {
        private List<FuzzyTerm> Terms = new List<FuzzyTerm>();

        public FzOR(FzOR fa)
        {
            foreach (var item in fa.Terms)
            {
                Terms.Add(item.Clone());
            }
        }

        public FzOR(FuzzyTerm op1, FuzzyTerm op2)
        {
            Terms.Add(op1.Clone());
            Terms.Add(op2.Clone());
        }

        public FzOR(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3)
        {
            Terms.Add(op1.Clone());
            Terms.Add(op2.Clone());
            Terms.Add(op3.Clone());
        }

        public FzOR(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3, FuzzyTerm op4)
        {
            Terms.Add(op1.Clone());
            Terms.Add(op2.Clone());
            Terms.Add(op3.Clone());
            Terms.Add(op4.Clone());
        }

        ~FzOR()
        {
            Terms.Clear();
        }

        public override FuzzyTerm Clone()
        {
            return new FzOR(this);
        }

        public override double GetDOM()
        {
            double largest = Double.MinValue;

            foreach (var item in Terms)
            {
                if (item.GetDOM() > largest)
                {
                    largest = item.GetDOM();
                }
            }

            return largest;
        }

        public override void ClearDOM()
        {
            foreach (var item in Terms)
            {
                item.ClearDOM();
            }
        }

        public override void ORwithDOM(double val)
        {
            foreach (var item in Terms)
            {
                item.ORwithDOM(val);
            }
        }
    }
}
