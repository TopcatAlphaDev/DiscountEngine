using CalculatorEngine.Models.Validators;

namespace CalculatorEngine.UnitTests.Fixtures
{
    public static class ValidatorFactory
    {
        public static BaseValidator GetMinimumValidator(decimal minimumPrice)
        {
            var randomId = new Random().Next().ToString();
            return new AllowedMinimumValidator(randomId, 0, minimumPrice);
        }
    }
}
