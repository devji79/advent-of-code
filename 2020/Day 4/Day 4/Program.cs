using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            string[] requiredPassportFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            var passports = GetPassportData(filename);

            var validPassportCount = passports.Count(p => PassportIsValid(p, requiredPassportFields));
            Console.WriteLine($"Number of valid passports: {validPassportCount}");
        }

        static bool PassportIsValid(Dictionary<string, string> passport, string[] requiredFields)
        {
            var passportFields = passport.Keys.Select(s => s);
            var allPassportFields = requiredFields.All(rf => passportFields.Contains(rf));
            if (!allPassportFields) return false;
            
            var byr = passport["byr"];
            if (byr.Length != 4) return false;
            int byrInt = int.Parse(byr);
            if (byrInt < 1920 || byrInt > 2002) return false;

            var iyr = passport["iyr"];
            if (iyr.Length != 4) return false;
            int iyrInt = int.Parse(iyr);
            if (iyrInt < 2010 || iyrInt > 2020) return false;

            var eyr = passport["eyr"];
            if (eyr.Length != 4) return false;
            int eyrInt = int.Parse(eyr);
            if (eyrInt < 2020 || eyrInt > 2030) return false;

            var hgt = passport["hgt"];
            if (!hgt.EndsWith("cm") && !hgt.EndsWith("in")) return false;
            var hgtInt = int.Parse(hgt.Replace("cm", "").Replace("in", ""));
            if (hgt.EndsWith("cm") && (hgtInt < 150 || hgtInt > 193)) return false;
            if (hgt.EndsWith("in") && (hgtInt < 59 || hgtInt > 76)) return false;

            var hcl = passport["hcl"];
            if (!Regex.IsMatch(hcl, "^#[a-f0-9]{6}$")) return false;

            var ecl = passport["ecl"];
            var validEyeColors = new string[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            if (!validEyeColors.Contains(ecl)) return false;

            var pid = passport["pid"];
            if (!Regex.IsMatch(pid, "^[0-9]{9}$")) return false;

            return true;
        }

        static IList<Dictionary<string, string>> GetPassportData(string filename)
        {
            IList<Dictionary<string,string>> passportData = new List<Dictionary<string, string>>();

            string line;
            using var reader = new StreamReader(filename);

            Dictionary<string, string> passport = new Dictionary<string, string>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line == string.Empty && passport.Count > 0)
                {
                    passportData.Add(passport);
                    passport = new Dictionary<string, string>();
                }
                else
                {
                    var fields = line.Split(" ");
                    foreach (var field in fields)
                    {
                        var fieldParts = field.Trim().Split(":");
                        passport.Add(fieldParts[0].Trim(), fieldParts[1].Trim());
                    }
                }
            }

            if (passport.Count > 0)
            {
                passportData.Add(passport);
            }

            return passportData;
        }
    }
}
