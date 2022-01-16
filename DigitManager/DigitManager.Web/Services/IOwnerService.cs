using DigitManager.ModelLibrary;
using DigitManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetOwners();
        Task<Owner> GetOwner(int id);
        //Task<Owner> GetLoginOwner(string userName, string password);
        Task<Owner> UpdateOwner(Owner owner);
        //Task<UserOwner> LoginOwner(LoginUserData user);
        //Task<OwnerRefreshToken> AddOwnerRefreshToken(OwnerRefreshToken ownerRefreshToken);
    }
}
