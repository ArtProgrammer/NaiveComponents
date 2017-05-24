using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClass.FSM.TestFSM
{
    class Regulator
    {
        private double UpdatePeriod = 0.0;

        private long NextUpdateTime = 0;

        private const double UpdatePeriodVaristor = 10.0;

        public Regulator(double numUpdatesPerSecondRqd)
        {
            NextUpdateTime = DateTime.Now.Ticks / 10000;

            if (numUpdatesPerSecondRqd > 0)
            {
                UpdatePeriod = 1000.0 / numUpdatesPerSecondRqd;
            }
            else if (Double.Equals(0.0, numUpdatesPerSecondRqd))
            {
                UpdatePeriod = 0.0;
            }
            else if (numUpdatesPerSecondRqd < 0.0)
            {
                UpdatePeriod = -1;
            }
        }

        public bool IsReady()
        {
            if (Double.Equals(0.0, UpdatePeriod)) return true;

            if (UpdatePeriod < 0) return false;

            long curTime = DateTime.Now.Ticks / 10000;

            if (curTime >= NextUpdateTime)
            {
                NextUpdateTime = curTime + (long)UpdatePeriod + (long)(Math.Round(UpdatePeriodVaristor) - UpdatePeriodVaristor * 0.5);
                return true;
            }

            return false;
        }
    }
}
