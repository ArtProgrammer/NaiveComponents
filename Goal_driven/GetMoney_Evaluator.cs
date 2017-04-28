using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class GetMoney_Evaluator : Goal_Evaluator
    {
        public GetMoney_Evaluator(double bias) : base(bias)
        {

        }

        public override double CalculateDesirability(Agent ag)
        {
            double desirability = 0.5;
            desirability *= CharacterBias;

            return desirability;
        }

        public override void SetGoal(Agent ag)
        {
            ag.Brain.AddGoal_EarnMoney();
        }
    }
}
