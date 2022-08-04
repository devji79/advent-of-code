using System;
using Xunit;

namespace AdventOfCodeDay11.Tests;

public class PasswordIteratorTests
{
    [Theory]
    [InlineData("a")]
    [InlineData("abbbcbbbb")]
    [InlineData("12312")]
    public void InputValidation(string input)
    {
        // Arrange
        IPasswordIterator iterator = new PasswordIterator(8);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => iterator.Next(input));
    }
    
    [Theory]
    [InlineData("zzzzzzzz")]
    public void Next_OutOfRange(string input)
    {
        // Arrange
        IPasswordIterator iterator = new PasswordIterator(8);
        
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => iterator.Next(input));
    }
    
    
    [Theory]
    [InlineData("aaaaaaaa", "aaaaaaab")]
    [InlineData("aaaaaaaz", "aaaaaaba")]
    [InlineData("aaaagzzz", "aaaahaaa")]
    [InlineData("eeeeeeee", "eeeeeeef")]
    public void Next(string input, string expectedResult)
    {
        // Arrange
        IPasswordIterator iterator = new PasswordIterator(8);
        
        // Act
        var result = iterator.Next(input);
            
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("abcdefgh", "abcdffaa")]
    [InlineData("ghijklmn", "ghjaabcc")]
    public void NextValid(string input, string expectedResult)
    {
        // Arrange
        IPasswordGenerator generator = new PasswordGenerator();
        
        // Act
        var result = generator.GetNextPassword(input);
            
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("hijklmmn", false)]
    [InlineData("abbceffg", false)]
    [InlineData("abbcegjk", false)]
    [InlineData("abcdffaa", true)]
    [InlineData("ghjaabcc", true)]
    public void IsPasswordValid(string input, bool expectedResult)
    {
        // Arrange
        IPasswordGenerator generator = new PasswordGenerator();
        
        // Act
        var result = generator.IsPasswordValid(input);
            
        // Assert
        Assert.Equal(expectedResult, result);
    }
}