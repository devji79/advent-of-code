namespace AdventOfCodeDay9;

public class RouteFinder : IRouteFinder
{
    private readonly List<Route> _routes;
    private readonly List<string> _locations;
    private readonly string?[] _route;
    
    private int _minimumDistance;
    private int _maximumDistance;
    
    public RouteFinder(string[] lines)
    {
        _routes = new List<Route>();
        foreach (var line in lines)
        {
            var parts = line.Split(new[] { " to ", " = " }, StringSplitOptions.RemoveEmptyEntries);
            var route = new Route(parts[0], parts[1], int.Parse(parts[2]));
            _routes.Add(route);
        }
        
        _locations = _routes.Select(r => r.Origin)
            .Concat(_routes.Select(r => r.Destination))
            .Distinct()
            .OrderBy(l => l)
            .ToList();

        _route = new string?[_locations.Count];

        _minimumDistance = 0;
        _maximumDistance = 0;
    }

    public void FindLocationN(int index = 0)
    {
        if (index >= _locations.Count)
        {
            if (IsRouteValid())
            {
                var distance = CalculateDistance();
                //Console.WriteLine("Solution found: " + string.Join(" -> ", _route) + " . Distance: " + distance);
                
                if (distance > 0 && (_minimumDistance == 0 || distance < _minimumDistance))
                {
                    _minimumDistance = distance;
                }

                if (distance > _maximumDistance)
                {
                    _maximumDistance = distance;
                }
            }
            
            return;
        } 
            
        for (var i = 0; i < _locations.Count; i++)
        {
            _route[index] = _locations[i];
            if (IsMoveValid())
            {
                FindLocationN(index + 1);
            }
            else
            {
                _route[index] = null;
            }
        }
        
        _route[index] = null;
    }

    private bool IsMoveValid()
    {
        var allLocationsInRoute = _route.Where(l => l != null).ToList();
        var distinctLocationsInRoute = allLocationsInRoute.Distinct().ToList();
        return allLocationsInRoute.Count == distinctLocationsInRoute.Count();
    }
    
    private bool IsRouteValid()
    {
        return _locations.All(l => _route.Contains(l));
    }

    private int CalculateDistance()
    {
        var distance = 0;

        for (var i = 0; i < _route.Length - 1; i++)
        {
            var route = _routes.SingleOrDefault(r => (r.Origin == _route[i] && r.Destination == _route[i + 1]) ||
                                                          (r.Origin == _route[i + 1] && r.Destination == _route[i]));
            if (route == null)
            {
                return 0;
            }
            distance += route.Distance;
        }

        return distance;
    }

    public int GetMinimumDistance()
    {
        return _minimumDistance;
    }
    
    public int GetMaximumDistance()
    {
        return _maximumDistance;
    }
}