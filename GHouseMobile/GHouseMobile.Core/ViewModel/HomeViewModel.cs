using GHouseMobile.Core.Commands;
using GHouseMobile.Core.Models;
using GHouseMobile.Core.Models.User;
using GHouseMobile.Core.Services.Navigation;
using GHouseMobile.Core.Services.User;
using GHouseMobile.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GHouseMobile.Core.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        public Command ValidateInputs { get; set; }
        public IAsyncCommand ValidateUser { get; set; }

        public UserInfo UserInfo { get; set; }

        public HomeViewModel(IUserService userService)
        {
            UserInfo = new UserInfo();

            UserInfo.MobileNumber.IsValid = !string.IsNullOrEmpty(UserInfo.MobileNumber.Value);

            //TODO : get value from api, based on culture
            UserInfo.MobileNumber.ErrorMessage = "Please enter valid mobile number";
            UserInfo.MobileNumber.PlaceHolder = "Mobile Number";
            _userService = userService;

            ValidateUser = new AsyncCommand(async () => await CheckUserExist()
          );
        }

        async Task CheckUserExist()
        {
            var isUserExist = await _userService.CheckUserAsync("917064339334");
            if (isUserExist)
                await NavigationService.NavigateToAsync<LoginViewModel>();
            else
                await NavigationService.NavigateToAsync<RegisterViewModel>();
        }
    }
}
