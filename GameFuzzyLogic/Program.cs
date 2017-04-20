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

            FzSet Target_Close = Dist2Target.AddTrianglularSet("Target_Close",
                0, 25, 150);
            FzSet Target_Medium = Dist2Target.AddTrianglularSet("Target_Medium",
                25, 150, 300);
            FzSet Target_Far = Dist2Target.AddTrianglularSet("Target_Far",
                150, 300, 500);

            FzSet Ammon_low = AmmoStatus.AddTrianglularSet("Ammon_low",
                0, 0, 10);
            FzSet Ammon_OKAY = AmmoStatus.AddTrianglularSet("Ammon_OKAY",
                0, 10, 30);
            FzSet Ammon_Loads = AmmoStatus.AddTrianglularSet("Ammon_Loads",
                10, 30, 40);

            FzSet Undesirable = Desirability.AddTrianglularSet("Undesirable",
                0, 25, 50);
            FzSet Desirable = Desirability.AddTrianglularSet("Desirable",
                25, 50, 75);
            FzSet VeryDesirable = Desirability.AddTrianglularSet("VeryDesirable",
                50, 75, 100);

            fm.AddRule(Target_Far, Undesirable);
            fm.AddRule(Target_Medium, Desirable);
            fm.AddRule(Target_Close, VeryDesirable);

            fm.AddRule(Ammon_low, Undesirable);
            fm.AddRule(Ammon_OKAY, Desirable);
            fm.AddRule(Ammon_Loads, VeryDesirable);

            fm.Fuzzify("Dist2Target", 25);
            fm.Fuzzify("AmmoStatus", 30);

            double result = fm.Defuzzify("Desirability", FuzzyModule.DefuzzifyMethod.max_av);

            Console.WriteLine("Dist2Target is {0}", fm.Defuzzify("Dist2Target", FuzzyModule.DefuzzifyMethod.max_av));
            Console.WriteLine("AmmoStatus is {0}", fm.Defuzzify("AmmoStatus", FuzzyModule.DefuzzifyMethod.max_av));
            Console.WriteLine("Desirability is {0}", result);
        }
    }
}
