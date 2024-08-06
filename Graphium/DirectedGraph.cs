using System.Collections.ObjectModel;

namespace Graphium
{
    public class DirectedGraph<TVertex, TEdge> : Graph<TVertex, TEdge> where TVertex : DirectedGraph<TVertex, TEdge>.Vertex where TEdge : DirectedGraph<TVertex, TEdge>.Edge
    {
        public new class Vertex : Graph<TVertex, TEdge>.Vertex
        {
            internal IList<TEdge> _incomingEdges;
            internal IList<TEdge> _outgoingEdges;

            public override IEnumerable<TEdge> Edges => new ReadOnlyCollection<TEdge>(_outgoingEdges);

            public Vertex()
            {
                _incomingEdges = new List<TEdge>();
                _outgoingEdges = new List<TEdge>();
            }
        }

        public new class Edge : Graph<TVertex, TEdge>.Edge
        {
            public TVertex Source => _vertex1;
            public TVertex Destination => _vertex2;

            public Edge(TVertex vertex1, TVertex vertex2) : base(vertex1, vertex2) { }
        }

        public void Connect(TEdge edge)
        {
            edge.Source._outgoingEdges.Add(edge);
            edge.Destination._incomingEdges.Add(edge);
        }
    }

    public class DirectedGraph : DirectedGraph<DirectedGraph.Vertex, DirectedGraph.Edge>
    {
        public new class Vertex : DirectedGraph<Vertex, Edge>.Vertex { }

        public new class Edge : DirectedGraph<Vertex, Edge>.Edge
        {
            public Edge(Vertex vertex1, Vertex vertex2) : base(vertex1, vertex2) { }
        }
    }
}
