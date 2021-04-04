using NUnit.Framework;
using Princeton_Algorithms_2.Week1;

namespace Princeton_Algorithms_2_Tests.Week1
{
    public class DfsTests
    {
        [Test]
        public void SimpleDfsTest()
        {
            var graph = new Graph(3);
            graph.AddEdge(0, 1);
            AssertPaths(new DfsPaths(graph, 0));
        }
        
        [Test]
        public void SimpleBfsTest()
        {
            var graph = new Graph(3);
            graph.AddEdge(0, 1);
            AssertPaths(new BfsPaths(graph, 0));
        }

        private static void AssertPaths(Paths paths)
        {
            Assert.True(paths.HasPathTo(0));
            Assert.True(paths.HasPathTo(1));
            Assert.True(!paths.HasPathTo(2));
            CollectionAssert.AreEqual(new[] {0, 1}, paths.PathTo(1));
        }
    }
}