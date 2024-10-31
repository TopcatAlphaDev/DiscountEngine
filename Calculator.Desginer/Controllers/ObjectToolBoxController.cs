using Calculator.Desginer.Extensions;
using CalculatorEngine.Models.Correctors;
using CalculatorEngine.Models.Discounts;
using CalculatorEngine.Models.Validators;
using CalculatorEngine.Models.Conditions;

namespace Calculator.Desginer.Controllers
{
    public class ObjectToolBoxController
    {
        private readonly ListView _listView;
        public ObjectToolBoxController(ListView listView) 
        { 
            _listView = listView;
        }
        public void Initialize() 
        {
            _listView.Clear();
            _listView.Columns.Clear();
            _listView.Columns.Add("", 240, HorizontalAlignment.Left);
            _listView.HeaderStyle = ColumnHeaderStyle.None;
            _listView.MultiSelect = false;
            _listView.FullRowSelect = true;
            _listView.View = View.Details;

            _listView.BeginUpdate();
            AddItems<BaseCondition>("Conditions");
            AddItems<BaseCorrector>("Correctors");
            AddItems<BaseDiscount>("Discounts");
            AddItems<BaseValidator>("Validators");
            _listView.EndUpdate();
        }

        public void AddItems<T>(string groupName)
        {
            var group = _listView.Groups.Add(groupName, groupName);
            var items = GetInheritedClasses<T>().Select(x => new ListViewItem()  { Text = x.GetDisplayName(), Tag = x, Group = group }).ToArray();
            _listView.Items.AddRange(items);
        }
        public IEnumerable<Type> GetInheritedClasses<T>()
        {
            return typeof(T)
                .Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(T)) && !x.IsAbstract && !x.IsInterface);
        }
    }
}

