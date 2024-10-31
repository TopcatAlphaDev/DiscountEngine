using CalculatorEngine.Models.Discounts;

namespace CalculatorEngine.UnitTests.Fixtures
{
    public static class DiscountFactory
    {
        public static BaseDiscount GetNoDiscount() 
        {
            var randomId = new Random().Next().ToString();
            return new BaseDiscount(randomId, 0);
        }

        public static AmountDiscount GetAmountDiscount(decimal amount, int sortOrder = 0)
        {
            var randomId = new Random().Next().ToString();
            return new AmountDiscount(randomId, sortOrder) 
            { 
                Amount = amount
            };
        }
        public static PercentageDiscount GetPercentageDiscount(decimal percentage, int sortOrder = 0)
        {
            var randomId = new Random().Next().ToString();
            return new PercentageDiscount(randomId, sortOrder)
            {
                Percentage = percentage
            };
        }
        public static Price2Discount GetPrice2Discount(bool overRulesOtherDiscounts, int sortOrder = 0)
        {
            var randomId = new Random().Next().ToString();
            return new Price2Discount(randomId, sortOrder)
            {
                OverRulesOtherDiscounts = overRulesOtherDiscounts
            };
        }

        public static Price3Discount GetPrice3Discount(bool overRulesOtherDiscounts, int sortOrder = 0)
        {
            var randomId = new Random().Next().ToString();
            return new Price3Discount(randomId, sortOrder)
            {
                OverRulesOtherDiscounts = overRulesOtherDiscounts
            };
        }

    }
}
