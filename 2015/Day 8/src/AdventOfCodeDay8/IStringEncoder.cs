namespace AdventOfCodeDay8;

public interface IStringEncoder
{
    string Encode(string decoded);
    string Decode(string encoded);
}