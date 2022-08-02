using AdventOfCodeDay7;

var lines = File.ReadAllLines("input.txt");

// Part 1
Console.WriteLine("Part 1");
IWireSignalEvaluator evaluator = new WireSignalEvaluator(lines);
var wireASignal = evaluator.GetSignal("a");
Console.WriteLine($"Signal on wire 'a': {wireASignal}");
Console.WriteLine();

// Part 2
Console.WriteLine("Part 2");
evaluator = new WireSignalEvaluator(lines);
evaluator.OverrideValue("b", wireASignal);
wireASignal = evaluator.GetSignal("a");
Console.WriteLine($"Signal on wire 'a': {wireASignal}");