using CalculatorEngine.Models.Correctors;

namespace CalculatorEngine.Models.Reports.Extensions
{
    public static class CorrectorExtensions
    {
        public static string ToText(this BaseCorrector corrector)
        {
            switch (corrector)
            {
                case AllowedMinimumCorrector c1: return c1.ToText();
                case MinimumPurchasePriceCorrector c2: return c2.ToText();
                case MaximumOriginalPriceCorrector c3: return c3.ToText();
                default: throw new ArgumentException($"Unknow corrector {corrector.GetType().Name}!");
            }
        }
        public static string ToText(this AllowedMinimumCorrector corrector)
        {
            return $"Correction {corrector.GetType().Name} {corrector.Id} applied";
        }
        public static string ToText(this MinimumPurchasePriceCorrector corrector)
        {
            return $"Correction {corrector.GetType().Name} {corrector.Id} applied";
        }
        public static string ToText(this MaximumOriginalPriceCorrector corrector)
        {
            return $"Correction {corrector.GetType().Name} {corrector.Id} applied";
        }
    }
}
