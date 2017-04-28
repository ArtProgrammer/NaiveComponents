using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Goal_GetGirls : Goal_Composite<Agent>
    {

        public Goal_GetGirls(Agent ag) : base (ag, Agent_Goal_Types.goal_getGirls)
        {
            
        }

        public override void Activate()
        {
            Status = Goal_Status.active;

            RemoveAllSubgoals();

            AddSubgoal(new Goal_GetMoney(Owner));

            Console.WriteLine("$start to get girls, go!");
        }

        public override Goal_Status Process()
        {
            ActiveIfInactive();

            Status = ProcessSubgoals();

            if (Status == Goal_Status.completed)
            {
                Console.WriteLine("$girls got!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                Owner.Girlsnum += 1;
                Owner.Willing = 0;
            }

            return Status;
        }

        public override void Terminate()
        {
            base.Terminate();
        }

        public override bool HandleMessage()
        {
            return base.HandleMessage();
        }
    }
}
