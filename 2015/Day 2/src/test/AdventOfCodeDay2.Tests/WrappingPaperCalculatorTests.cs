using NUnit.Framework;

namespace AdventOfCodeDay2.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1,1,1, 7)]
    [TestCase(2,3,4, 58)]
    [TestCase(1,1,10, 43)]
    public void CalculateWrappingPaperRequired(int length, int width, int height, int expectedResult)
    {
        // Arrange
        IPresentCalculator calculator = new PresentCalculator();

        // Act
        var wrappingPaperRequired = calculator.CalculateWrappingPaperRequired(length, width, height);

        // Assert
        Assert.AreEqual(expectedResult, wrappingPaperRequired);
    }
    
    [Test]
    [TestCase(1,1,1, 5)]
    [TestCase(2,3,4, 34)]
    [TestCase(1,1,10, 14)]
    public void CalculateRibbonRequired(int length, int width, int height, int expectedResult)
    {
        // Arrange
        IPresentCalculator calculator = new PresentCalculator();

        // Act
        var ribbonRequired = calculator.CalculateRibbonRequired(length, width, height);

        // Assert
        Assert.AreEqual(expectedResult, ribbonRequired);
    }
}