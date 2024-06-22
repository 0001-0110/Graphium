using System.Collections.ObjectModel;

namespace Graphium
{
	public abstract class DirectedGraph<TVertex, TEdge> : Graph<TVertex, TEdge> where TVertex : DirectedGraph<TVertex, TEdge>.Vertex where TEdge : DirectedGraph<TVertex, TEdge>.Edge
	{
		public new abstract class Vertex : Graph<TVertex, TEdge>.Vertex
		{
			private IList<TEdge> _incomingEdges;
			private IList<TEdge> _outgoingEdges;

			public override IEnumerable<TEdge> GetEdges()
			{
				return new ReadOnlyCollection<TEdge>(_outgoingEdges);
			}

			protected Vertex()
			{
				_incomingEdges = new List<TEdge>();
				_outgoingEdges = new List<TEdge>();
			}
		}

		public new abstract class Edge : Graph<TVertex, TEdge>.Edge
		{
			protected Edge(TVertex vertex1, TVertex vertex2) : base(vertex1, vertex2) { }
		}
	}
}
