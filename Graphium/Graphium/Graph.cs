using System.Collections.ObjectModel;

namespace Graphium
{
	public abstract class Graph<TVertex, TEdge> where TVertex : Graph<TVertex, TEdge>.Vertex where TEdge : Graph<TVertex, TEdge>.Edge
	{
		public abstract class Vertex
		{
			public abstract IEnumerable<TEdge> GetEdges();

			public IEnumerable<TVertex> GetNeighbors()
			{
				return GetEdges().Select(edge => edge.GetOppositeNeighbor(this));
			}
		}

		public abstract class Edge
		{
			private TVertex _vertex1;
			private TVertex _vertex2;

			protected Edge(TVertex vertex1, TVertex vertex2)
			{
				_vertex1 = vertex1;
				_vertex2 = vertex2;
			}

			public TVertex GetOppositeNeighbor(Vertex vertex)
			{
				if (vertex == _vertex1)
					return _vertex2;
				if (vertex == _vertex2)
					return _vertex1;
				throw new ArgumentException("You seem to be confused about life");
			}
		}

		private IList<TVertex> _vertices;
		public IEnumerable<TVertex> Vertices { get { return new ReadOnlyCollection<TVertex>(_vertices); } }

		public Graph()
		{
			_vertices = new List<TVertex>();
		}
	}
}
