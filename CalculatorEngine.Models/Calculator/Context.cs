using CalculatorEngine.Models.Items;

namespace CalculatorEngine.Models.Calculator
{
    public class Context
    {
        public DateTime ActiveDateTime = DateTime.Now;
        public List<Item> Items = new List<Item>();
        public List<KeyValuePair<string, string>> Properties = new List<KeyValuePair<string, string>>();
    }
}
