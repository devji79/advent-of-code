namespace AdventOfCodeDay9;

public class Route
{
    public string Origin { get; }
    public string Destination { get; }
    public int Distance { get; }

    public Route(string origin, string destination, int distance)
    {
        this.Origin = origin;
        this.Destination = destination;
        this.Distance = distance;
    }
}