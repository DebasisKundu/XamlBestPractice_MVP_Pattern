using GHouseMobile.Core.Services.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.User
{
    public class UserService : IUserService
    {
        readonly IRequestService _requestService;

        public UserService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public Task<bool> CheckUserAsync(string userName)
        {
            var uri = string.Concat(GlobalSettings.CheckUserEndpoint, "?userName=", userName);
            return _requestService.GetAsync<bool>(uri);
        }
    }
}
