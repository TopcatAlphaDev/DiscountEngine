using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Discounts
{
    // example OR instead of AND for conditions !
    public class PercentageDiscountWhenAny : BaseDiscount
    {
        public decimal Percentage;
        public bool Cumulating;
        public PercentageDiscountWhenAny(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void ApplyDiscount(Item item, Context context)
        {
            if (Conditions.All(x => x.IsFulFilled(item, context) == false)) return;

            if (Cumulating)
                item.FinalPrice = item.FinalPrice - (item.FinalPrice * (Percentage / 100));
            else if (item.OriginalPrice - (item.OriginalPrice * (Percentage / 100)) < item.FinalPrice)
            {
                item.FinalPrice = item.OriginalPrice - (item.OriginalPrice * (Percentage / 100));
            }
            base.ApplyDiscount(item, context);
        }
    }
}