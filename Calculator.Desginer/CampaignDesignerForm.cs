using Calculator.Desginer.Controllers;

namespace Calculator.Desginer
{
    public partial class CampaignDesignerForm : Form
    {
        private readonly ObjectToolBoxController _objectToolBoxController;
        private readonly CampaignDetailsController _campaignDetailsController;
        public CampaignDesignerForm()
        {
            InitializeComponent();
            _objectToolBoxController = new ObjectToolBoxController(ObjectToolBox);
            _campaignDetailsController = new CampaignDetailsController(CampaignDetails);
        }

        private void CampaignDesignerForm_Load(object sender, EventArgs e)
        {
            _objectToolBoxController.Initialize();
            _campaignDetailsController.Initialize();
        }

        private void CampaignDetails_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
        }

        private void ObjectToolBox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ObjectToolBox.DoDragDrop(ObjectToolBox.SelectedItems, DragDropEffects.Move);
        }

        private void CampaignDetails_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = e.AllowedEffect;
        }

        private void CampaignDetails_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)))
                {
                    var a = (ListViewItem)current.Clone();
                    var group = FindGroupByName(a.Group.Name);
                    a.Group = group;
                    CampaignDetails.Items.Add(a);
                }
            }
        }
        private ListViewGroup FindGroupByName(string groupName)
        {
            foreach (ListViewGroup group in CampaignDetails.Groups)
            {
                if (group.Name == groupName)
                {
                    return group;
                }
            }
            return null; // Group not found
        }
        private void CampaignDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

            SelectedObjectPropertyGrid.SelectedObject = CampaignDetails.FocusedItem;
        }
    }
}
