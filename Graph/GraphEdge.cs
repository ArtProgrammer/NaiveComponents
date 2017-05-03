using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Graph
{
    class GraphEdge
    {
        protected int SrcNodeIndex = GraphNode.INVALID_NODE_INDEX;

        protected int DstNodeIndex = GraphNode.INVALID_NODE_INDEX;

        protected double EdgeCost = .0;

        public GraphEdge(int src, int dst, double cost)
        {
            SrcNodeIndex = src;
            DstNodeIndex = dst;
            EdgeCost = cost;
        }

        public GraphEdge(int src, int dst)
        {
            SrcNodeIndex = src;
            DstNodeIndex = dst;
            EdgeCost = 1.0;
        }

        public GraphEdge()
        {
            SrcNodeIndex = GraphNode.INVALID_NODE_INDEX;
            DstNodeIndex = GraphNode.INVALID_NODE_INDEX;
            EdgeCost = 1.0;
        }

        public int SrcIndex
        {
            set { SrcNodeIndex = value; }
            get { return SrcNodeIndex; }
        }

        public int DstIndex
        {
            set { DstNodeIndex = value; }
            get { return DstNodeIndex; }
        }

        public double Cost
        {
            set { EdgeCost = value; }
            get { return EdgeCost; }
        }
    }
}
