var depth = 0;
var horizontalPostion = 0;
var aim = 0;

string path = @"input.txt";
string[] lines = File.ReadAllLines(path);

foreach (string line in lines)
{
    var parts = line.Trim().Split(' ');
    if(parts.Length != 2)
    {
        Console.WriteLine($"ERROR: Cannot parse {line}");
        return;
    }

    var command = parts[0];
    int amount;
    if(!int.TryParse(parts[1], out amount)) {
        Console.WriteLine($"ERROR: Cannot parse {line}");
    };

    if(command == "forward")
    {
        horizontalPostion += amount;
        depth += (aim * amount);
    }

    else if(command == "down")
    {
        //depth += amount;
        aim += amount;
    }

    else if(command == "up")
    {
        //depth -= amount;
        aim -= amount;
    }
}

Console.WriteLine($"horizontal: {horizontalPostion}; depth: {depth}");
Console.WriteLine($"horizontal x depth = {horizontalPostion * depth}");