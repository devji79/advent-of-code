using NUnit.Framework;

namespace AdventOfCodeDay1.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("((", 2)]
    [TestCase("()(", 1)]
    [TestCase("()())", -1)]
    [TestCase("))", -2)]
    [TestCase("(())", 0)]
    [TestCase("", 0)]
    [TestCase("abc", 0)]
    public void CalculateFinalFloor(string input, int expectedResult)
    {
        // Arrange
        IFloorCalculator calculator = new FloorCalculator();
        
        // Act
        var floor = calculator.CalculateFinalFloor(input);
        
        // Assert
        Assert.AreEqual(expectedResult, floor);
    }
    
    [Test]
    [TestCase("(()))", 5)]
    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    [TestCase("))", 1)]
    [TestCase("(())", 0)]
    [TestCase("", 0)]
    [TestCase("abc", 0)]
    public void CalculateBasementPosition(string input, int expectedResult)
    {
        // Arrange
        IFloorCalculator calculator = new FloorCalculator();
        
        // Act
        var basementPosition = calculator.CalculateBasementPosition(input);
        
        // Assert
        Assert.AreEqual(expectedResult, basementPosition);
    }
}