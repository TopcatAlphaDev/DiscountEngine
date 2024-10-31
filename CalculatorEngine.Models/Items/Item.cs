using CalculatorEngine.Models.Reports;

namespace CalculatorEngine.Models.Items
{
    public class Item
    {
        public readonly string Id;
        public readonly decimal OriginalPrice;
        public decimal Price2;
        public decimal Price3;
        public decimal Price4;
        public decimal Price5;
        public readonly decimal PurchasePrice;
        public decimal FinalPrice;
        public readonly int SortOrder;
        public readonly List<KeyValuePair<string, string>> Properties = new List<KeyValuePair<string, string>>();
        public readonly List<BaseReport> Reports = new List<BaseReport>();
        public Item(string id, decimal originalPrice, decimal purchasePrice, int sortOrder)
        {
            Id = id;
            OriginalPrice = originalPrice;
            PurchasePrice = purchasePrice;
            SortOrder = sortOrder;
        }

        public void AddProperty(string key, string value) 
        { 
            Properties.Add(new KeyValuePair<string, string>( key, value)); 
        }
        public void AddReport(BaseReport report)
        {
            Reports.Add(report);
        }
    }
}