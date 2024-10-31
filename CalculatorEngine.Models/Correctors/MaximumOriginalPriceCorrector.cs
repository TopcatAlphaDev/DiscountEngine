using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Correctors
{
    public class MaximumOriginalPriceCorrector : BaseCorrector
    {
        public MaximumOriginalPriceCorrector(string id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override void Correct(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (item.FinalPrice > item.OriginalPrice)
            {
                item.FinalPrice = item.OriginalPrice;
            }
            base.Correct(item, context);
        }
    }
}