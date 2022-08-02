using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "sample2.txt";
            
            var adapters = LoadData(filename).OrderBy(a => a).ToList();

            //var lastAdapter = 0;
            //Dictionary<int, int> joltDifferenceDictionary = new Dictionary<int, int>() {{ 3, 1 }};
            //foreach (var adapter in adapters)
            //{
            //    var diff = adapter - lastAdapter;
            //    if (joltDifferenceDictionary.ContainsKey(diff))
            //    {
            //        joltDifferenceDictionary[diff] = joltDifferenceDictionary[diff] + 1;
            //    }
            //    else
            //    {
            //        joltDifferenceDictionary[diff] = 1;
            //    }

            //    lastAdapter = adapter;
            //}
            //Console.WriteLine($"1 jolt diffs ({joltDifferenceDictionary[1]}) x 3 jolt diffs ({joltDifferenceDictionary[3]}) = {joltDifferenceDictionary[1] * joltDifferenceDictionary[3]}");

            var currentAdapter = 0;
            double adapterCombinations = 1;
            while (currentAdapter != adapters.Max())
            {
                Console.WriteLine($"Testing {currentAdapter}");
                var possibleAdapters = adapters.Where(a => a > currentAdapter && a <= currentAdapter + 3).ToList();
                
                //1 2^0 = 1
                //2 2^1 = 2
                //4 2^2 = 4
                Console.WriteLine($"Possible adapters [{string.Join(", ", possibleAdapters)}]");
                var combinations = Math.Pow(2, possibleAdapters.Count() - 1);
                Console.WriteLine($"Combinations is {combinations}");
                
                adapterCombinations *= combinations;
                Console.WriteLine($"Adapter combinations is {adapterCombinations}");

                currentAdapter = possibleAdapters.Max();
                //var combinations = sortedAdapters.Count(a => a > currentAdapter && a <= currentAdapter + 3);
                //    if (combinations > 0)
                //    {
                //        adapterCombinations *= CalculateFactorial(combinations);
                //    }

                //    currentAdapter = sortedAdapters.Where(a => a > currentAdapter && a <= currentAdapter + 3).Max();
            }
            Console.WriteLine($"Adapter combinations: {adapterCombinations}");
        }

        static List<int> LoadData(string filename)
        {
            var data = new List<int>();

            string line;
            using var reader = new StreamReader(filename);
            while ((line = reader.ReadLine()) != null)
            {
                if (int.TryParse(line, out int value))
                {
                    data.Add(value);
                }
                else
                {
                    throw new ArgumentException($"Cannot parse adapter value {line}");
                }
            }
            
            return data;
        }
    }
}
