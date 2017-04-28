using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Goal_GetMoney : Goal<Agent>
    {
        public int TargetMoneyCount = 1000;

        public int MoneyPerTime = 10;

        public Goal_GetMoney(Agent ag) : base(ag, Agent_Goal_Types.goal_getMoney)
        {
            
        }

        public override void Activate()
        {
            Status = Goal_Status.active;
            Console.WriteLine("$ Start get money!");
        }

        public override Goal_Status Process()
        {
            if (Owner.Money >= TargetMoneyCount)
            {
                Status = Goal_Status.completed;
                Console.WriteLine("$money enough to get girls");
            } else
            {
                Owner.Money += MoneyPerTime;
                Console.WriteLine("$ holy money got! {0}", Owner.Money);
            }

            return Status;
        }

        public override void Terminate()
        {
            base.Terminate();
        }
    }
}
