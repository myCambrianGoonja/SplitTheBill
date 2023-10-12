namespace SplitTheBill;

public class SplitTheBill
{
    public static decimal GetSplitAmount(int numberOfPeople, decimal totalAmount)
    {
        if(numberOfPeople <= 0) {
            throw new ArgumentException("Minimum number of people we can have is 1");
        } else if(totalAmount <= 0) {
            throw new ArgumentException("Bill amount needs to be more than 0");
        }


        return totalAmount/numberOfPeople;
    }
}
