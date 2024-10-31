using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Discounts
{
    public class FixedPriceDiscount : BaseDiscount
    {
        public decimal Price;
        public bool OverRulesOtherDiscounts;
        public FixedPriceDiscount(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void ApplyDiscount(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (OverRulesOtherDiscounts)
                item.FinalPrice = Price;
            else if (Price < item.FinalPrice)
            {
                item.FinalPrice = Price;
            }
            base.ApplyDiscount(item, context);
        }
    }
}