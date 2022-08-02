using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var rules = LoadRules(filename);
            var targetColour = "shiny gold";
            
            var bagCarryColours = GetBagCarryColours(targetColour, rules);
            Console.WriteLine($"There are {bagCarryColours.Count} colours of bag that will carry {targetColour}");

            var totalBagsRequired = GetBagCount(targetColour, rules);
            Console.WriteLine($"A {targetColour} bag must contain {totalBagsRequired} other bags");
        }

        static int GetBagCount(string colour, IList<BaggageRule> rules)
        {
            var bagCount = 0;

            var matchingRule = rules.FirstOrDefault(r => r.Colour == colour);
            if (matchingRule != null)
            {
                foreach (var permittedContent in matchingRule.PermittedContent)
                {
                    bagCount += permittedContent.Value;
                    bagCount += permittedContent.Value * GetBagCount(permittedContent.Key, rules);
                }
            }

            return bagCount;
        }

        static IList<string> GetBagCarryColours(string colour, IList<BaggageRule> rules)
        {
            var carriers = new List<string>();

            var matchingRules = rules.Where(r => r.PermittedContent.ContainsKey(colour));
            foreach (var matchingRule in matchingRules)
            {
                carriers.Add(matchingRule.Colour);
                carriers.AddRange(GetBagCarryColours(matchingRule.Colour, rules));
            }

            return carriers.Distinct().ToList();
        }

        static IList<BaggageRule> LoadRules(string filename)
        {
            var baggageRules = new List<BaggageRule>();

            string line;
            using var reader = new StreamReader(filename);
            while ((line = reader.ReadLine()) != null)
            {
                var parsedline = line.Replace(".", "").Replace("bags", "").Replace("bag", "");
                var parts = parsedline.Split(" contain ", StringSplitOptions.RemoveEmptyEntries);
                var bagColour = parts[0].Trim().ToLower();

                var baggageRule = new BaggageRule()
                {
                    Colour = bagColour,
                };

                if (parts[1].Trim() != "no other")
                {
                    foreach (var bagStr in parts[1].Trim().ToLower().Split(", ", StringSplitOptions.RemoveEmptyEntries))
                    {
                        var bagStrParts = bagStr.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToArray();
                        var qty = int.Parse(bagStrParts[0]);
                        var name = string.Join(" ", bagStrParts.Skip(1));
                        //Console.WriteLine($"{baggageRule.Colour} adding ({name} {qty})");
                        baggageRule.PermittedContent.Add(name, qty);
                    }
                }

                baggageRules.Add(baggageRule);
            }

            return baggageRules;
        }
    }
}
