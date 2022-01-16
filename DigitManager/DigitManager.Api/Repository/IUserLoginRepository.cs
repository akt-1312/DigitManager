using DigitManager.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Repository
{
    public interface IUserLoginRepository
    {
        Task<Owner> LoginOwner(LoginUserData user);
        Task<Agent> LoginAgent(LoginUserData user);
        Task<Agent> LoginPlayer(LoginUserData user);
        Task<Agent> GetValidateAgent(string userName);
        Task<Agent> GetValidatePlayer(string userName);
        //Task<OwnerRefreshToken> AddOwnerRefreshToken(OwnerRefreshToken ownerRefreshToken);
    }
}
