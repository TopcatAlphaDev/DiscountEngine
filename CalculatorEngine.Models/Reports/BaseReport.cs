using CalculatorEngine.Models.Correctors;
using CalculatorEngine.Models.Conditions;
using CalculatorEngine.Models.Discounts;
using CalculatorEngine.Models.Items;
using CalculatorEngine.Models.Validators;

namespace CalculatorEngine.Models.Reports
{
    public class BaseReport
    {
        public readonly string Id;
        public readonly int SortOrder;
        public BaseReport(string id, int sortOrder)
        {
            Id = id;
            SortOrder = sortOrder;
        }
        public virtual void Add(BaseDiscount discount, Item item) 
        { 
        }
        public virtual void Add(BaseCondition condition, Item item)
        {
        }
        public virtual void Add(BaseCorrector discount, Item item)
        {
        }
        public virtual void Add(BaseValidator discount, Item item)
        {
        }
    }
}
