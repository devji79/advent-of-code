using NUnit.Framework;

namespace AdventOfCodeDay6.Tests;

public class LightGridTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("turn on", 0, 0, 9, 9, 100)]
    public void Switch(string command, int startX, int startY, int endX, int endY, int expectedResult)
    {
        // Arrange
        ILightGrid lightGrid = new LightGrid(10);
        lightGrid.Switch(command, startX, startY, endX, endY);
        
        // Act
        var result = lightGrid.CountLit();
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    [TestCase("turn on", 0, 0, 9, 9, 100)]
    [TestCase("toggle", 0, 0, 9, 9, 200)]
    public void Adjust(string command, int startX, int startY, int endX, int endY, int expectedResult)
    {
        // Arrange
        ILightGrid lightGrid = new LightGrid(10);
        lightGrid.Adjust(command, startX, startY, endX, endY);
        
        // Act
        var result = lightGrid.TotalBrightness();
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}