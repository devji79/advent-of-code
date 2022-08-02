namespace AdventOfCodeDay6;

public interface ILightGrid
{
    void Switch(string command, int startX, int startY, int endX, int endY);
    void Adjust(string command, int startX, int startY, int endX, int endY);
    int CountLit();
    int TotalBrightness();
}

public class LightGrid : ILightGrid
{
    private readonly int[,] _grid;
    
    public LightGrid(int size)
    {
        _grid = new int[size, size];
    }
    
    public void Switch(string command, int startX, int startY, int endX, int endY)
    {
        for(var i = startX; i <= endX; i++)
        {
            for (var j = startY; j <= endY; j++)
            {
                switch (command)
                {
                    case "turn on":
                        _grid[i, j] = 1;
                        break;
                    case "turn off":
                        _grid[i, j] = 0;
                        break;
                    case "toggle":
                        _grid[i, j] = _grid[i, j] == 0 ? 1 : 0; 
                        break;
                    default:
                        throw new Exception($"Unable to parse command: {command}");
                }
            }
        }
    }
    
    public void Adjust(string command, int startX, int startY, int endX, int endY)
    {
        for(var i = startX; i <= endX; i++)
        {
            for (var j = startY; j <= endY; j++)
            {
                switch (command)
                {
                    case "turn on":
                        _grid[i, j] += 1;
                        break;
                    case "turn off":
                        _grid[i, j] = Math.Max(0, _grid[i ,j] - 1);
                        break;
                    case "toggle":
                        _grid[i, j] += 2; 
                        break;
                    default:
                        throw new Exception($"Unable to parse command: {command}");
                }
            }
        }
    }

    public int CountLit()
    {
        var count = 0;
        for(var i = 0; i < _grid.GetLength(0); i++)
        {
            for (var j = 0; j < _grid.GetLength(1); j++)
            {
                if(_grid[i, j] == 1)
                {
                    count++;
                }
            }
        }
        
        return count;
    }
    
    public int TotalBrightness()
    {
        var totalBrightness = 0;
        for(var i = 0; i < _grid.GetLength(0); i++)
        {
            for (var j = 0; j < _grid.GetLength(1); j++)
            {
                totalBrightness += _grid[i, j];
            }
        }
        
        return totalBrightness;
    }
} 