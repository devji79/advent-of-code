namespace AdventOfCodeDay11;

public class PasswordGenerator : IPasswordGenerator
{
    private readonly IPasswordIterator _iterator;
    
    public PasswordGenerator()
    {
        _iterator = new PasswordIterator(8);
    }
    
    public string GetNextPassword(string current)
    {
        var password = current;
        do
        {
            password = _iterator.Next(password);
        } 
        while (!IsPasswordValid(password));

        return password;
    }

    public bool IsPasswordValid(string password)
    {
        var minimumConsecutiveLetters = 3;
        var invalidChars = new[] { 'i', 'o', 'l' };
        var minimumLetterPairs = 2;
        
        return !ContainsInvalidCharacters(password, invalidChars)
            && HasConsecutiveLetters(password, minimumConsecutiveLetters) 
            && ContainsLetterPairs(password, minimumLetterPairs);
    }

    private bool HasConsecutiveLetters(string password, int minimumRequired)
    {
        if (string.IsNullOrEmpty(password))
            return false;
        
        var lastCharacter = password[0];
        var count = 1;
        
        for (var i = 1; i < password.Length; i++)
        {
            if ((int)password[i] == (int)(lastCharacter + 1))
            {
                count++;
                if (count >= minimumRequired)
                {
                    return true;
                }
            }
            else
            {
                count = 1;
            }
            
            lastCharacter = password[i];
        }

        return false;
    }

    private bool ContainsInvalidCharacters(string password, char[] invalidChars)
    {
        return invalidChars.Any(c => password.Contains(c));
    }

    private bool ContainsLetterPairs(string password, int minimumRequired)
    {
        var pairsFound = 0;
        
        for (var i = 1; i < password.Length; i++)
        {
            if (password[i] == password[i - 1])
            {
                if (i > 1)
                {
                    if (password[i] != password[i - 2])
                    {
                        pairsFound++;
                    }
                }
                else
                {
                    pairsFound++;
                }
            }
        }

        return pairsFound >= minimumRequired;
    }
}