using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzyModule
    {
        public enum DefuzzifyMethod
        {
            max_av,
            centroid
        }

        public enum SamplesNums
        {
            low = 15
        }

        public int NumSamples = 15;

        private Dictionary<string, FuzzyVariable> Variables =
            new Dictionary<string, FuzzyVariable>();

        private List<FuzzyRule> Rules = new List<FuzzyRule>();

        private void SetConfidenceOfConsequentsToZero()
        {
            foreach (var item in Rules)
            {
                item.SetConfidenceOfConsequentToZero();
            }
        }

        ~FuzzyModule()
        {            
            Variables.Clear();

            Rules.Clear();
        }

        public FuzzyVariable CreateFLV(string varname)
        {
            Variables[varname] = new FuzzyVariable();
            return Variables[varname];
        }

        public void AddRule(FuzzyTerm antecedent, FuzzyTerm consequence)
        {
            Rules.Add(new FuzzyRule(antecedent, consequence));
        }

        public void Fuzzify(string nameofflv, double val)
        {
            if (Variables.ContainsKey(nameofflv))
            {
                Variables[nameofflv].Fuzzify(val);
            }
        }

        public double Defuzzify(string key, DefuzzifyMethod method = DefuzzifyMethod.max_av)
        {
            if (Variables.ContainsKey(key))
            {
                SetConfidenceOfConsequentsToZero();

                foreach (var item in Rules)
                {
                    item.Calculate();
                }

                switch(method)
                {
                    case DefuzzifyMethod.centroid:
                        {
                            return Variables[key].DefuzzifyCentroid(NumSamples);
                        }
                        break;
                    case DefuzzifyMethod.max_av:
                        {
                            return Variables[key].DefuzzifyMaxAv();
                        }
                        break;
                }
            }

            return 0;
        }
    }
}
