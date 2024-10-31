using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Conditions
{
    public class ActivePeriodCondition : BaseCondition
    {
        public DateTime StartDateTime;
        public DateTime EndDateTime;

        public ActivePeriodCondition(string id) : base(id)
        {
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;

            return Result(item, StartDateTime <= context.ActiveDateTime && EndDateTime >= context.ActiveDateTime);
        }
    }
}