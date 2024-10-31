using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Conditions
{
    public class LimitedAssignmentCondition : BaseCondition
    {
        public int MaxNumberOfAssignments = 999999999;
        private int NumberOfAssignments = 0;
        public int AvailableAssignments => MaxNumberOfAssignments - NumberOfAssignments;


        public LimitedAssignmentCondition(string id) : base(id)
        {
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;

            if (AvailableAssignments <= 0) return false;

            NumberOfAssignments++;

            return Result(item, true);
        }
    }
}