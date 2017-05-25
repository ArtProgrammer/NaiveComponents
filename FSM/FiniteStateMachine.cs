using System;
using System.Collections.Generic;
using CSharpClass.FSM.TestFSM;

namespace CSharpClass.FSM
{
    class FiniteStateMachine
    {
        // Owner
        public SimpleC Owner
        {
            set; get;
        }

        Dictionary<string, State> StateList = new Dictionary<string, State>();

        State CurrentState = null;

        State PrevState = null;

        State GlobalState = null;

        public void AddState(string name, State s)
        {
	    if (!StateList.ContainsKey(name)) {
		StateList.Add(name, s);

		s.RecordFSM(this);
	    }
        }

        public void RemoveState(string name)
        {
            StateList.Remove(name);
        }
        
        public void Excute()
        {
            if (CurrentState != null && !CurrentState.NeedTransition(Owner))
            {
                CurrentState.Excute(Owner);
            }
        }
	
	public void TransferToState(name)
	{
	    if (StateList.ContainsKey(name))
	    {
		TransferToState(StateList[name]);
	    }
	}

        public void TransferToState(State s)
        {
            if (s == null)
            {
                // alert
                return;
            }

            PrevState = CurrentState;

            if (PrevState != null)
            {
                PrevState.OnExit();
            }

            CurrentState = s;

            CurrentState.OnEnter();
        }

        public void RevertToPrevState()
        {
            TransferToState(PrevState);
        }
    }
}
