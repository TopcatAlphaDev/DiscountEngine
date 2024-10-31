using CalculatorEngine.Models.Correctors;
using CalculatorEngine.Models.Conditions;
using CalculatorEngine.Models.Discounts;
using CalculatorEngine.Models.Items;
using CalculatorEngine.Models.Reports.Extensions;
using CalculatorEngine.Models.Validators;
using System.Text;

namespace CalculatorEngine.Models.Reports
{
    public class TextReport: BaseReport
    {
        private StringBuilder _text = new StringBuilder();

        public TextReport(string id, int sortOrder) :base(id, sortOrder)
        {

        }
        public string Text => _text.ToString();
        public override void Add(BaseDiscount discount, Item item)
        {
            _text.AppendLine($"{discount.ToText()}, resulting in finalprice {item.FinalPrice:0.00}");
        }
        public override void Add(BaseCondition condition, Item item)
        {
            _text.AppendLine(condition.ToText());
        }
        public override void Add(BaseCorrector corrector, Item item)
        {
            _text.AppendLine($"{corrector.ToText()}, resulting in finalprice {item.FinalPrice:0.00}");
        }
        public override void Add(BaseValidator validator, Item item)
        {
            _text.AppendLine(validator.ToText());
        }
    }
}
