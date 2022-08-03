namespace AdventOfCodeDay9;

public interface IRouteFinder
{
    void FindLocationN(int index = 0);
    int GetMinimumDistance();
    int GetMaximumDistance();
}