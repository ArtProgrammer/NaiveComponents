using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Graph
{
    class GraphNode
    {
        public static int INVALID_NODE_INDEX = -1;

        private int NodeIndex = 0;

        public int Index
        {
            get { return NodeIndex; }
            set { NodeIndex = value; }
        }

        public GraphNode()
        {
            NodeIndex = INVALID_NODE_INDEX;
        }

        public GraphNode(int index)
        {
            NodeIndex = index;
        }

        ~GraphNode()
        {
            NodeIndex = INVALID_NODE_INDEX;
        }
    }
}
