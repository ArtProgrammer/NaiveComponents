using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClass.FSM.TestFSM
{
    class SimpleC_Sleep : State
    {
        public override void OnEnter()
        {
            Console.WriteLine("$$$ start to sleep");
        }

        public override void OnExit()
        {

        }

        public override void Excute(SimpleC target)
        {
            if (target != null)
            {
                target.Sleep();
            }
        }

        public override bool NeedTransition(SimpleC target)
        {
            if (target != null && target.IsHungery())
            {
                State dsts = GetOutputState("EatFood");
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
