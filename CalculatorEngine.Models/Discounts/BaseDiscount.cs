using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Conditions;
using CalculatorEngine.Models.Items;
using Newtonsoft.Json;

namespace CalculatorEngine.Models.Discounts
{
    public class BaseDiscount
    {
        public readonly string Id;
        public readonly int SortOrder;
        [JsonProperty] 
        protected List<BaseCondition> Conditions = new List<BaseCondition>();

        public BaseDiscount(string id = "", int sortOrder = 0)
        {
            Id = id;
            SortOrder = sortOrder;
        }

        public virtual void ApplyDiscount(Item item, Context context)
        {
            item.Reports.ForEach(x => x.Add(this, item));
        }

        public void AddCondition(BaseCondition condition)
        {
            Conditions.Add(condition);
        }
    }
}