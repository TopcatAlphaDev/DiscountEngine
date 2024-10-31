using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Discounts
{
    public class AmountDiscount : BaseDiscount
    {
        public decimal Amount;
        public bool Cumulating;
        public AmountDiscount(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void ApplyDiscount(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (Cumulating)
                item.FinalPrice -= Amount;
            else if (item.OriginalPrice - Amount < item.FinalPrice)
            {
                item.FinalPrice = item.OriginalPrice - Amount;
            }
            base.ApplyDiscount(item, context);
        }
    }
}