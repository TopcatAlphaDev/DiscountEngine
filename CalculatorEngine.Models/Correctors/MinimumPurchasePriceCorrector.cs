using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Correctors
{
    public class MinimumPurchasePriceCorrector : BaseCorrector
    {
        public decimal AllowedMinimum = 0;

        public MinimumPurchasePriceCorrector(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void Correct(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (item.FinalPrice < item.PurchasePrice)
            {
                item.FinalPrice = item.PurchasePrice;
            }
            base.Correct(item, context);
        }
    }
}