using System.Data;
using AdventOfCodeDay6;

var lines = File.ReadAllLines("input.txt");
ILightGrid lightGrid;

// Part 1
Console.WriteLine("Part 1");
lightGrid = new LightGrid(1000);
ProcessLightInput(lines, lightGrid.Switch);
var lightsLit = lightGrid.CountLit();
Console.WriteLine($"Number of lights lit: {lightsLit}");
Console.WriteLine();

// Part 2
Console.WriteLine("Part 2");
lightGrid = new LightGrid(1000);
ProcessLightInput(lines, lightGrid.Adjust);
var totalBrightness = lightGrid.TotalBrightness();
Console.WriteLine($"Total brightness: {totalBrightness}");

void ProcessLightInput(string[] inputLines, Action<string, int, int, int, int> action)
{
    foreach (var line in inputLines)
    {
        var parts = line.Split(" ");
        string? command = null;
        string[] startParts, endParts;
        int startX = -1, startY = -1, endX = -1, endY = -1;
        if (parts[0] == "turn")
        {
            command = $"turn {parts[1]}";
            startParts = parts[2].Split(",");
            startX = int.Parse(startParts[0]);
            startY = int.Parse(startParts[1]);
            endParts = parts[4].Split(",");
            endX = int.Parse(endParts[0]);
            endY = int.Parse(endParts[1]);
        } 
        else if (parts[0] == "toggle")
        {
            command = "toggle";
            startParts = parts[1].Split(",");
            startX = int.Parse(startParts[0]);
            startY = int.Parse(startParts[1]);
            endParts = parts[3].Split(",");
            endX = int.Parse(endParts[0]);
            endY = int.Parse(endParts[1]);
        }

        if (!string.IsNullOrWhiteSpace(command))
        {
            action(command, startX, startY, endX, endY);
        }
    }
}