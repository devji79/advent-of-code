using NUnit.Framework;

namespace AdventOfCodeDay3.Tests;

public class DeliveryCacheTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddToCache()
    {
        // Arrange
        IDeliveryCache cache = new DeliveryCache();

        // Act
        var gridReference = new GridReference(0, 0);
        cache.AddOrIncrement(gridReference);
        var count = cache.GetValue(gridReference);

        // Assert
        Assert.AreEqual(1, count);
    }
    
    [Test]
    public void GetTotalEntries()
    {
        // Arrange
        IDeliveryCache cache = new DeliveryCache();

        // Act
        var gridReference = new GridReference(0, 0);
        cache.AddOrIncrement(gridReference);
        gridReference = new GridReference(0, 1);
        cache.AddOrIncrement(gridReference);
        gridReference = new GridReference(1, 0);
        cache.AddOrIncrement(gridReference);
        
        var count = cache.GetTotalEntries();

        // Assert
        Assert.AreEqual(3, count);
    }
}