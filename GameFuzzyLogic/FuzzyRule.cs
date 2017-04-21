using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi
{
    public class FuzzyRule
    {
        private FuzzyTerm Antecedent;

        private FuzzyTerm Consequence;

        //
        //

        public FuzzyRule(FuzzyTerm ant,
            FuzzyTerm con)
        {
            Antecedent = ant.Clone();
            Consequence = con.Clone();
        }

        ~FuzzyRule()
        {
            Antecedent = null;
            Consequence = null;
        }

        public void SetConfidenceOfConsequentToZero()
        {
            Consequence.ClearDOM();
        }

        public void Calculate()
        {
            Consequence.ORwithDOM(Antecedent.GetDOM());
        }
    }
}
