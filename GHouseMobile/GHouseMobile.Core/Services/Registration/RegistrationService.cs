using System;
using System.Threading.Tasks;
using GHouseMobile.Core.Models.API;
using GHouseMobile.Core.Models.User;
using GHouseMobile.Core.Services.Request;

namespace GHouseMobile.Core.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRequestService _requestService;

        public RegistrationService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task<APIResponse> RegisterAsync(UserInfo userInfo)
        {
            return new APIResponse();//await _requestService.Post<UserInfo, APIResponse>(GlobalSettings.RegisterEndpoint, userInfo);
        }
    }
}
