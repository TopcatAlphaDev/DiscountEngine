using CalculatorEngine.Models.Validators;

namespace CalculatorEngine.Models.Reports.Extensions
{
    public static class ValidatorExtensions
    {
        public static string ToText(this BaseValidator validator)
        {
            switch (validator)
            {
                case AllowedMinimumValidator v1: return v1.ToText();
                default: throw new ArgumentException($"Unknow validator {validator.GetType().Name}!");
            }
        }
        public static string ToText(this AllowedMinimumValidator validator)
        {
            return $"Validator {validator.GetType().Name} {validator.Id} applied with allowedMinimum {validator.AllowedMinimum} and sortOrder {validator.SortOrder}";
        }
    }
}
