using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Services.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GHouseMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeNavigation();
        }

        private Task InitializeNavigation()
        {
            var navigationService = ContainerManager.Current.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
