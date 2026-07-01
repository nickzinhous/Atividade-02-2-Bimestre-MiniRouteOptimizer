using MiniRouteOptimizer.Models;

namespace MiniRouteOptimizer.Services;

public sealed class RouteSorter
{
    public IEnumerable<RouteResult> SortByCostThenStops(IEnumerable<RouteResult> routes)
    {
        return routes.OrderBy(route => route.TotalCost).ThenBy(route => route.Stops);
    }
}
