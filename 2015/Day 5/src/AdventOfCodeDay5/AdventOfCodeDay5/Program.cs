using AdventOfCodeDay5;

var lines = File.ReadAllLines("input.txt");
IBehaviourAssessor assessor = new BehaviourAssessor();

// Part 1
Console.WriteLine("Part 1");
var niceCount = 0;
foreach (var line in lines)
{
    if (assessor.IsNice(line))
    {
        niceCount++;
    }
}
Console.WriteLine($"Number of 'nice' strings: {niceCount}");
Console.WriteLine();
      
// Part 2
Console.WriteLine("Part 2");
assessor = new BehaviourAssessorV2();
niceCount = 0;
foreach (var line in lines)
{
    if (assessor.IsNice(line))
    {
        niceCount++;
    }
}
Console.WriteLine($"Number of 'nice' strings: {niceCount}");