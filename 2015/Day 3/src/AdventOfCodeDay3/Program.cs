using System;
using System.IO;

namespace AdventOfCodeDay3
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var input = File.ReadAllText("input.txt");
      IDeliveryCounter counter = new DeliveryCounter();
      
      // Part 1
      Console.WriteLine($"Part 1");
      var totalDeliveredHouses = counter.CalculateDeliveredHouses(input);
      Console.WriteLine($"Total delivered houses is: {totalDeliveredHouses}");
      Console.WriteLine();
      
      // Part 2
      Console.WriteLine($"Part 2");
      totalDeliveredHouses = counter.CalculateDeliveredHouses(input, 2);
      Console.WriteLine($"Total delivered houses is: {totalDeliveredHouses}");
    }
  }
}