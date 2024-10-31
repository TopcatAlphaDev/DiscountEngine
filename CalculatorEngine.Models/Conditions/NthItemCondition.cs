using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Conditions
{
    public class NthItemCondition : BaseCondition
    {
        private int ItemCounter = 0;
        public int NthItem = 0;

        public NthItemCondition(string id) : base(id)
        {
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;
            
            ItemCounter++;

            if (ItemCounter != NthItem) return false;

            return Result(item, true);
        }
    }
}