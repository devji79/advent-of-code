using System;
using System.IO;

namespace AdventOfCodeDay1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IFloorCalculator calculator = new FloorCalculator();
            
            var input = File.ReadAllText("input.txt");

            // Part 1
            Console.WriteLine($"Part 1");
            var floor = calculator.CalculateFinalFloor(input);
            Console.WriteLine($"Final floor is: {floor}");
            Console.WriteLine();
            
            // Part 2
            Console.WriteLine($"Part 2");
            var basementPosition = calculator.CalculateBasementPosition(input);
            Console.WriteLine($"Position where basement entered: {basementPosition}");
            Console.WriteLine();
        }
    }
}