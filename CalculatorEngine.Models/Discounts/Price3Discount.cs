using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Discounts
{
    public class Price3Discount : BaseDiscount
    {
        public bool OverRulesOtherDiscounts;

        public Price3Discount(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void ApplyDiscount(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (OverRulesOtherDiscounts)
                item.FinalPrice = item.Price3;
            else if (item.Price3 < item.FinalPrice)
            {
                item.FinalPrice = item.Price3;
            }
            base.ApplyDiscount(item, context);
        }
    }
}