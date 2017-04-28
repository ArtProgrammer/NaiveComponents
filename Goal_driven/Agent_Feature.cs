using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Goal_driven
{
    class Agent_Feature
    {
        public static double Health(Agent ag)
        {
            return 0.0;
        }

        public static double DistanceToItem(Agent ag, int itemtype)
        {
            return 0.0;
        }

        public static double IndividualWeaponStrength(Agent ag, int weapontype)
        {
            return 0.0;
        }

        public static double TotalWeaponStrength(Agent ag)
        {
            return 0.0;
        }

        public static double WillingToGirls(Agent ag)
        {
            return ag.Willing / ag.MaxWilling;
        }

        public static double WillingToStudy(Agent ag)
        {
            return (1 - ag.Willing/ ag.MaxWilling);
        }
    }
}
