using AdventOfCodeDay8;

IStringEncoder encoder = new StringEncoder();

Console.WriteLine("Part 1");
var lines = File.ReadLines("input.txt").ToList();

var memoryTotal = 0;
var literalTotal = 0;

foreach (var line in lines)
{
    var decoded = encoder.Decode(line); 
    memoryTotal += line.Length;
    literalTotal += decoded.Length;
}

Console.WriteLine($"Difference between memory and literal is: {memoryTotal - literalTotal}");
Console.WriteLine();

Console.WriteLine("Part 2");
literalTotal = 0;
memoryTotal = 0;

foreach (var line in lines)
{
    var encoded = encoder.Encode(line); 
    memoryTotal += encoded.Length;
    literalTotal += line.Length;
}
Console.WriteLine($"Difference between memory and literal is: {memoryTotal - literalTotal}");