﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzySet_Triangle : FuzzySet
    {
        private double PeakPoint;
        private double LeftOffset;
        private double RightOffset;

        public FuzzySet_Triangle(double mid, double lft, double rgt) : base(mid)
        {

            PeakPoint = mid;
            LeftOffset = lft;
            RightOffset = rgt;
        }

        public override double CalculateDOM(double val)
        {
            if ((Double.Equals(RightOffset, 0.0) && Double.Equals(PeakPoint, val)) ||
                (Double.Equals(LeftOffset, 0.0) && Double.Equals(PeakPoint, val)))
            {
                return 1.0;
            }

            if (val <= PeakPoint && val >= (PeakPoint - LeftOffset))
            {
                double grad = 1.0 / LeftOffset;

                return grad * (val - (PeakPoint - LeftOffset));
            }
            else if (val > PeakPoint && val < (PeakPoint + RightOffset))
            {
                double grad = 1.0 / -RightOffset;
                return grad * (val - PeakPoint) + 1.0;
            }
            else
            {
                return base.CalculateDOM(val);
            }
        }
    }
}
