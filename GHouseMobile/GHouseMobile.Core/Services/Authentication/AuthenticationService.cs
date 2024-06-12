using GHouseMobile.Core.Models.User;
using GHouseMobile.Core.Services.Request;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IRequestService _requestService;

        public AuthenticationService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public bool IsAuthenticated => GlobalSettings.User != null;

        public UserInfo? AuthenticatedUser => GlobalSettings.User;

        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginInfo = new LoginInfo(username, password);

            var userInfo = await _requestService.Post<LoginInfo, UserInfo>(GlobalSettings.LoginEndpoint, loginInfo);
            GlobalSettings.User = userInfo;

            return true;
        }

        public async Task LogoutAsync()
        {
            await _requestService.Post(GlobalSettings.LogoutEndpoint, AuthenticatedUser);
            GlobalSettings.RemoveUserData();
        }
    }
}
