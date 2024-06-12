using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Services.Authentication;
using GHouseMobile.Core.ViewModel;
using GHouseMobile.Core.ViewModel.Base;
using GHouseMobile.Core.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GHouseMobile.Core.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Dictionary<Type, Type> _mapping;

        private Application CurrentApplication => Application.Current;

        public NavigationService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _mapping = new Dictionary<Type, Type>();

            CreatePageViewModelMapping();
        }

        public async Task InitializeAsync()
        {
            if (_authenticationService.IsAuthenticated)
            {
                await NavigateToAsync<MainViewModel>();
            }
            else
            {
                await NavigateToAsync<HomeViewModel>();
            }
        }

        public async Task NavigateBackAsync<TViewModel>()
        {
            if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;
                await mainPage!.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel => InternalNavigateToAsync(typeof(TViewModel), parameter);

        private async Task InternalNavigateToAsync(Type viewModelType, object? parameter)
        {
            var page = CreateAndBindPage(viewModelType);

            if (page is MainView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (page is HomeView)
            {
                CurrentApplication.MainPage = new GHouseNavigationPage(page);
            }
            else if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;

                if (mainPage!.Detail is GHouseNavigationPage gHouseNavigationPage)
                {
                    var currentPage = gHouseNavigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        gHouseNavigationPage?.PushAsync(page);
                    }
                }
                else
                {
                    gHouseNavigationPage = new GHouseNavigationPage(page);
                    mainPage.Detail = gHouseNavigationPage;
                }
            }
            else
            {
                if (CurrentApplication.MainPage is GHouseNavigationPage gHouseNavigationPage)
                {
                    gHouseNavigationPage?.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new GHouseNavigationPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel)!.InitializeAsync(parameter);
        }

        private Page CreateAndBindPage(Type viewModelType)
        {
            var pageType = GetPageViewModelMapping(viewModelType);

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = ContainerManager.Current.Resolve(viewModelType) as BaseViewModel;
            page!.BindingContext = viewModel;

            return page;
        }

        private Type GetPageViewModelMapping(Type viewModelType)
        {
            if (!_mapping.ContainsKey(viewModelType))
            {
                throw new Exception($"No mapping found for {viewModelType}");
            }

            return _mapping[viewModelType];
        }

        private void CreatePageViewModelMapping()
        {
            _mapping.Add(typeof(HomeViewModel), typeof(HomeView));
            _mapping.Add(typeof(LoginViewModel), typeof(LoginView));
            _mapping.Add(typeof(MainViewModel), typeof(MainView));
            _mapping.Add(typeof(RegisterViewModel), typeof(RegisterView));

            // all other mappings will go here...
        }
    }
}
