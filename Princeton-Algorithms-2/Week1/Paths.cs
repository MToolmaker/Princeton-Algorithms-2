using System.Collections.Generic;
using JetBrains.Annotations;

namespace Princeton_Algorithms_2.Week1
{
    [PublicAPI]
    public abstract class Paths
    {
        protected readonly int Vertex;
        protected int[] EdgeTo;
        protected bool[] Marked;

        protected Paths(Graph graph, int vertex)
        {
            Vertex = vertex;
            var numberOfVertices = graph.NumberOfVertices;
            EdgeTo = new int[numberOfVertices];
            Marked = new bool[numberOfVertices];
            // ReSharper disable once VirtualMemberCallInConstructor
            FindPaths(graph, vertex);
        }

        protected abstract void FindPaths(Graph graph, int vertex);

        public bool HasPathTo(int vertex)
        {
            return Marked[vertex];
        }

        public IEnumerable<int>? PathTo(int vertex)
        {
            if (!HasPathTo(vertex)) return null;
            var path = new Stack<int>();
            for (var i = vertex; i != Vertex; i = EdgeTo[i]) path.Push(i);
            path.Push(Vertex);
            return path;
        }
    }

    [PublicAPI]
    public sealed class DfsPaths : Paths
    {
        public DfsPaths(Graph graph, int vertex)
            : base(graph, vertex)
        {
        }

        protected override void FindPaths(Graph graph, int vertex)
        {
            Dfs(graph, vertex);
        }

        private void Dfs(Graph graph, int vertex)
        {
            Marked[vertex] = true;
            foreach (var adjacent in graph.AdjacentVerticesOf(vertex))
            {
                if (Marked[adjacent]) continue;
                Dfs(graph, adjacent);
                EdgeTo[adjacent] = vertex;
            }
        }
    }

    [PublicAPI]
    public sealed class BfsPaths : Paths
    {
        public BfsPaths(Graph graph, int vertex)
            : base(graph, vertex)
        {
        }

        protected override void FindPaths(Graph graph, int vertex)
        {
            var queue = new Queue<int>();
            queue.Enqueue(vertex);
            Marked[vertex] = true;
            while (queue.Count != 0)
            {
                var currentVertex = queue.Dequeue();
                foreach (var adjacent in graph.AdjacentVerticesOf(currentVertex))
                {
                    if (Marked[adjacent]) continue;
                    queue.Enqueue(adjacent);
                    Marked[adjacent] = true;
                    EdgeTo[adjacent] = currentVertex;
                }
            }
        }
    }
}