using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuizi.Graph
{
    class SparseGraph
    {
        private List<NavGraphNode> Nodes = new List<NavGraphNode>();

        private List<List<NavGraphEdge>> Edges = new List<List<NavGraphEdge>>();

        private bool IsDirectGraph = false;

        private int NextNodeIndex = 0;

        private int NodesNum = 0;

        private int ActiveNodesNum = 0;

        private int EdgesNum = 0;

        public SparseGraph(bool isDirect)
        {
            IsDirectGraph = isDirect;
            NextNodeIndex = 0;
        }

        public NavGraphNode GetNode(int index)
        {
            if (!IsNodePresent(index))
            {
                throw new System.ArgumentOutOfRangeException();
            }

            return Nodes[index];
        }

        public NavGraphEdge GetEdge(int srcNodeIndex, int dstNodeIndex)
        {
            if (!IsEdgePresent(srcNodeIndex, dstNodeIndex))
            {
                throw new System.ArgumentOutOfRangeException();
            }

            return Edges[srcNodeIndex][dstNodeIndex];
        }

        public int GetNextFreeNodeIndex()
        {
            return NextNodeIndex;
        }

        public int AddNode(NavGraphNode node)
        {
            if (node.Index < Nodes.Count)
            {
                Nodes[node.Index] = node;
            }
            else
            {
                Nodes.Add(node);
                Edges.Add(new List<NavGraphEdge>());

                NextNodeIndex++;

                NodesNum++;
            }

            return NextNodeIndex;
        }

        public void RemoveNode(int index)
        {
            if (!IsNodePresent(index))
            {
                throw new System.ArgumentOutOfRangeException();
            }

            Nodes[index].Index = NavGraphNode.INVALID_NODE_INDEX;

            if (!IsDirectGraph)
            {
                foreach (var edges in Edges[index])
                {
                    foreach (var edge in Edges[edges.DstIndex])
                    {
                        if (edge.DstIndex == index)
                        {
                            Edges[edges.DstIndex].Remove(edge);
                            break;
                        }
                    }
                }

                Edges[index].Clear();
            }
            else
            {
                CullInvalidEdges();
            }
        }

        public void AddEdge(NavGraphEdge edge)
        {
            if (edge.SrcIndex >= NextNodeIndex || edge.DstIndex >= NextNodeIndex)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            if (Nodes[edge.DstIndex].Index != NavGraphNode.INVALID_NODE_INDEX &&
                Nodes[edge.SrcIndex].Index != NavGraphNode.INVALID_NODE_INDEX)
            {
                if (UniqueEdge(edge.SrcIndex, edge.DstIndex))
                {
                    Edges[edge.SrcIndex].Add(edge);
                }

                if (!IsDirectGraph)
                {
                    if (UniqueEdge(edge.DstIndex, edge.SrcIndex))
                    {
                        NavGraphEdge newEdge = new NavGraphEdge(edge.SrcIndex,
                        edge.DstIndex,
                        edge.Cost,
                        edge.Flags);

                        Edges[edge.DstIndex].Add(newEdge);
                    }
                }
            }
        }

        public void RemoveEdge(int srcNodeIndex, int dstNodeIndex)
        {
            if (srcNodeIndex >= Nodes.Count ||
                dstNodeIndex >= Nodes.Count)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            if (!IsDirectGraph)
            {
                foreach (var edge in Edges[dstNodeIndex])
                {
                    if (edge.DstIndex == srcNodeIndex)
                    {
                        Edges[dstNodeIndex].Remove(edge);
                        break;
                    }
                }
            }
            
            foreach (var edge in Edges[srcNodeIndex])
            {
                if (edge.DstIndex == dstNodeIndex)
                {
                    Edges[srcNodeIndex].Remove(edge);
                }
            }
        }

        public List<NavGraphEdge> GetEdges(int nodeindex)
        {
            if (!IsNodePresent(nodeindex))
            {
                throw new ArgumentOutOfRangeException();
            }
            return Edges[nodeindex];
        }

        private void CullInvalidEdges()
        {
            foreach (var item in Edges)
            {
                foreach (var edge in item)
                {
                    if (Nodes[edge.DstIndex].Index == NavGraphNode.INVALID_NODE_INDEX ||
                        Nodes[edge.SrcIndex].Index == NavGraphNode.INVALID_NODE_INDEX)
                    {
                        item.Remove(edge);
                    }
                }
            }
        }

        public void SetEdgeCost(int srcNodeIndex, int dstNodeIndex, double cost)
        {
            if (srcNodeIndex >= Nodes.Count ||
                dstNodeIndex >= Nodes.Count)
            {
                throw new System.ArgumentOutOfRangeException();
            }

            foreach (var edge in Edges[srcNodeIndex])
            {
                if (edge.DstIndex == dstNodeIndex)
                {
                    edge.Cost = cost;
                    break;
                }
            }
        }

        public int NumOfNodes
        {
            get { return NodesNum; }
        }

        public int NumOfActiveNodes
        {
            get { return ActiveNodesNum; }
        }

        public int NumOfEdges
        {
            get { return EdgesNum; }
        }

        public bool IsDigraph
        {
            get { return IsDirectGraph; }
        }

        public bool IsEmpty
        {
            get { return NodesNum == 0; }
        }

        public bool IsNodePresent(int nodeindex)
        {
            return nodeindex < NodesNum && 
                Nodes[nodeindex].Index != NavGraphNode.INVALID_NODE_INDEX;
        }

        public bool IsEdgePresent(int srcNodeindex, int dstNodeIndex)
        {
            if (IsNodePresent(srcNodeindex) && IsNodePresent(srcNodeindex))
            {
                foreach (var edge in Edges[srcNodeindex])
                {
                    if (edge.DstIndex == dstNodeIndex)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool UniqueEdge(int srcNodeindex, int dstNodeIndex)
        {
            foreach (var edge in Edges[srcNodeindex])
            {
                if (edge.DstIndex == dstNodeIndex)
                {
                    return false;
                }
            }

            return true;
        }

        public void Clear()
        {
            NextNodeIndex = 0;
            Nodes.Clear();
            Edges.Clear();
        }

        public void RemoveEdges()
        {
            foreach (var item in Edges)
            {
                item.Clear();
            }

            Edges.Clear();
        }
    }
}
