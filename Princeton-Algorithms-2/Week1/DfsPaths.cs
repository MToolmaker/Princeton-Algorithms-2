using System.Collections.Generic;
using JetBrains.Annotations;

namespace Princeton_Algorithms_2.Week1
{
    [PublicAPI]
    public sealed class DfsPaths
    {
        private int[] _edgeTo;
        private bool[] _marked;
        private readonly int _vertex;

        public DfsPaths(Graph graph, int vertex)
        {
            _vertex = vertex;
            var numberOfVertices = graph.NumberOfVertices;
            _edgeTo = new int[numberOfVertices];
            _marked = new bool[numberOfVertices];
            Dfs(graph, vertex);
        }

        private void Dfs(Graph graph, int vertex)
        {
            _marked[vertex] = true;
            foreach (var adjacent in graph.AdjacentVerticesOf(vertex))
            {
                if (_marked[adjacent]) continue;
                Dfs(graph, adjacent);
                _edgeTo[adjacent] = vertex;
            }
        }

        public bool HasPathTo(int vertex) => _marked[vertex];
        
        public IEnumerable<int>? PathTo(int vertex)
        {
            if (!HasPathTo(vertex)) return null;
            var path = new Stack<int>();
            for (var i = vertex; i != _vertex; i = _edgeTo[i]) path.Push(i);
            path.Push(_vertex);
            return path;
        }
    }
}