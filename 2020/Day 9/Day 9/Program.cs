using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var data = LoadData(filename).ToArray();
            var preambleLength = 25;
            int invalidIndex = 0;
            long invalidValue = 0;
            
            for (var i = preambleLength; i < data.Length; i++)
            {
                var value = data[i];
                var preamble = data.Skip(i - preambleLength).Take(preambleLength).ToArray();
                var isValid = IsValid(value, preamble);

                if (!isValid)
                {
                    //Console.WriteLine($"Value: {value}, Preamble: {String.Join(", ", preamble)}");
                    invalidIndex = i;
                    invalidValue = value;
                    break;
                }
            }
            
            Console.WriteLine($"Invalid value is {invalidValue}. Index: {invalidIndex}");

            for (var i = 0; i < invalidIndex; i++)
            {
                for (var j = i + 1; j < invalidIndex; j++)
                {
                    var skip = i;
                    var take = j - i;
                    var range = data.Skip(skip).Take(take);
                    var sum = range.Sum();
                    if (sum == invalidValue)
                    {
                        Console.WriteLine($"Eureka! {data[i]}, {data[j]}. The sum is {range.Min() + range.Max()}");
                    }
                }
            }
        }

        static bool IsValid(long value, long[] preamble)
        {
            for (var i = 0; i < preamble.Length; i++)
            {
                for (var j = i + 1; j < preamble.Length; j++)
                {
                    if (preamble[i] + preamble[j] == value)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        static List<long> LoadData(string filename)
        {
            var data = new List<long>();

            string line;

            using var reader = new StreamReader(filename);
            while ((line = reader.ReadLine()) != null)
            {
                if (!long.TryParse(line, out long value))
                {
                    throw new ArgumentException($"Value is not a valid long: {line}");
                }
                data.Add(value);
            }

            return data;
        }
    }
}
