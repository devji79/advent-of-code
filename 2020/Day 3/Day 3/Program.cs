using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            
            var data = LoadData(filename);
            //DisplayData(data);

            var testCases = new int[5,2]
            {
                { 1, 1 }, 
                { 3, 1 }, 
                { 5, 1 }, 
                { 7, 1 }, 
                { 1, 2 }
            };

            long product = 1;
            for (var i = 0; i < testCases.GetLength(0); i++)
            {
                product *= CalculateTreesEncountered(testCases[i, 0], testCases[i, 1], data);
            }

            Console.WriteLine($"Product is {product}");
        }

        static int CalculateTreesEncountered(int rightValue, int downValue, char[,] data)
        {
            var treeCount = 0;
            var currentRight = 0;
            var currentDown = 0;
            var targetDown = data.GetLength(0);
            var mapWidth = data.GetLength(1);

            while (currentDown + downValue < targetDown)
            {
                currentRight += rightValue;
                currentDown += downValue;

                var nextPosition = data[currentDown, currentRight % mapWidth];
                //Console.WriteLine($"Next position [{currentDown},{currentRight}] = {currentRight % mapWidth} = {nextPosition}");
                if (nextPosition == '#')
                {
                    treeCount++;
                }
            }

            Console.WriteLine($"Tree count for {rightValue}, {downValue} is {treeCount}");
            return treeCount;
        }

        static void DisplayData(char[,] data)
        {
            for (var r = 0; r < data.GetLength(0); r++)
            {
                for (var c = 0; c < data.GetLength(1); c++)
                {
                    Console.Write(data[r, c]);
                }
                Console.WriteLine();
            }
        }

        static char[,] LoadData(string filename)
        {
            var lines = new List<string>();
            
            string line;
            using var reader = new StreamReader(filename);
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            var rows = lines.Count;
            var columns = lines.First().Length;

            var data = new char[rows, columns];
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    data[r, c] = lines[r].ToCharArray()[c];
                }
            }

            return data;
        }
    }
}
