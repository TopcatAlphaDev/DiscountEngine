using System.Data;
using System.Text.Json.Serialization;
using CalculatorEngine.Models.Calculator;
using CalculatorEngine.Models.Correctors;
using CalculatorEngine.Models.Discounts;
using CalculatorEngine.Models.Items;
using Newtonsoft.Json;
using BaseValidator = CalculatorEngine.Models.Validators.BaseValidator;

namespace CalculatorEngine.Library
{
    public class CalculatorEngine
    {
        private List<Item> _items = new List<Item>();
        private Context _context;

        [JsonProperty] 
        private List<BaseDiscount> _discounts = new List<BaseDiscount>();
        [JsonProperty] 
        private List<BaseValidator> _validators = new List<BaseValidator>();
        [JsonProperty] 
        private List<BaseCorrector> _correctors = new List<BaseCorrector>();
        public CalculatorEngine()
        {
            _context = new Context();
        }

        public void Execute()
        {
            if (_items.Count == 0)
            {
                throw new DataException("Nothing to calculate!");
            }

            _context.Items = _items;

            _items
                .OrderBy(x => x.SortOrder).ToList()
                .ForEach(Calculate);
        }

        private void Calculate(Item item)
        {
            item.FinalPrice = item.OriginalPrice;
            _discounts
                .OrderBy(x => x.SortOrder).ToList()
                .ForEach(x => x.ApplyDiscount(item, _context));
            _correctors
                .OrderBy(x => x.SortOrder).ToList()
                .ForEach(x => x.Correct(item, _context));
            _validators
                .OrderBy(x => x.SortOrder).ToList()
                .ForEach(x => x.Validate(item, _context));
        }
        public bool AddItemsToCalculate(List<Item> items)
        {
            _items.AddRange(items);
            return true;
        }
        public bool AddItem(Item item)
        {
            _items.Add(item);
            return true;
        }
        public void SetActiveDateTime(DateTime activeDateTime)
        {
            _context.ActiveDateTime = activeDateTime;
        }
        public bool AddProperty(string key, string value)
        {
            _context.Properties.Add(new KeyValuePair<string, string>(key, value));
            return true;
        }

        public bool AddDiscount(BaseDiscount discount)
        {
            _discounts.Add(discount);
            return true;
        }

        public bool AddValidator(BaseValidator validator)
        {
            _validators.Add(validator);
            return true;
        }

        public bool AddCorrector(BaseCorrector corrector)
        {
            _correctors.Add(corrector);
            return true;
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}