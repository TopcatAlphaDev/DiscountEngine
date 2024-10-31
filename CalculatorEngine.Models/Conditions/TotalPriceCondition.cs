using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;
using System.Linq.Dynamic.Core;

namespace CalculatorEngine.Models.Conditions
{
    public class TotalPriceCondition : BaseCondition
    {
        public decimal ExceedingTotalPrice = 0;

        public TotalPriceCondition(string id) : base(id)
        { 
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;

            if (context.Items.Sum(x => x.OriginalPrice) <= ExceedingTotalPrice) return false;

            return Result(item, true);
        }

    }
}