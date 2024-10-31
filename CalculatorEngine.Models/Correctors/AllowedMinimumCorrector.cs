using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Correctors
{
    public class AllowedMinimumCorrector : BaseCorrector
    {
        protected decimal AllowedMinimum = 0;

        public AllowedMinimumCorrector(string id, int sortOrder, decimal allowedMinimum) : base(id, sortOrder)
        {
            AllowedMinimum = allowedMinimum;
        }

        public override void Correct(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (item.FinalPrice < AllowedMinimum)
            {
                item.FinalPrice = AllowedMinimum;
            }
            base.Correct(item, context);
        }
    }
}