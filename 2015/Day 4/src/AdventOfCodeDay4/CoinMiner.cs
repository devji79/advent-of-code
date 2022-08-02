using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCodeDay4
{
    public interface ICoinMiner
    {
        int MineCoin(string prefix, string hashPrefix, int maxAttempts = 10000000);
    }
    
    public class CoinMiner : ICoinMiner
    {
        public int MineCoin(string prefix, string hashPrefix, int maxAttempts = 10000000)
        {
            for (var ctr = 1; ctr < maxAttempts; ctr++)
            {
                var hash = GenerateMD5(prefix + ctr);
                if (hash.StartsWith(hashPrefix))
                {
                    return ctr;
                }
            }

            throw new Exception($"Unable to mine coin. No valid coins found within the first {maxAttempts} attempts.");
        }

        // ReSharper disable once InconsistentNaming
        private static string GenerateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}