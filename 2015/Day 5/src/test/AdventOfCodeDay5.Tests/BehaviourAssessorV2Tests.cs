using NUnit.Framework;

namespace AdventOfCodeDay5.Tests;

public class BehaviourAssessorV2Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("aaa", false)]
    [TestCase("abab", true)]
    [TestCase("abcde", false)]
    [TestCase("xxyxx", true)]
    [TestCase("dddggg", false)]
    public void DistinctLetterPairFound(string input, bool expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessorV2();
        
        // Act
        var result = assessor.DistinctLetterPairFound(input);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    [TestCase("xyx", 1,true)]
    [TestCase("abcdefeghi", 1, true)]
    [TestCase("aaa", 1, true)]
    [TestCase("uurcxstgmygtbstg", 1, false)]
    [TestCase("abcde", 1, false)]
    public void RepeatedLetter(string input, int spaceBetweenLetters, bool expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessorV2();
        
        // Act
        var result = assessor.RepeatedLetter(input, spaceBetweenLetters);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    [TestCase("qjhvhtzxzqqjkmpb", true)]
    [TestCase("xxyxx",  true)]
    [TestCase("uurcxstgmygtbstg", false)]
    [TestCase("ieodomkazucvgmuy",  false)]
    public void IsNice(string input, bool expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessorV2();
        
        // Act
        var result = assessor.IsNice(input);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}