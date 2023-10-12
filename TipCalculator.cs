namespace SplitTheBill
{
    public class TipCalculator
    {
        public static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null)
            {
                throw new ArgumentNullException(nameof(mealCosts), "Meal costs dictionary cannot be null.");
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(tipPercentage), "Tip percentage must be between 0 and 100.");
            }

            decimal totalMealCost = mealCosts.Values.Sum();
            decimal totalTipAmount = (decimal)(tipPercentage / 100.0) * totalMealCost;

            Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();

            foreach (var pair in mealCosts)
            {
                decimal tipShare = (pair.Value / totalMealCost) * totalTipAmount;
                tipAmounts[pair.Key] = tipShare;
            }

            return tipAmounts;
        }
    }
}
