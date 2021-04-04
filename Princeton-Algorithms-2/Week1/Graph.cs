using System.Collections.Generic;
using JetBrains.Annotations;

namespace Princeton_Algorithms_2.Week1
{
    [PublicAPI]
    public class Graph
    {
        public int NumberOfVertices { get; }
        private List<int>[] _adjacentVerticesOf; 
        
        public Graph(int numberOfVertices)
        {
            NumberOfVertices = numberOfVertices;
            _adjacentVerticesOf = new List<int>[numberOfVertices];
            for (var i = 0; i < NumberOfVertices; i++) _adjacentVerticesOf[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            _adjacentVerticesOf[v].Add(w);
            _adjacentVerticesOf[w].Add(v);
        }
        
        public IEnumerable<int> AdjacentVerticesOf(int v) => _adjacentVerticesOf[v];
    }
}