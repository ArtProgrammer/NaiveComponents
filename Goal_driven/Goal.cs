using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    public class Goal<T>
    {
        public enum Goal_Status
        {
            active,
            inactive,
            completed,
            failed
        }

        protected Agent_Goal_Types Type;

        protected T Owner;

        protected Goal_Status Status;

        protected void ActiveIfInactive()
        {
            if (isInactive())
            {
                Activate();
            }
        }

        protected void ReactiveIfFailed()
        {
            if (hasFailed())
            {
                Status = Goal_Status.inactive;
            }
        }

        public Goal(T owner, Agent_Goal_Types type)
        {
            Owner = owner;
            Type = type;
            Status = Goal_Status.inactive;
        }

        ~Goal() { }

        public virtual void Activate() { }
        public virtual Goal_Status Process() { return Goal_Status.inactive; }
        public virtual void Terminate() { }
        public virtual bool HandleMessage(/*msg*/) { return false; }

        public virtual void AddSubgoal(Goal<T> g)
        {
        }

        public bool isComplete()
        {
            return Status == Goal_Status.completed;
        }

        public bool isActive()
        {
            return Status == Goal_Status.active;
        }

        public bool isInactive()
        {
            return Status == Goal_Status.inactive;
        }

        public bool hasFailed()
        {
            return Status == Goal_Status.failed;
        }

        public Agent_Goal_Types GetGoalType() { return Type; }
    }
}
