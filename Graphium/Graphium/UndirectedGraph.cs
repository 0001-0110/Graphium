using System.Collections.ObjectModel;

namespace Graphium
{
	public abstract class UndirectedGraph<TVertex, TEdge> : Graph<TVertex, TEdge> where TVertex : UndirectedGraph<TVertex, TEdge>.Vertex where TEdge : UndirectedGraph<TVertex, TEdge>.Edge
	{
		public new abstract class Vertex : Graph<TVertex, TEdge>.Vertex
		{
			private IList<TEdge> _edges;

			public override IEnumerable<TEdge> GetEdges()
			{
				return new ReadOnlyCollection<TEdge>(_edges);
			}
		}

		public new abstract class Edge : Graph<TVertex, TEdge>.Edge
		{
			protected Edge(TVertex vertex1, TVertex vertex2) : base(vertex1, vertex2) { }
		}
	}
}
