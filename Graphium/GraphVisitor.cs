namespace Graphium
{
    public class GraphVisitor<TVertex, TEdge> where TVertex : Graph<TVertex, TEdge>.Vertex where TEdge : Graph<TVertex, TEdge>.Edge
    {
        public TVertex CurrentPosition { get; private set; }

        public GraphVisitor(TVertex start)
        {
            CurrentPosition = start;
        }

        public void Traverse(TEdge edge)
        {
#if DEBUG
            // TODO
            if (false)
                throw new ArgumentException("This edge is not accessible from the current position");
#endif

            CurrentPosition = edge.GetOppositeNeighbor(CurrentPosition);
        }
    }
}
