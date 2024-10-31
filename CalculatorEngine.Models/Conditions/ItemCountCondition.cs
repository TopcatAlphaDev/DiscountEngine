using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Conditions
{
    public class ItemCountCondition : BaseCondition
    {
        public int MinimumAmount = 0;

        public ItemCountCondition(string id) : base(id)
        {
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;

            if (context.Items.Count(x => base.IsFulFilled(x, context)) < MinimumAmount) return false;

            return Result(item, true);
        }
    }
}