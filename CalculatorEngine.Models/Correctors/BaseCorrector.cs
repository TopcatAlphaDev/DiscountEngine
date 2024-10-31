using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Conditions;
using CalculatorEngine.Models.Items;
using Newtonsoft.Json;

namespace CalculatorEngine.Models.Correctors
{
    public class BaseCorrector
    {
        public readonly string Id;
        public readonly int SortOrder;
        [JsonProperty] 
        protected List<BaseCondition> Conditions = new List<BaseCondition>();

        public BaseCorrector(string id = "", int sortOrder = 0)
        {
            Id = id;
            SortOrder = sortOrder;
        }

        public virtual void Correct(Item item, Context context)
        {
            item.Reports.ForEach(x => x.Add(this, item));
        }
        public void AddCondition(BaseCondition condition)
        {
            Conditions.Add(condition);
        }
    }
}