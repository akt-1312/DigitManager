using DigitManager.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Repository
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetOwners();
        Task<Owner> GetOwner(int id);
        //Task<Owner> GetLoginOwner(string userName, string password);
        Task<Owner> UpdateOwner(Owner owner);

        Task<Owner> CheckOwnerOldPasswordCorrect(int agentId, string password);
        Task<Owner> ChangeAndResetOwnerPassword(Owner owner);
        //Task<Owner> LoginOwner(LoginUserData user);

    }
}
