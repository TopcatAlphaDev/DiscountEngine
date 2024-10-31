using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Discounts
{
    public class Price2Discount : BaseDiscount
    {
        public bool OverRulesOtherDiscounts;

        public Price2Discount(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void ApplyDiscount(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (OverRulesOtherDiscounts)
                item.FinalPrice = item.Price2;
            else if (item.Price2 < item.FinalPrice)
            {
                item.FinalPrice = item.Price2;
            }
            base.ApplyDiscount(item, context);
        }
    }
}