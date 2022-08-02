namespace AdventOfCodeDay5;

public interface IBehaviourAssessor
{
    bool IsNice(string input);
}

public class BehaviourAssessor : IBehaviourAssessor
{
    private readonly char[] _vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
    private readonly string[] _invalidStrings = new[] { "ab", "cd", "pq", "xy" };
    
    public bool IsNice(string input)
    {
        return CountVowels(input) >= 3
               && ContainsDoubleLetter(input)
               && !ContainsInvalidString(input);
    }

    public int CountVowels(string input)
    {
        return input
            .ToCharArray()
            .Count(c => _vowels.Contains(c));
    }

    public bool ContainsDoubleLetter(string input)
    {
        return input
            .ToCharArray()
            .Zip(Enumerable.Range(0, input.Length), Tuple.Create)
            .Any(x => x.Item2 > 0 && x.Item1 == input[x.Item2-1]);
    }

    public bool ContainsInvalidString(string input)
    {
        return _invalidStrings
            .Any(input.Contains);
    }
}

public class BehaviourAssessorV2 : IBehaviourAssessor
{
    public bool IsNice(string input)
    {
        return DistinctLetterPairFound(input) && RepeatedLetter(input, 1);
    }

    public bool DistinctLetterPairFound(string input)
    {
        for (var i = 0; i < input.Length - 1; i++)
        {
            var letterPair = input.Substring(i, 2);
            for (var j = i + 1; j < input.Length - 1; j++)
            {
                var nextLetterPair = input.Substring(j, 2);
                if (letterPair == nextLetterPair && j != i + 1)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool RepeatedLetter(string input, int spaceBetweenLetters)
    {
        for (var i = 0; i < input.Length - (spaceBetweenLetters + 1); i++)
        {
            var letter = input[i];
            var nextLetter = input[i + spaceBetweenLetters + 1];
            if (letter == nextLetter)
            {
                return true;
            }
        }

        return false;
    }
}