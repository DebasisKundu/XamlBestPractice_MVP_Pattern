using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Services.Navigation;
using System.Threading.Tasks;

namespace GHouseMobile.Core.ViewModel.Base
{
    public class BaseViewModel : BaseObservable
    {
        protected readonly INavigationService NavigationService;

        public BaseViewModel()
        {
            NavigationService = ContainerManager.Current.Resolve<INavigationService>();
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public virtual Task InitializeAsync(object? parameter) => Task.FromResult(false);
    }
}
