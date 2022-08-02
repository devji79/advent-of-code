using System;

namespace AdventOfCodeDay4
{
  // ReSharper disable once ClassNeverInstantiated.Global
  internal class Program
  {
    public static void Main()
    {
      // ReSharper disable once StringLiteralTypo
      const string prefix = "yzbqklnj";
      ICoinMiner coinMiner = new CoinMiner();
      
      // Part 1
      Console.WriteLine("Part 1");
      var coin = coinMiner.MineCoin(prefix, "00000");
      Console.WriteLine($"Mined coin found: {prefix}{coin}");
      Console.WriteLine();
      
      // Part 2
      Console.WriteLine("Part 2");
      coin = coinMiner.MineCoin(prefix, "000000");
      Console.WriteLine($"Mined coin found: {prefix}{coin}");
    }
  }
}