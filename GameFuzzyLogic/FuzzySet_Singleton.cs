using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzySet_Singleton : FuzzySet
    {
        private double MidPoint;
        private double RightOffset;
        private double LeftOffset;

        public FuzzySet_Singleton(double mid,
            double lftoffset,
            double rgtoffset) : base(mid)
        {
            MidPoint = mid;
            LeftOffset = lftoffset;
            RightOffset = rgtoffset;
        }

        public override double CalculateDOM(double val)
        {
            if ((val >= MidPoint - LeftOffset) &&
                (val <= MidPoint + RightOffset))
            {
                return 1.0;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
