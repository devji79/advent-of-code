using System;
using System.IO;

namespace AdventOfCodeDay2
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      IPresentCalculator calculator = new PresentCalculator();
                  
      var input = File.ReadAllLines("input.txt");

      // Part 1
      Console.WriteLine($"Part 1");
      var totalWrappingPaperRequired = 0;
      foreach (var line in input)
      {
        var parts = line.Split('x');
        var length = int.Parse(parts[0]);
        var width = int.Parse(parts[1]);
        var height = int.Parse(parts[2]);

        var wrappingPaperRequired = calculator.CalculateWrappingPaperRequired(length, width, height);
        totalWrappingPaperRequired += wrappingPaperRequired;
      }
      Console.WriteLine($"Total wrapping paper required is: {totalWrappingPaperRequired}");
      Console.WriteLine();
      
      // Part 2
      Console.WriteLine($"Part 2");
      var totalRibbonRequired = 0;
      foreach (var line in input)
      {
        var parts = line.Split('x');
        var length = int.Parse(parts[0]);
        var width = int.Parse(parts[1]);
        var height = int.Parse(parts[2]);

        var ribbonRequired = calculator.CalculateRibbonRequired(length, width, height);
        totalRibbonRequired += ribbonRequired;
      }
      Console.WriteLine($"Total ribbon required: {totalRibbonRequired}");
    }
  }
}