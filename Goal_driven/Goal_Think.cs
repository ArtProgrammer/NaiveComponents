using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Goal_Think : Goal_Composite<Agent>
    {
        private List<Goal_Evaluator> GoalEvaluators =
            new List<Goal_Evaluator>();

        public Goal_Think(Agent ag) : base(ag, Agent_Goal_Types.goal_think)
        {
            const double LowRangeOfBias = 0.5;
            const double HightRangeOfBias = 1.5;

            double moneyBias = Math.Round(HightRangeOfBias - LowRangeOfBias) + LowRangeOfBias;
            double willingGirlsBias = Math.Round(HightRangeOfBias - LowRangeOfBias) + LowRangeOfBias;
            double studyBias = Math.Round(HightRangeOfBias - LowRangeOfBias) + LowRangeOfBias;

            //GoalEvaluators.Add(new GetMoney_Evaluator(moneyBias));
            GoalEvaluators.Add(new GetGirls_Evaluator(willingGirlsBias));
            GoalEvaluators.Add(new Study_Evaluator(studyBias));
        }

        ~Goal_Think()
        {
            GoalEvaluators.Clear();
        }

        public void Arbitrate()
        {
            double best = 0;
            Goal_Evaluator mostDesirable = null;

            foreach (var item in GoalEvaluators)
            {
                double desirability = item.CalculateDesirability(Owner);
                if (desirability >= best)
                {
                    best = desirability;
                    mostDesirable = item;
                }
            }

            if (mostDesirable != null) {
                mostDesirable.SetGoal(Owner);
            }
        }

        public bool notPresent(Agent_Goal_Types goaltype)
        {
            if (SubGoals.Count > 0)
            {
                return SubGoals.Peek().GetGoalType() != goaltype;
            }

            return true;
        }

        public override Goal_Status Process()
        {
            ActiveIfInactive();

            Goal_Status sgs = ProcessSubgoals();

            if (sgs == Goal_Status.completed || sgs == Goal_Status.failed)
            {
                //if (!Owner.isProcessed())
                {
                    Status = Goal_Status.inactive;
                }
            }

            return Status;
        }

        public override void Activate()
        {
            //if (!Owner.isProcessed())
            {
                Arbitrate();
            }

            Status = Goal_Status.active;
        }

        public override void Terminate()
        {
            base.Terminate();
        }

        public void AddGoal_BuildProducts()
        {
            if (notPresent(Agent_Goal_Types.goal_buildProduct))
            {
                RemoveAllSubgoals();
            }
        }

        public void AddGoal_EarnMoney()
        {
            AddSubgoal(new Goal_GetMoney(Owner));
        }

        public void AddGoal_PlayWithGirls()
        {
            AddSubgoal(new Goal_GetGirls(Owner));
        }

        public void AddGoal_Study()
        {
            AddSubgoal(new Goal_Study(Owner));
        }
    }
}
