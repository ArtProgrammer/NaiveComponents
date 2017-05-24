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

        List<State> StateList = new List<State>();

        State CurrentState = null;

        State PrevState = null;

        State GlobalState = null;

        public void AddState(State s)
        {
            StateList.Add(s);

            s.RecordFSM(this);
        }

        public void RemoveState(State s)
        {
            StateList.Remove(s);
        }
        
        public void Excute()
        {
            if (CurrentState != null && !CurrentState.NeedTransition(Owner))
            {
                CurrentState.Excute(Owner);
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
