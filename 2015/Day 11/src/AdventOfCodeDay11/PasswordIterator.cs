using System.Text.RegularExpressions;

namespace AdventOfCodeDay11;

public class PasswordIterator : IPasswordIterator
{
    private readonly int _requiredPasswordLength;
    
    public PasswordIterator(int requiredPasswordLength)
    {
        _requiredPasswordLength = requiredPasswordLength;
    }
    
    public string Next(string current)
    {
        if (current.Length != _requiredPasswordLength || !Regex.IsMatch(current, "[a-z]{"+ _requiredPasswordLength + "}"))
        {
            throw new ArgumentException($"Invalid password: {current}");
        }

        // Convert to base-26
        var chars = new int[_requiredPasswordLength];
        for (var i = 0; i < current.Length; i++)
        {
            chars[i] = (int)current[i] - 96;
        }
        
        // Increment
        chars[_requiredPasswordLength - 1]++;
        
        // Carry
        for (var i = chars.Length - 1; i >= 0; i--)
        {
            if (chars[i] > 26)
            {
                if (i == 0)
                {
                    throw new IndexOutOfRangeException("Unable to increment password");
                }
                chars[i] = 1;
                chars[i - 1]++;
            }
        }
        
        // Convert to string
        string output = string.Empty;
        for (var i = 0; i < chars.Length; i++)
        {
            output += (char)(chars[i] + 96);
        }
        
        return output;
    }
}