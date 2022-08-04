using Xunit;

namespace AdventOfCodeDay10.Tests;

public class LookAndSayGeneratorTests
{
    [Theory]
    [InlineData("1", "11")]
    [InlineData("11", "21")]
    [InlineData("21", "1211")]
    [InlineData("1211", "111221")]
    [InlineData("111221", "312211")]
    public void Generate(string input, string expectedResult)
    {
        // Arrange
        ILookAndSayGenerator generator = new LookAndSayGenerator();
        
        // Act
        var result = generator.Generate(input);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}