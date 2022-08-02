

Console.WriteLine("Hello, World!");

string path = @"input.txt";
string[] lines = File.ReadAllLines(path);

int? previousDepth = null;
var increaseCount = 0;
var decreaseCount = 0;

// Part 1
for(var i = 0; i < lines.Length; i++)
{
    var depth = int.Parse(lines[i]);

    if(previousDepth != null && depth > previousDepth)
    {
        increaseCount++;
    }

    previousDepth = depth;
}
Console.WriteLine($"IncreaseCount: {increaseCount}");

// Part 2
previousDepth = null;
increaseCount = 0;

for(var i = 2; i < lines.Count(); i++)
{
    var depth1 = int.Parse(lines[i - 2]);
    var depth2 = int.Parse(lines[i - 1]);
    var depth3 = int.Parse(lines[i]);
    
    var currentDepth = depth1 + depth2 + depth3;

    if (previousDepth == null)
    {
        previousDepth = currentDepth;
    } else
    {
        if(currentDepth > previousDepth)
        {
            increaseCount++;
        } 
        else if (currentDepth < previousDepth)
        {
            decreaseCount++;
        }
        previousDepth = currentDepth;
    }
}
Console.WriteLine($"IncreaseCount: {increaseCount}, DecreaseCount: {decreaseCount}");