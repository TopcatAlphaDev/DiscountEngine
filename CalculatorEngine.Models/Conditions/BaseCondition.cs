using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Items;
using Newtonsoft.Json;

namespace CalculatorEngine.Models.Conditions
{
    public class BaseCondition
    {
        public readonly string Id;
        public readonly int SortOrder;
        [JsonProperty] 
        protected List<BaseCondition> Conditions = new List<BaseCondition>();

        public BaseCondition(string id)
        {
            Id = id;
        }

        public virtual bool IsFulFilled(Item item, Context context)
        {
            if (Conditions.Any(x => x.IsFulFilled(item, context) == false)) return false;
            return true;
        }
        public void AddCondition(BaseCondition condition)
        {
            Conditions.Add(condition);
        }

        protected bool Result(Item item, bool isFulFilled) 
        {
            if (isFulFilled) { 
                item.Reports.ForEach(x => x.Add(this, item)); 
            }
            return isFulFilled;
        }
    }
}