using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chuizi.Graph
{
    class Graph_SearchDFS
    {
        private enum SearchSignal
        {
            visited,
            unvisited,
            no_parent_assigned
        }

        private SparseGraph ConcreteGraph;

        private List<SearchSignal> Visited = new List<SearchSignal>();

        private List<int> Route = new List<int>();

        private List<GraphEdge> SpanningTree = new List<GraphEdge>();

        private int SrcIndex;

        private int DstIndex;

        private bool Found = false;

        private bool Search()
        {
            Stack<GraphEdge> stack = new Stack<GraphEdge>();

            GraphEdge dummy = new GraphEdge(SrcIndex, SrcIndex, 0.0);

            stack.Push(dummy);

            while (stack.Count > 0)
            {
                GraphEdge next = stack.Pop();

                Route[next.DstIndex] = next.SrcIndex;

                if (next != dummy)
                {
                    SpanningTree.Add(next);
                }

                Visited[next.DstIndex] = SearchSignal.visited;

                if (next.DstIndex == DstIndex)
                {
                    return true;
                }

                foreach (var edge in ConcreteGraph.GetEdges(next.DstIndex))
                {
                    if (Visited[edge.DstIndex] == SearchSignal.unvisited)
                    {
                        stack.Push(edge);
                    }
                }            
            }

            return false;
        }

        public Graph_SearchDFS(SparseGraph graph,
            int srcIndex,
            int dstIndex)
        {
            ConcreteGraph = graph;
            SrcIndex = srcIndex;
            DstIndex = dstIndex;

            for (int i = 0; i < graph.NumOfNodes; ++i)
            {
                Visited.Add(SearchSignal.unvisited);
                Route.Add(0);
            }

            Found = Search();
        }

        public List<GraphEdge> GetSearchTree()
        {
            return SpanningTree;
        }

        public Stack<int> GetPathToTarget()
        {
            Stack<int> path = new Stack<int>();

            if (!Found || DstIndex < 0) return path;

            int nd = DstIndex;

            path.Push(nd);

            while (nd != SrcIndex)
            {
                nd = Route[nd];
                path.Push(nd);
            }

            return path;
        }
    }
}
