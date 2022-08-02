using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var data = LoadData(filename);
            var maxSeatId = data.Max(s => s.SeatId);
            Console.WriteLine($"The maximum seat ID is {maxSeatId}");

            var takenSeatIds = data.Select(s => s.SeatId).ToList();
            for (var i = 0; i < 976; i++)
            {
                if (!takenSeatIds.Contains(i))
                {
                    Console.WriteLine($"SeatID {i} has not been checked in");
                }
            }
        }

        static IList<Seat> LoadData(string filename)
        {
            var seats = new List<Seat>();

            string line;

            using var reader = new StreamReader(filename);
            while ((line = reader.ReadLine()) != null)
            {
                var seat = new Seat();
                seat.Row = BinarySearch(line.Substring(0, 7), 0, 127, 'F', 'B');
                seat.Column = BinarySearch(line.Substring(7, 3), 0, 7, 'L', 'R');
                seats.Add(seat);
            }

            return seats;
        }

        static int BinarySearch(string str, int lowerBound, int upperBound, char lowerChar, char upperChar)
        {
            var chars = str.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                var midPoint = lowerBound + (int) ((upperBound - lowerBound) / 2);
                if (chars[i] == lowerChar) upperBound = midPoint;
                if (chars[i] == upperChar) lowerBound = midPoint + 1;
            }

            if (upperBound == lowerBound) return upperBound;

            throw new Exception("Cannot narrow search");
        }
    }
}
