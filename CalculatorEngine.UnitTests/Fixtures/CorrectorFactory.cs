
using CalculatorEngine.Models.Correctors;

namespace CalculatorEngine.UnitTests.Fixtures
{
    public static class CorrectorFactory
    {
        public static MinimumPurchasePriceCorrector GetMinimumPurchaseCorrector() 
        {
            var randomId = new Random().Next().ToString();
            return new MinimumPurchasePriceCorrector(randomId, 0);
        }

        public static BaseCorrector GetMinimumCorrector(decimal minimumPrice)
        {
            var randomId = new Random().Next().ToString();
            return new AllowedMinimumCorrector(randomId, 0, minimumPrice);
        }

        public static BaseCorrector GetMaximumOriginalPriceCorrector()
        {
            var randomId = new Random().Next().ToString();
            return new MaximumOriginalPriceCorrector(randomId, 0);
        }
    }
}
