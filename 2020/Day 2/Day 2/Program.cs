using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            var data = LoadData(filename);

            var validPasswordCount = 0;
            foreach (var passwordToCheck in data)
            {
                if (passwordToCheck.IsFrequencyValid())
                {
                    validPasswordCount++;
                }
                var passwordValidityString = passwordToCheck.IsFrequencyValid() ? "VALID" : "INVALID";
                Console.WriteLine($"Checking {passwordToCheck.password} : {passwordValidityString} - {passwordToCheck.originalData}");
            }

            Console.WriteLine($"Valid passwords: {validPasswordCount}");
        }

        static List<PasswordDebugItem> LoadData(string filename)
        {
            List<PasswordDebugItem> data = new List<PasswordDebugItem>();

            string line;
            var file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                var items = line.Trim().Split(" ");
                if (items.Length != 3)
                {
                    throw new Exception($"Cannot parse line: {line}");
                }

                var frequencyString = items[0].Split("-");
                if (frequencyString.Length != 2)
                {
                    throw new Exception($"Cannot parse range: {items[0]}");
                }

                var minFrequency = int.Parse(frequencyString[0]);
                var maxFrequency = int.Parse(frequencyString[1]);

                var policyCharString = items[1].Trim().Replace(":", "");
                if (policyCharString.Length != 1)
                {
                    throw new Exception($"Cannot parse policyChar: {items[1]}");
                }

                char policyChar = policyCharString.ToCharArray().Single();

                var password = items[2].Trim();

                var passwordDebugItem = new PasswordDebugItem()
                {
                    originalData = line,
                    password = password,
                    passwordPolicies = new List<PasswordPolicy>()
                    {
                        new PasswordPolicy()
                        {
                            Letter = policyChar,
                            Min = minFrequency,
                            Max = maxFrequency
                        }
                    }
                };

                data.Add(passwordDebugItem);
            }

            return data;
        }
    }
}
