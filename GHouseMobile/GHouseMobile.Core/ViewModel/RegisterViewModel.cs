using System;
using GHouseMobile.Core.Commands;
using GHouseMobile.Core.Models.User;
using GHouseMobile.Core.Services.Registration;
using GHouseMobile.Core.ViewModel.Base;

namespace GHouseMobile.Core.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IRegistrationService _registrationService;
        public UserInfo UserInfo { get; set; }

        public IAsyncCommand RegisterCommand { get; set; }

        public RegisterViewModel(IRegistrationService registrationService)
        {
            _registrationService = registrationService;

            UserInfo = new UserInfo();

            RegisterCommand = new AsyncCommand(() =>
             _registrationService.RegisterAsync(UserInfo));
        }
    }
}
