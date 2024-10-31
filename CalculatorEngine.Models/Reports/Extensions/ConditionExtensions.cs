using CalculatorEngine.Models.Conditions;

namespace CalculatorEngine.Models.Reports.Extensions
{
    public static class ConditionExtensions
    {
        public static string ToText(this BaseCondition condition)
        {
            switch (condition)
            {
                case ActivePeriodCondition c1: return c1.ToText();
                case ItemCountCondition c2: return c2.ToText();
                case LimitedAssignmentCondition c3: return c3.ToText();
                case ItemPropertiesCondition c4: return c4.ToText();
                case NthItemCondition c5: return c5.ToText();
                case AnyItemCustomCondition c6: return c6.ToText();
                case ItemCustomCondition c7: return c7.ToText();
                case TotalPriceCondition c8: return c8.ToText();
                default: throw new ArgumentException($"Unknow condition {condition.GetType().Name}!");
            }
        }
        public static string ToText(this ActivePeriodCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this ItemCountCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this LimitedAssignmentCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this ItemPropertiesCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this NthItemCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this AnyItemCustomCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this ItemCustomCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
        public static string ToText(this TotalPriceCondition condition)
        {
            return $"Condition {condition.GetType().Name} {condition.Id} is fulfilled";
        }
    }
}
