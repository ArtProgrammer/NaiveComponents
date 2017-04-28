using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Goal_Composite<T> : Goal<T>
    {
        public Goal_Composite(T owner, Agent_Goal_Types type) : base(owner, type)
        {

        }

        ~Goal_Composite() { RemoveAllSubgoals(); }


        protected Stack<Goal<T>> SubGoals = new Stack<Goal<T>>();

        protected Goal_Status ProcessSubgoals()
        {
            while (SubGoals.Count > 0 &&
                (SubGoals.Peek().isComplete() && SubGoals.Peek().hasFailed()))
            {
                SubGoals.Peek().Terminate();
                var item = SubGoals.Pop();
                item = null;
            }

            if (SubGoals.Count > 0)
            {
                Goal_Status gs = SubGoals.Peek().Process();
                if (gs == Goal_Status.completed && SubGoals.Count > 1)
                {
                    return Goal_Status.active;
                }

                return gs;
            } else
            {
                return Goal_Status.completed;
            }
        }

        protected bool ForwardMessageToFrontMostSubgoal(/*msg*/)
        {
            if (SubGoals.Count > 0)
            {
                return SubGoals.Peek().HandleMessage(/*msg*/);
            }

            return false;
        }

        public override void Activate()
        {
            base.Activate();
        }

        public override Goal_Status Process()
        {
            return base.Process();
        }

        public override void Terminate()
        {
            base.Terminate();
        }

        public override bool HandleMessage(/*msg*/)
        {
            return base.HandleMessage(/*msg*/);
        }

        public override void AddSubgoal(Goal<T> g)
        {
            SubGoals.Push(g);
        }

        public void RemoveAllSubgoals()
        {
            foreach (var item in SubGoals)
            {
                item.Terminate();                
            }

            SubGoals.Clear();
        }
    }
}
