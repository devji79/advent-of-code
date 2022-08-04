using AdventOfCodeDay10;

ILookAndSayGenerator generator = new LookAndSayGenerator();

Console.WriteLine("Part 1");
var input = "1113222113";
for (var i = 0; i < 40; i++)
{
    input = generator.Generate(input);
}
Console.WriteLine($"Final sequence length is: {input.Length}");

Console.WriteLine("Part 2");
input = "1113222113";
for (var i = 0; i < 50; i++)
{
    input = generator.Generate(input);
}
Console.WriteLine($"Final sequence length is: {input.Length}");