using System.Text.RegularExpressions;

namespace AdventOfCodeDay8;

public class StringEncoder : IStringEncoder
{
    public string Encode(string decoded)
    {
        var encoded = decoded.Trim();
        
        // Escape backslashes
        encoded = encoded.Replace("\\", "\\\\");
        
        // Escaped double quotes
        encoded = encoded.Replace("\"", "\\\"");
        
        // Escape single quotes
        encoded = encoded.Replace("'", "\\x27");
        
        // Add double quotes to start and end
        encoded = "\"" + encoded + "\"";

        return encoded;
    }

    public string Decode(string encoded)
    {
        var decoded = encoded.Trim();
        
        // Remove first and last characters
        decoded = decoded.Remove(0,1);
        decoded = decoded.Remove(decoded.Length-1);
        
        // Replace escaped backslash
        decoded = decoded.Replace("\\\\", "\\");
        
        // Replace escaped double quote
        decoded = decoded.Replace("\\\"", "\"");
        
        // Replace hexidecimal notation
        decoded = Regex.Replace(decoded, "\\\\x[0-9A-Fa-f]{2}", "'");

        return decoded;
    }
}