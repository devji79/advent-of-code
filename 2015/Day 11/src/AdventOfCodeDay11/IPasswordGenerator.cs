namespace AdventOfCodeDay11;

public interface IPasswordGenerator
{
    string GetNextPassword(string current);
    bool IsPasswordValid(string password);
}