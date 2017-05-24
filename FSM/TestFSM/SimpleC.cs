using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpClass.FSM.TestFSM
{
    class SimpleC
    {
        FiniteStateMachine FSM = null;

        public int FullAcount
        { set; get; }

        public int MaxFullAcount
        { set; get; }

        public SimpleC()
        {
            
        }
        
        public void ConfigFSM()
        {
            FSM = new FiniteStateMachine();
            FSM.Owner = this;

            SimpleC_EatFood s_eat = new SimpleC_EatFood();
            SimpleC_Sleep s_sleep = new SimpleC_Sleep();

            s_eat.AddTransition("Sleep", s_sleep);
            s_sleep.AddTransition("EatFood", s_eat);

            FSM.AddState(s_eat);
            FSM.AddState(s_sleep);

            FSM.TransferToState(s_sleep);
        }       
        
        public void Update()
        {
            if (FSM != null) { FSM.Excute(); }
        } 

        public bool IsHungery()
        {
            return FullAcount <= 0;
        }

        public bool IsFull()
        {
            return FullAcount >= MaxFullAcount;
        }

        public void Sleep()
        {
            FullAcount -= 10;
            Console.WriteLine("$ z z Z !");
        }

        public void EatFood()
        {
            FullAcount += 10;
            Console.WriteLine("$ good test...");
        }
    }
}
