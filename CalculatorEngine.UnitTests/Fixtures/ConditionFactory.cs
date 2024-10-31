
using CalculatorEngine.Models.Conditions;

namespace CalculatorEngine.UnitTests.Fixtures
{
    public static class ConditionFactory
    {
        public static ActivePeriodCondition GetValidActivePeriodCondition() 
        {
            var randomId = new Random().Next().ToString();
            return new ActivePeriodCondition(randomId)
            {
                StartDateTime = DateTime.Now.AddMinutes(-1),
                EndDateTime = DateTime.Now.AddDays(1)
            };
        }

        public static ActivePeriodCondition GetInValidActivePeriodCondition()
        {
            var randomId = new Random().Next().ToString();
            return new ActivePeriodCondition(randomId)
            {
                StartDateTime = DateTime.Now.AddDays(10),
                EndDateTime = DateTime.Now.AddDays(15)
            };
        }
        public static ItemPropertiesCondition GetItemPropertiesCondition(string key = "Group", string value = "Shoe")
        {
            var randomId = new Random().Next().ToString();
            var condition = new ItemPropertiesCondition(randomId)
            {
            };
            condition.AddProperty(key, value);
            return condition;
        }
        public static ContextPropertiesCondition GetContextPropertiesCondition(string key = "Group", string value = "Shoe")
        {
            var randomId = new Random().Next().ToString();
            var condition = new ContextPropertiesCondition(randomId)
            {
            };
            condition.AddProperty(key, value);
            return condition;
        }

        public static LimitedAssignmentCondition GetLimitedAssignmentCondition(int maxAssignments)
        {
            var randomId = new Random().Next().ToString();
            return new LimitedAssignmentCondition(randomId)
            {
                MaxNumberOfAssignments = maxAssignments
            };
        }
        public static ItemCountCondition GetItemCountCondition(int minimumAount)
        {
            var randomId = new Random().Next().ToString();
            return new ItemCountCondition(randomId)
            {
                MinimumAmount = minimumAount
            };
        }
        public static NthItemCondition GetNthItemCondition(int nthItem)
        {
            var randomId = new Random().Next().ToString();
            return new NthItemCondition(randomId)
            {
                NthItem = nthItem
            };
        }
        public static ItemCountCondition GetSameKindCondition(int minimumAount, string key = "Group", string value = "Shoe")
        {
            var randomId = new Random().Next().ToString();
            var condition = new ItemCountCondition(randomId)
            {
                MinimumAmount = minimumAount
            };
            condition.AddCondition(GetItemPropertiesCondition(key, value));
            return condition;
        }
        public static ItemCustomCondition GetItemCustomCondition(string query)
        {
            var randomId = new Random().Next().ToString();
            return new ItemCustomCondition(randomId)
            {
                Query = query
            };
        }
        public static AnyItemCustomCondition GetAnyItemCustomCondition(string query)
        {
            var randomId = new Random().Next().ToString();
            return new AnyItemCustomCondition(randomId)
            {
                Query = query
            };
        }
        public static TotalPriceCondition GetTotalPriceCondition(decimal exceedingTotalPrice)
        {
            var randomId = new Random().Next().ToString();
            return new TotalPriceCondition(randomId)
            {
                ExceedingTotalPrice = exceedingTotalPrice
            };
        }

    }
}
