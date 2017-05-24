using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClass.FSM.TestFSM
{
    class SimpleC_SearchFood : State
    {
        public override void OnEnter()
        {

        }

        public override void OnExit()
        {

        }

        public override void Excute(SimpleC target)
        {
        }

        public override bool NeedTransition(SimpleC target)
        {
            return false;
        }
    }
}
