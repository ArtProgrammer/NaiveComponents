using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzySet_RightShoulder : FuzzySet
    {
        private double PeakPoint;
        private double RightOffset;
        private double LeftOffset;

        public FuzzySet_RightShoulder(double peak,
            double lftoffset,
            double rftoffet) : base((rftoffet + peak + peak) / 2)
        {
            PeakPoint = peak;
            RightOffset = rftoffet;
            LeftOffset = lftoffset;
        }

        public override double CalculateDOM(double val)
        {
            if ((Double.Equals(RightOffset, 0.0) && Double.Equals(PeakPoint, val)) ||
                (Double.Equals(LeftOffset, 0.0) && Double.Equals(PeakPoint, val)))
            {
                return 1.0;
            }
            else if ((val <= PeakPoint) &&
                (val > PeakPoint - LeftOffset))
            {
                double grad = 1.0 / LeftOffset;
                return grad * (val - (PeakPoint - LeftOffset));
            }
            else if ((val > PeakPoint) &&
                (val <= PeakPoint + RightOffset))
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
