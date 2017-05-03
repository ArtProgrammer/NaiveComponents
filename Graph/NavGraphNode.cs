using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Graph
{
    class NavGraphNodeExtraInfo
    {
        public NavGraphNodeExtraInfo()
        {

        }
    }

    class NavGraphNode : GraphNode
    {
        protected float Pos_X;

        protected float Pos_Y;

        protected NavGraphNodeExtraInfo ExtraInfo;

        public NavGraphNode(int index,
            float posx, 
            float posy) : base(index)
        {
            Pos_X = posx;
            Pos_Y = posy;
            ExtraInfo = new NavGraphNodeExtraInfo();
        }

        public NavGraphNode()
        {
            ExtraInfo = new NavGraphNodeExtraInfo();
        }

        public float PosX
        {
            get { return Pos_X; }
            set { Pos_X = value; }
        }

        public float PoxY
        {
            get { return PoxY; }
            set { PoxY = value; }
        }
    }
}
