namespace AdventOfCodeDay7;

public interface IWireSignalEvaluator
{
    int GetSignal(string w);
    void OverrideValue(string w, int value);
}