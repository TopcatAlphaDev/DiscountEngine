namespace Calculator.Desginer.Controllers
{
    public class CampaignDetailsController
    {
        private readonly ListView _listView;
        public CampaignDetailsController(ListView listView)
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
            _listView.Groups.Add("Discounts", "Discounts");
            _listView.Groups.Add("Correctors", "Correctors");
            _listView.Groups.Add("Validators", "Validators");
            _listView.EndUpdate();
        }
    }
}

