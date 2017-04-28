using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Study_Evaluator : Goal_Evaluator
    {
        public Study_Evaluator(double bias) : base(bias)
        {

        }

        public override double CalculateDesirability(Agent ag)
        {
            double desirability = Agent_Feature.WillingToStudy(ag);
            desirability *= CharacterBias;

            return desirability;
        }

        public override void SetGoal(Agent ag)
        {
            ag.Brain.AddGoal_Study();
        }
    }
}
