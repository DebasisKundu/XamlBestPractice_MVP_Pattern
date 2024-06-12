using System;
using System.Threading.Tasks;
using GHouseMobile.Core.Models.API;
using GHouseMobile.Core.Models.User;

namespace GHouseMobile.Core.Services.Registration
{
    public interface IRegistrationService
    {
        Task<APIResponse> RegisterAsync(UserInfo userInfo);
    }
}
