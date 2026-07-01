using MiniRouteOptimizer.Models;

namespace MiniRouteOptimizer.Services;

public sealed class DijkstraService
{
    public RouteResult FindShortestPath(CityGraph graph, string origin, string destination)
    {
        var vertices = graph.GetVertices();

        if (!vertices.Contains(origin))
        {
            return new RouteResult(Array.Empty<string>(), int.MaxValue);
        }

        var distances = vertices.ToDictionary(v => v, _ => int.MaxValue);
        var previous = vertices.ToDictionary(v => v, _ => (string?)null);
        var priorityQueue = new PriorityQueue<string, int>();
        var visited = new HashSet<string>();

        distances[origin] = 0;
        priorityQueue.Enqueue(origin, 0);

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue();

            if (visited.Contains(current))
            {
                continue;
            }

            visited.Add(current);

            if (current == destination)
            {
                break;
            }

            foreach (var edge in graph.GetNeighbors(current))
            {
                if (distances[current] == int.MaxValue)
                {
                    continue;
                }

                var newDistance = distances[current] + edge.Cost;

                if (newDistance < distances[edge.To])
                {
                    distances[edge.To] = newDistance;
                    previous[edge.To] = current;
                    priorityQueue.Enqueue(edge.To, newDistance);
                }
            }
        }

        if (distances[destination] == int.MaxValue)
        {
            return new RouteResult(Array.Empty<string>(), int.MaxValue);
        }

        var path = new List<string>();
        for (var current = destination; current is not null; current = previous[current])
        {
            path.Add(current);
        }

        path.Reverse();

        return new RouteResult(path, distances[destination]);
    }
}
