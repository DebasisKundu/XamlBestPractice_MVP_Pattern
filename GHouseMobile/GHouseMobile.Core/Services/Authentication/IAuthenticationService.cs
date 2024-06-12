using GHouseMobile.Core.Models.User;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        UserInfo? AuthenticatedUser { get; }

        Task<bool> LoginAsync(string username, string password);

        Task LogoutAsync();
    }
}
