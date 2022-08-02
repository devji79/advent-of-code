using NUnit.Framework;

namespace AdventOfCodeDay4.Tests;

[TestFixture]
public class CoinMinerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    // ReSharper disable once StringLiteralTypo
    [TestCase("abcdef", 609043)]
    // ReSharper disable once StringLiteralTypo
    [TestCase("pqrstuv", 1048970)]
    public void MineCoin(string prefix, int expectedResult)
    {
        // Arrange
        ICoinMiner coinMiner = new CoinMiner();

        // Act
        var coin = coinMiner.MineCoin(prefix, "00000");
        
        // Assert
        Assert.AreEqual(expectedResult, coin);
    }
}