using System.Collections.ObjectModel;

namespace Graphium
{
	public class UndirectedGraph<TVertex, TEdge> : Graph<TVertex, TEdge> where TVertex : UndirectedGraph<TVertex, TEdge>.Vertex where TEdge : UndirectedGraph<TVertex, TEdge>.Edge
	{
		public new class Vertex : Graph<TVertex, TEdge>.Vertex
		{
			private IList<TEdge> _edges;

			public override IEnumerable<TEdge> GetEdges()
			{
				return new ReadOnlyCollection<TEdge>(_edges);
			}

            public Vertex()
            {
                _edges = new List<TEdge>();
            }
		}

		public new class Edge : Graph<TVertex, TEdge>.Edge
		{
			public Edge(TVertex vertex1, TVertex vertex2) : base(vertex1, vertex2) { }
		}
	}

    public class UndirectedGraph : UndirectedGraph<UndirectedGraph.Vertex, UndirectedGraph.Edge>
    {
        public new class Vertex : UndirectedGraph<Vertex, Edge>.Vertex { }

        public new class Edge : UndirectedGraph<Vertex, Edge>.Edge
        {
            public Edge(Vertex vertex1, Vertex vertex2) : base(vertex1, vertex2) { }
        }
    }
}
