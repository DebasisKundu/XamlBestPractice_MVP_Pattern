
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Enums;
using GHouseMobile.Core.Helpers;
using GHouseMobile.Core.Services.Navigation;
using GHouseMobile.Core.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GHouseMobile.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        
    }
}