
using CalculatorEngine.Models.Discounts;

namespace CalculatorEngine.Models.Reports.Extensions
{
    public static class DiscountExtensions
    {
        public static string ToText(this BaseDiscount discount)
        {
            switch (discount)
            {
                case AmountDiscount d1: return d1.ToText();
                case PercentageDiscount d2: return d2.ToText();
                case FixedPriceDiscount d3: return d3.ToText();
                default: throw new ArgumentException($"Unknow discount {discount.GetType().Name}!");
            }
        }
        public static string ToText(this AmountDiscount discount)
        {
            return $"Discount {discount.GetType().Name} {discount.Id} applied";
        }
        public static string ToText(this FixedPriceDiscount discount)
        {
            return $"Discount {discount.GetType().Name} {discount.Id} applied";
        }
        public static string ToText(this PercentageDiscount discount)
        {
            return $"Discount {discount.GetType().Name} {discount.Id} applied";
        }
    }
}
