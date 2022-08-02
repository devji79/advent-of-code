using NUnit.Framework;

namespace AdventOfCodeDay5.Tests;

public class BehaviourAssessorV1Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("aei", 3)]
    [TestCase("xazegov", 3)]
    [TestCase("aeiouaeiouaeiou", 15)]
    public void CountVowels(string input, int expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessor();
        
        // Act
        var result = assessor.CountVowels(input);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    [TestCase("aei", false)]
    [TestCase("aaa", true)]
    [TestCase("jchzalrnumimnmhp", false)]
    [TestCase("haegwjzuvuyypxyu", true)]
    [TestCase("dvszwmarrgswjxmb", true)]
    public void ContainsDoubleLetter(string input, bool expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessor();
        
        // Act
        var result = assessor.ContainsDoubleLetter(input);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    [TestCase("aei", false)]
    [TestCase("aaa", false)]
    [TestCase("jchzalrnumimnmhp", false)]
    [TestCase("haegwjzuvuyypxyu", true)]
    [TestCase("dvszwmarrgswjxmb", false)]
    public void ContainsInvalidString(string input, bool expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessor();
        
        // Act
        var result = assessor.ContainsInvalidString(input);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    [TestCase("ugknbfddgicrmopn", true)]
    [TestCase("aaa", true)]
    [TestCase("jchzalrnumimnmhp", false)]
    [TestCase("haegwjzuvuyypxyu", false)]
    [TestCase("dvszwmarrgswjxmb", false)]
    public void IsNice(string input, bool expectedResult)
    {
        // Arrange
        var assessor = new BehaviourAssessor();
        
        // Act
        var result = assessor.IsNice(input);
        
        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}