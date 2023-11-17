using System.Runtime.CompilerServices;

namespace SplitTheBill.Tests;

[TestClass]
public class SplitTheBill_SplitTheBillShould
{
    [TestMethod]
    public void SplitBill_EqualAmounts_ShouldReturnEqualSplits()
    {
       decimal totalAmount = 100.0m;
            int numberOfPeople = 5;

            decimal splitAmount = SplitTheBill.GetSplitAmount(numberOfPeople, totalAmount);

            Assert.AreEqual(20.0m, splitAmount);
    }

    [TestMethod]
        public void SplitBill_Less_Than_ZeroPeople_ShouldThrowException()
        {
            decimal totalAmount = 100.0m;
            int numberOfPeople = -1;

            Assert.ThrowsException<ArgumentException>(() =>
            {
                SplitTheBill.GetSplitAmount(numberOfPeople, totalAmount);
            });
        }



[TestMethod]
        public void SplitBill_NegativeTotalAmount_ShouldThrowException()
        {
            decimal totalAmount = -100.0m;
            int numberOfPeople = 5;

            Assert.ThrowsException<ArgumentException>(() =>
            {
                SplitTheBill.GetSplitAmount(numberOfPeople, totalAmount);
            });
        }
}