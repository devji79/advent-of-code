using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var groups = LoadData(filename);
            for (var i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"Group {i} has {groups[i].DistinctResponses} distinct responses");
            }

            var uniqueSum = groups.Sum(g => g.DistinctResponses);
            Console.WriteLine($"The sum of all unique answers is {uniqueSum}");

            var commonSum = groups.Sum(g => g.CommonResponses);
            Console.WriteLine($"The sum of all common answers is {commonSum}");
        }

        static IList<Group> LoadData(string filename)
        {
            var groups = new List<Group>();

            string line;
            using var reader = new StreamReader(filename);
            var group = new Group();

            while ((line = reader.ReadLine()) != null)
            {
                if (line == string.Empty)
                {
                    groups.Add(group);
                    group = new Group();
                }
                else
                {
                    group.Responses.Add(line.ToCharArray());
                }
            }

            groups.Add(group);

            return groups;
        }
    }
}
