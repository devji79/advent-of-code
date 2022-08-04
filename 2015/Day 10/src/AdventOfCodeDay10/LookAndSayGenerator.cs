namespace AdventOfCodeDay10;

public class LookAndSayGenerator : ILookAndSayGenerator
{
    public string Generate(string sequence)
    {
        if (string.IsNullOrEmpty(sequence))
        {
            return string.Empty;
        }
        
        var output = string.Empty;
        
        char previousChar = sequence[0];
        int count = 0;
        for (var i = 0; i < sequence.Length; i++)
        {
            var currentChar = sequence[i];
            if (currentChar == previousChar)
            {
                count++;
            }
            else
            {
                output += count + "" + previousChar;
                previousChar = currentChar;
                count = 1;
            }
        }
        
        output += count + "" + previousChar;

        return output;
    }
}