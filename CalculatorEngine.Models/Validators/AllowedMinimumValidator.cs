using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Validators
{
    public class AllowedMinimumValidator : BaseValidator
    {
        public readonly decimal AllowedMinimum = 0;
        
        public AllowedMinimumValidator(string id, int sortOrder, decimal allowedMinimum) : base(id, sortOrder)
        {
            AllowedMinimum = allowedMinimum;
        }

        public override void Validate(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return;

            if (item.FinalPrice < AllowedMinimum)
            {
                throw new InvalidDataException("Minimum allowed exeeded this - item - value !");
            }
            base.Validate(item, context);
        }
    }
}