using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chuizi;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello {0}", "John");

            FuzzyModule fm = new FuzzyModule();
            FuzzyVariable Dist2Target = fm.CreateFLV("Dist2Target");
            FuzzyVariable Desirability = fm.CreateFLV("Desirability");
            FuzzyVariable AmmoStatus = fm.CreateFLV("AmmoStatus");
            
            FzSet Target_Close = Dist2Target.AddLeftShoulderSet("Target_Close",
                0, 25, 150);
            FzSet Target_Medium = Dist2Target.AddTrianglularSet("Target_Medium",
                25, 150, 300);
            FzSet Target_Far = Dist2Target.AddRightShoulderSet("Target_Far",
                150, 300, 400);

            FzSet Ammon_low = AmmoStatus.AddLeftShoulderSet("Ammon_low",
                0, 0, 10);
            FzSet Ammon_Okay = AmmoStatus.AddTrianglularSet("Ammon_Okay",
                0, 10, 30);
            FzSet Ammon_Loads = AmmoStatus.AddRightShoulderSet("Ammon_Loads",
                10, 30, 40);

            FzSet Undesirable = Desirability.AddLeftShoulderSet("Undesirable",
                0, 25, 50);
            FzSet Desirable = Desirability.AddTrianglularSet("Desirable",
                25, 50, 75);
            FzSet VeryDesirable = Desirability.AddRightShoulderSet("VeryDesirable",
                50, 75, 100);

            bool Combos = true;

            if (Combos) {
                fm.AddRule((Target_Far), Undesirable);
                fm.AddRule((Target_Medium), VeryDesirable);
                fm.AddRule((Target_Close), Undesirable);
                fm.AddRule((Ammon_Loads), VeryDesirable);
                fm.AddRule((Ammon_Okay), Desirable);
                fm.AddRule((Ammon_low), Undesirable);

                //fm.AddRule(new FzFairly(Target_Far), Undesirable);
                //fm.AddRule(new FzFairly(Target_Medium), VeryDesirable);
                //fm.AddRule(new FzFairly(Target_Close), Undesirable);
                //fm.AddRule(new FzFairly(Ammon_Loads), VeryDesirable);
                //fm.AddRule(new FzFairly(Ammon_Okay), Desirable);
                //fm.AddRule(new FzFairly(Ammon_low), Undesirable);

                //fm.AddRule(new FzVery(Target_Far), Undesirable);
                //fm.AddRule(new FzVery(Target_Medium), VeryDesirable);
                //fm.AddRule(new FzVery(Target_Close), Undesirable);
                //fm.AddRule(new FzVery(Ammon_Loads), VeryDesirable);
                //fm.AddRule(new FzVery(Ammon_Okay), Desirable);
                //fm.AddRule(new FzVery(Ammon_low), Undesirable);
            } else
            {
                fm.AddRule(new FzAND(Target_Far, Ammon_Loads), Desirable);
                fm.AddRule(new FzAND(Target_Far, Ammon_Okay), Undesirable);
                fm.AddRule(new FzAND(Target_Far, Ammon_low), Undesirable);

                fm.AddRule(new FzAND(Target_Medium, Ammon_Loads), VeryDesirable);
                fm.AddRule(new FzAND(Target_Medium, Ammon_Okay), VeryDesirable);
                fm.AddRule(new FzAND(Target_Medium, Ammon_low), Desirable);

                fm.AddRule(new FzAND(Target_Close, Ammon_Loads), Undesirable);
                fm.AddRule(new FzAND(Target_Close, Ammon_Okay), Undesirable);
                fm.AddRule(new FzAND(Target_Close, Ammon_low), Undesirable);
            }

            fm.Fuzzify("Dist2Target", 200);
            fm.Fuzzify("AmmoStatus", 8);

            double result = fm.Defuzzify("Desirability", FuzzyModule.DefuzzifyMethod.max_av);

            Console.WriteLine("Dist2Target is {0}", fm.Defuzzify("Dist2Target", FuzzyModule.DefuzzifyMethod.max_av));
            Console.WriteLine("AmmoStatus is {0}", fm.Defuzzify("AmmoStatus", FuzzyModule.DefuzzifyMethod.max_av));
            Console.WriteLine("Desirability is {0}", result);
        }
    }
}
