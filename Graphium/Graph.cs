using System.Collections;

namespace Graphium
{
    public abstract class Graph<TVertex, TEdge> where TVertex : Graph<TVertex, TEdge>.Vertex where TEdge : Graph<TVertex, TEdge>.Edge
    {
        private class VertextCollection : ICollection<TVertex>
        {
            private readonly List<TVertex> _edges;

            public int Count => _edges.Count;
            public bool IsReadOnly => false;

            public VertextCollection()
            {
                _edges = new List<TVertex>();
            }

            public void Add(TVertex vertex)
            {
                _edges.Add(vertex);
            }

            public bool Remove(TVertex vertex)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                _edges.Clear();
            }

            public bool Contains(TVertex vertex)
            {
                return _edges.Contains(vertex);
            }

            public void CopyTo(TVertex[] array, int arrayIndex)
            {
                _edges.CopyTo(array, arrayIndex);
            }

            public IEnumerator<TVertex> GetEnumerator()
            {
                return _edges.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _edges.GetEnumerator();
            }
        }

        public abstract class Vertex
        {
            public abstract IEnumerable<TEdge> Edges { get; }

            public IEnumerable<TVertex> Neighbors => Edges.Select(edge => edge.GetOppositeNeighbor(this));
        }

        public abstract class Edge
        {
            internal TVertex _vertex1;
            internal TVertex _vertex2;

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

        public ICollection<TVertex> Vertices { get; }

        public Graph()
        {
            Vertices = new VertextCollection();
        }
    }
}
