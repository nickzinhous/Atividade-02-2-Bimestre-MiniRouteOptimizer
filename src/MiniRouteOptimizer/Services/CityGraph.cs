using MiniRouteOptimizer.Models;

namespace MiniRouteOptimizer.Services;

public sealed class CityGraph
{
    private readonly Dictionary<string, List<Edge>> _adjacency = new();

    public void AddConnection(string from, string to, int cost)
    {
        if (cost < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cost), "O custo não pode ser negativo.");
        }

        if (!_adjacency.ContainsKey(from))
        {
            _adjacency[from] = new List<Edge>();
        }

        if (!_adjacency.ContainsKey(to))
        {
            _adjacency[to] = new List<Edge>();
        }

        _adjacency[from].Add(new Edge(from, to, cost));
    }

    public IReadOnlyCollection<string> GetVertices()
    {
        return _adjacency.Keys.ToList();
    }

    public IReadOnlyCollection<Edge> GetEdges()
    {
        return _adjacency.Values.SelectMany(edges => edges).ToList();
    }

    public IReadOnlyCollection<Edge> GetNeighbors(string vertex)
    {
        if (!_adjacency.TryGetValue(vertex, out var neighbors))
        {
            return Array.Empty<Edge>();
        }

        return neighbors.ToList();
    }
}
