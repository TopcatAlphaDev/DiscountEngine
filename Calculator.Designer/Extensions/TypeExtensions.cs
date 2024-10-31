using CalculatorEngine.Models.Conditions;
using CalculatorEngine.Models.Correctors;
using CalculatorEngine.Models.Discounts;
using CalculatorEngine.Models.Validators;

namespace Calculator.Designer.Extensions
{
    public static class TypeExtensions
    {
        private static readonly Dictionary<Type, string> TypeDisplayNames = new Dictionary<Type, string>
        {
            { typeof(ActivePeriodCondition), "Active period condition" },
            { typeof(ItemCountCondition), "Item count condition" },
            { typeof(LimitedAssignmentCondition), "Limited assignment condition" },
            { typeof(ItemPropertiesCondition), "Item properties condition" },
            { typeof(NthItemCondition), "Nth item condition" },
            { typeof(AnyItemCustomCondition), "Any item custom condition" },
            { typeof(ItemCustomCondition), "Item custom condition" },
            { typeof(TotalPriceCondition), "Total price condition" },

            { typeof(AllowedMinimumCorrector), "Allowed minimum corrector" },
            { typeof(MinimumPurchasePriceCorrector), "Minimum purchaseprice corrector" },
            { typeof(MaximumOriginalPriceCorrector), "Maximum originalprice corrector" },

            { typeof(AmountDiscount), "Amount discount" },
            { typeof(FixedPriceDiscount), "Fixed pricedisxount" },
            { typeof(PercentageDiscount), "Percentage discount" },

            { typeof(AllowedMinimumValidator), "Allowed minimum validator" }
        };

        public static string GetDisplayName(this Type type) 
        {
            if (TypeDisplayNames.TryGetValue(type, out var displayName))
            {
                return displayName;
            }
            throw new NotImplementedException($" type {type.Name} does not support GetDisplayName() Extension! ");
        }
    }
}
