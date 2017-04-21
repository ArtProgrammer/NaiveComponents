using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzyVariable
    {
        private FuzzyVariable(FuzzyVariable val)
        {
        }

        private Dictionary<string, FuzzySet> MemberSets =
            new Dictionary<string, FuzzySet>();

        private double MinRange;

        private double MaxRange;

        private void AdjustRangeToFit(double min, double max)
        {
            if (MinRange > min) MinRange = min;
            if (MaxRange < max) MaxRange = max;
        }

        ~FuzzyVariable()
        {
            MemberSets.Clear();
        }

        public FuzzyVariable()
        {
            MinRange = 0.0;
            MaxRange = 0.0;
        }

        public FzSet AddLeftShoulderSet(string name, double minBound, double peak, double maxBound)
        {
            MemberSets[name] = new FuzzySet_LeftShoulder(peak, peak - minBound, maxBound - peak);
            AdjustRangeToFit(minBound, maxBound);

            return new FzSet(MemberSets[name]);
        }

        public FzSet AddRightShoulderSet(string name, double minBound, double peak, double maxBound)
        {
            MemberSets[name] = new FuzzySet_RightShoulder(peak, peak - minBound, maxBound - peak);
            AdjustRangeToFit(minBound, maxBound);

            return new FzSet(MemberSets[name]);
        }

        public FzSet AddTrianglularSet(string name, double minBound, double peak, double maxBound)
        {
            MemberSets[name] = new FuzzySet_Triangle(peak, peak - minBound, maxBound - peak);
            AdjustRangeToFit(minBound, maxBound);

            return new FzSet(MemberSets[name]);
        }

        public FzSet AddSingletonSet(string name, double minBound, double peak, double maxBound)
        {
            MemberSets[name] = new FuzzySet_Singleton(peak, peak - minBound, maxBound - peak);
            AdjustRangeToFit(minBound, maxBound);

            return new FzSet(MemberSets[name]);
        }

        public void Fuzzify(double val)
        {
            if (val >= MinRange && val <= MaxRange)
            {
                foreach (var item in MemberSets)
                {
                    item.Value.SetDOM(item.Value.CalculateDOM(val));
                }
            }
        }

        public double DefuzzifyMaxAv()
        {
            double bottom = 0.0;
            double top = 0.0;

            foreach (var item in MemberSets)
            {
                bottom += item.Value.GetDOM();

                top += item.Value.GetRepresentativeVal() * item.Value.GetDOM();
            }

            if (Double.Equals(0.0, bottom)) return 0.0;

            return top / bottom;
        }

        public double DefuzzifyCentroid(int numSamples)
        {
            double stepSize = (MaxRange - MinRange) / (double)numSamples;

            double totalArea = 0.0;
            double sumOfMoments = 0.0;

            for (int samp = 1; samp <= numSamples; ++samp)
            {
                foreach(var item in MemberSets)
                {
                    double contribution = Math.Min(
                        item.Value.CalculateDOM(MinRange + samp * stepSize),
                        item.Value.GetDOM()
                        );

                    totalArea += contribution;
                    sumOfMoments += (MinRange + samp * stepSize) * contribution;
                }
            }

            if (Double.Equals(0.0, totalArea)) return 0;
            return sumOfMoments / totalArea;
        }
    }
}
