using NUnit.Framework;

namespace AdventOfCodeDay3.Tests;

[TestFixture]
public class DeliveryCounterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("<<", 3)]
    [TestCase(">", 2)]
    [TestCase("^>v<", 4)]
    [TestCase("^v^v^v^v^v", 2)]
    public void CalculateDeliveredHouses(string input, int expectedResult)
    {
        // Arrange
        IDeliveryCounter counter = new DeliveryCounter();

        // Act
        var deliveredHouseCount = counter.CalculateDeliveredHouses(input);
        
        // Assert
        Assert.AreEqual(expectedResult, deliveredHouseCount);
    }
}