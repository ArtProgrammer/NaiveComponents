using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClass.FSM.TestFSM
{
    class SimpleC_EatFood : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("$$$ start to eat food!");
        }

        public override void OnExit()
        {

        }

        public override void Excute(SimpleC target)
        {
            if (target != null)
            {
                target.EatFood();
            }
        }

        public override bool NeedTransition(SimpleC target)
        {
            if (target.IsFull() && FSM != null)
            {
                State dsts = GetOutputState("Sleep");
                if (dsts != null)
                {
                    FSM.TransferToState(dsts);
                }

                return true;
            }

            return false;
        }
    }
}
