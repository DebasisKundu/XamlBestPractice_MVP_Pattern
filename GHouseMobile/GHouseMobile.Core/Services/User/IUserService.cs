using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.User
{
    public interface IUserService
    {
        Task<bool> CheckUserAsync(string userName);
    }
}
