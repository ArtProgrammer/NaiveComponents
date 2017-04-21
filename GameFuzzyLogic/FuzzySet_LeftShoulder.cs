using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzySet_LeftShoulder : FuzzySet
    {
        private double PeakPoint;
        private double RightOffset;
        private double LeftOffset;

        public FuzzySet_LeftShoulder(double peak,
            double lftoffset,
            double rftoffset) : base(((peak - lftoffset) + peak) / 2)
        {
            PeakPoint = peak;
            RightOffset = rftoffset;
            LeftOffset = lftoffset;
        }

        public override double CalculateDOM(double val)
        {
            if ((Double.Equals(RightOffset, 0.0) && Double.Equals(PeakPoint, val)) ||
                (Double.Equals(LeftOffset, 0.0) && Double.Equals(PeakPoint, val)))
            {
                return 1.0;
            }
            else if ((val >= PeakPoint) && 
                (val < (PeakPoint + RightOffset)))
            {
                double grad = 1.0 / -RightOffset;
                return grad * (val - PeakPoint) + 1.0;
            }
            else if ((val < PeakPoint) &&
                (val >= PeakPoint - LeftOffset))
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
