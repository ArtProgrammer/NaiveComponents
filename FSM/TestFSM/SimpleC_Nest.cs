using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpClass.FSM.TestFSM
{
    class SimpleC_Nest : State
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
