using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class GetGirls_Evaluator : Goal_Evaluator
    {
        public GetGirls_Evaluator(double bias) : base(bias)
        {
            
        }

        public override double CalculateDesirability(Agent ag)
        {
            double desirability = Agent_Feature.WillingToGirls(ag);
            desirability *= CharacterBias;

            return desirability;
        }

        public override void SetGoal(Agent ag)
        {
            ag.Brain.AddGoal_PlayWithGirls();
        }
    }
}
