using System;
using System.Collections.Generic;
using CSharpClass.FSM.TestFSM;

namespace CSharpClass.FSM
{
    abstract class State
    {
        Dictionary<string, State> TransitionPool = new Dictionary<string, State>();

        protected FiniteStateMachine FSM = null;

        public virtual void RecordFSM(FiniteStateMachine fsm)
        {
            FSM = fsm;
        }

        public virtual void AddTransition(string name, State dstState)
        {
            TransitionPool.Add(name, dstState);
        }

        public virtual void RemoveTransition(string name)
        {
            if (TransitionPool.ContainsKey(name))
            {
                TransitionPool.Remove(name);
            }
        }

        public virtual State GetOutputState(string name)
        {
            if (TransitionPool.ContainsKey(name))
            {
                return TransitionPool[name];
            }

            return null;
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void Excute(SimpleC target)
        {
        }

        public virtual bool NeedTransition(SimpleC target)
        {
            return false;
        }
    }
}
