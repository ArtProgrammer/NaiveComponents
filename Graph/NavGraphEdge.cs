using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Graph
{
    class NavGraphEdge : GraphEdge
    {
        public enum EdgeFlags
        {
            normal,
            swim,
            crawl,
            creep,
            jump,
            fly,
            grapple,
            goes_through_door
        }

        protected EdgeFlags SelfFlags = EdgeFlags.normal;

        protected int TheIDofIntersectingEntity;

        public EdgeFlags Flags
        {
            get { return SelfFlags; }
            set { SelfFlags = value; }
        }

        public int IDofIntersectingEntity
        {
            get { return TheIDofIntersectingEntity; }
            set { TheIDofIntersectingEntity = value; }
        }

        public NavGraphEdge(int src, int dst, double cost,
            EdgeFlags flags,
            int id = -1) : base(src, dst, cost)
        {
            SelfFlags = flags;
            TheIDofIntersectingEntity = id;
        }
    }
}
