using GHouseMobile.Core.ViewModel.Base;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateBackAsync<TViewModel>();
    }
}
