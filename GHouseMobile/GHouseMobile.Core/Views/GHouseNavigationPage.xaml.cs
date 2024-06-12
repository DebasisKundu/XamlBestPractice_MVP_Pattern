
using Xamarin.Forms;

namespace GHouseMobile.Core.Views
{
    public partial class GHouseNavigationPage : NavigationPage
    {
        public bool IgnoreLayoutChange { get; set; } = false;

        public GHouseNavigationPage() : base()
        {
            InitializeComponent();
        }

        public GHouseNavigationPage(Page root) :
            base(root)
        {
            InitializeComponent();
        }        

        protected override void OnSizeAllocated(double width, double height)
        {
            if (!IgnoreLayoutChange)
                base.OnSizeAllocated(width, height);
        }
    }
}