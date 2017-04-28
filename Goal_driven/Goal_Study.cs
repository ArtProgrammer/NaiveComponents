using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Goal_Study : Goal_Composite<Agent>
    {
        public int WillingToOutofControl = 100;

        public int WillingPerRound = 10;

        public Goal_Study(Agent ag) : base(ag, Agent_Goal_Types.goal_study)
        {

        }

        public override void Activate()
        {
            Console.WriteLine("###### start to study!");

            Status = Goal_Status.active;
        }

        public override Goal_Status Process()
        {
            if (Owner.Willing >= WillingToOutofControl)
            {
                Status = Goal_Status.failed;
                Console.WriteLine("###### tired of study, let's have some fun!");
            }
            else
            {
                Owner.Willing += WillingPerRound;
                Console.Write("abc... 123...");            
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
