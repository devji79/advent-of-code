namespace AdventOfCodeDay7;

public class WireSignalEvaluator : IWireSignalEvaluator
{
    private readonly IDictionary<string, string> _wireOperations;
    private readonly IDictionary<string, int> _cache;

    public WireSignalEvaluator(string[] lines)
    {
        _wireOperations = new Dictionary<string, string>();
        _cache = new Dictionary<string, int>();
        
        foreach (var line in lines)
        {
            var parts = line.Split(" -> ");
            _wireOperations[parts[1]] = parts[0];
        }
    }
    
    public int GetSignal(string w)
    {
        if (_cache.ContainsKey(w))
        {
            return _cache[w];
        }
        
        if (int.TryParse(w, out var value))
        {
            _cache[w] = value;
            return value;
        }
        
        if (!_wireOperations.ContainsKey(w))
        {
            throw new Exception($"Unable to find configurations for wire '{w}'.");
        }

        var operation = _wireOperations[w];
        //Console.WriteLine($"{w}: {operation}");
        
        if (operation.Contains("LSHIFT"))
        {
            var parts = operation.Split(' ');
            var input = GetSignal(parts[0]);
            var shift = int.Parse(parts[2]);
            var result = input << shift;
            _cache[w] = result;
            return result;

        }
        else if (operation.Contains("RSHIFT"))
        {
            var parts = operation.Split(' ');
            var input = GetSignal(parts[0]);
            var shift = int.Parse(parts[2]);
            var result = input >> shift;
            _cache[w] = result;
            return result;
        }
        else if (operation.Contains("AND"))
        {
            var parts = operation.Split(' ');
            var input1 = GetSignal(parts[0]);
            var input2 = GetSignal(parts[2]);
            var result = input1 & input2;
            _cache[w] = result;
            return result;
        }
        else if (operation.Contains("OR"))
        {
            var parts = operation.Split(' ');
            var input1 = GetSignal(parts[0]);
            var input2 = GetSignal(parts[2]);
            var result = input1 | input2;
            _cache[w] = result;
            return result;
        }
        else if (operation.Contains("NOT"))
        {
            var parts = operation.Split(' ');
            var input = GetSignal(parts[1]);
            var result = ~input;
            _cache[w] = result;
            return result;
        }
        else if(!operation.Contains(' '))
        {
            var result = GetSignal(operation);
            _cache[w] = result;
            return result;
        }
        
        throw new Exception($"Unknown operation: {operation}");
    }

    public void OverrideValue(string w, int value)
    {
        _cache[w] = value;
    }
}