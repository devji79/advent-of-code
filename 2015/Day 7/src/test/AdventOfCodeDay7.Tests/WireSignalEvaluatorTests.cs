using Xunit;

namespace AdventOfCodeDay7.Tests;

public class WireSignalEvaluatorTests
{
    [Theory]
    [InlineData("0 AND 1 -> test", 0)]
    [InlineData("1 AND 2 -> test", 0)]
    [InlineData("1 AND 3 -> test", 1)]
    public void And(string operation, int expectedResult)
    {
        // Arrange
        var lines = new[] { operation };
        IWireSignalEvaluator evaluator = new WireSignalEvaluator(lines);
        
        // Act
        var result = evaluator.GetSignal("test");
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("0 OR 1 -> test", 1)]
    [InlineData("1 OR 2 -> test", 3)]
    [InlineData("1 OR 3 -> test", 3)]
    public void Or(string operation, int expectedResult)
    {
        // Arrange
        var lines = new[] { operation };
        IWireSignalEvaluator evaluator = new WireSignalEvaluator(lines);
        
        // Act
        var result = evaluator.GetSignal("test");
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("1 LSHIFT 1 -> test", 2)]
    [InlineData("1 LSHIFT 2 -> test", 4)]
    [InlineData("1 LSHIFT 3 -> test", 8)]
    public void LShift(string operation, int expectedResult)
    {
        // Arrange
        var lines = new[] { operation };
        IWireSignalEvaluator evaluator = new WireSignalEvaluator(lines);
        
        // Act
        var result = evaluator.GetSignal("test");
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("32 RSHIFT 1 -> test", 16)]
    [InlineData("32 RSHIFT 2 -> test", 8)]
    [InlineData("32 RSHIFT 3 -> test", 4)]
    public void LRhift(string operation, int expectedResult)
    {
        // Arrange
        var lines = new[] { operation };
        IWireSignalEvaluator evaluator = new WireSignalEvaluator(lines);
        
        // Act
        var result = evaluator.GetSignal("test");
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("NOT 1 -> test", -2)]
    [InlineData("NOT 2 -> test", -3)]
    [InlineData("NOT 3 -> test", -4)]
    public void Not(string operation, int expectedResult)
    {
        // Arrange
        var lines = new[] { operation };
        IWireSignalEvaluator evaluator = new WireSignalEvaluator(lines);
        
        // Act
        var result = evaluator.GetSignal("test");
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}