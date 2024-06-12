using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Commands;
using GHouseMobile.Core.Services.Navigation;
using GHouseMobile.Core.ViewModel.Base;
using Xamarin.Forms;

namespace GHouseMobile.Core.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public IAsyncCommand NavigateToRegisterCommand { get; set; }
               
        public LoginViewModel()
        {
            NavigateToRegisterCommand = new AsyncCommand(() =>
            NavigationService.NavigateToAsync<RegisterViewModel>());
        }

    }
}
