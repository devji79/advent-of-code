using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilename = "input.txt";
            int targetSum = 2020;

            var data = LoadData(inputFilename);
            Console.WriteLine($"{data.Length} items loaded");

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = i + 1; j < data.Length; j++)
                {
                    if (data[i] + data[j] == targetSum)
                    {
                        Console.WriteLine($"{data[i]} and {data[j]} add up to {targetSum}. Product is {data[i] * data[j]}");
                    }
                }
            }

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = i + 1; j < data.Length; j++)
                {
                    for (var k = j + 1; k < data.Length; k++)
                    {
                        if (data[i] + data[j] + data[k] == targetSum)
                        {
                            Console.WriteLine(
                                $"{data[i]}, {data[j]} and {data[k]} add up to {targetSum}. Product is {data[i] * data[j] * data[k]}");
                        }
                    }
                }
            }
        }

        static int[] LoadData(string inputFilename)
        {
            var data = new List<int>();

            string line;
            var file = new StreamReader(inputFilename);
            while ((line = file.ReadLine()) != null)
            {
                if (int.TryParse(line, out var num))
                {
                    data.Add(num);
                }
            }

            return data.ToArray();
        }
    }
}
