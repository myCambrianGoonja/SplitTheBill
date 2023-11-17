using System.Runtime.CompilerServices;

namespace SplitTheBill.Tests;

[TestClass]
public class TipCalculator_TipCalculatorShould
{
    [TestMethod]
    public void CalculateTip_EqualMealCosts_ShouldReturnEqualTips()
    {
        var mealCosts = new Dictionary<string, decimal>
    {
        { "Person1", 50.0m },
        { "Person2", 50.0m },
        { "Person3", 50.0m }
    };
        float tipPercentage = 10.0f;

        // Act
        var tipAmounts = TipCalculator.CalculateTip(mealCosts, tipPercentage);

        // Assert
        foreach (var tipAmount in tipAmounts.Values)
        {
            Assert.AreEqual(5.0m, tipAmount, 0.001m); // Use a tolerance of 0.001m
        }

    }

    [TestMethod]
    public void CalculateTip_NullMealCosts_ShouldThrowArgumentNullException()
    {
        // Arrange
        Dictionary<string, decimal> mealCosts = null;
        float tipPercentage = 10.0f;

        // Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            TipCalculator.CalculateTip(mealCosts, tipPercentage);
        });
    }

    [TestMethod]
    public void CalculateTip_InvalidTipPercentage_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var mealCosts = new Dictionary<string, decimal>
            {
                { "Person1", 50.0m },
                
                { "Person2", 50.0m }
            };
        float tipPercentage = -10.0f;

        // Act and Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            TipCalculator.CalculateTip(mealCosts, tipPercentage);
        });
    }
}