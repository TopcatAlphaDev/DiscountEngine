using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Conditions
{
    public class ContextPropertiesCondition : BaseCondition
    {
        private List<KeyValuePair<string, string>> Properties = new List<KeyValuePair<string, string>>();
        public bool MatchAllProperties;

        public ContextPropertiesCondition(string id) : base(id)
        {
        }

        public override bool IsFulFilled(Item item, Context context)
        {
            if (base.IsFulFilled(item, context) == false) return false;

            if (MatchAllProperties)
                return Result(item, Properties.All(x => context.Properties.Any(y => y.Key == x.Key && y.Value == x.Value)));
            else
                return Result(item, Properties.Any(x => context.Properties.Any(y => y.Key == x.Key && y.Value == x.Value)));
        }

        public void AddProperty(string key, string value)
        {
            Properties.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}