using Xunit;

namespace AdventOfCodeDay8.Tests;

public class StringLiteralHelperTests
{
    [Theory]
    [InlineData("\"\\\\\"", "\\")]
    [InlineData("\"\"", "")]
    [InlineData("\"abc\"", "abc")]
    [InlineData("\"aaa\\\"aaa\"", "aaa\"aaa")]
    [InlineData("\"\\x27\"", "'")]
    public void Decode(string str, string expectedResult)
    {
        // Arrange
        IStringEncoder encoder = new StringEncoder();
        
        // Act
        var result = encoder.Decode(str);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("\\", "\"\\\\\"")]
    [InlineData("", "\"\"")]
    [InlineData("abc", "\"abc\"")]
    [InlineData("aaa\"aaa", "\"aaa\\\"aaa\"")]
    [InlineData("'", "\"\\x27\"")]
    public void Encode(string str, string expectedResult)
    {
        // Arrange
        IStringEncoder encoder = new StringEncoder();
        
        // Act
        var result = encoder.Encode(str);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}