using AdventOfCodeDay9;

var lines = File.ReadAllLines("input.txt");
IRouteFinder routeFinder = new RouteFinder(lines);

Console.WriteLine("Part 1");
routeFinder.FindLocationN();
var minimumDistance = routeFinder.GetMinimumDistance();
Console.WriteLine($"Shortest distance is: {minimumDistance}");
Console.WriteLine();

Console.WriteLine("Part 2");
var maximumDistance = routeFinder.GetMaximumDistance();
Console.WriteLine($"Longest distance is: {maximumDistance}");