using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Goal_Evaluator
    {
        protected double CharacterBias;

        public Goal_Evaluator(double bias)
        {
            CharacterBias = bias;
        }

        ~Goal_Evaluator() { }

        public virtual double CalculateDesirability(Agent ag) { return 0.0f; }

        public virtual void SetGoal(Agent ag) { }
    }
}
