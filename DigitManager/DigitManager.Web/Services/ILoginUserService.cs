using DigitManager.ModelLibrary;
using DigitManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Services
{
    public interface ILoginUserService
    {
        Task<UserOwner> LoginOwner(LoginUserData user);
        Task<UserAgent> LoginAgent(LoginUserData user);
        Task<UserAgent> LoginPlayer(LoginUserData user);
        Task<Agent> GetValidateAgent(string userName);
        Task<Agent> GetValidatePlayer(string userName);
        Task<UserAgent> AgentRefreshTokenAsync(RefreshRequest refreshRequest);
        Task<UserOwner> OwnerRefreshTokenAsync(RefreshRequest refreshRequest);
    }
}
