using DigitManager.Api.Models;
using DigitManager.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.ModelLibrary.CryptoExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace DigitManager.Api.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext db;

        public OwnerRepository(AppDbContext db)
        {
            this.db = db;
        }      

        //public async Task<Owner> GetLoginOwner(string userName, string password)
        //{
        //    password = password == null ? password : password.EncryptPassword();
        //    var result = await db.Owners.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
        //    return result;
        //}

        public async Task<Owner> GetOwner(int id)
        {
            return await db.Owners.FirstOrDefaultAsync(x => x.OwnerId == id);
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            var result = await db.Owners.ToListAsync();
            return result;
        }

        //public async Task<Owner> LoginOwner(LoginUserData user)
        //{
        //    var result = await db.Owners.Where(x => x.UserName.Trim() == user.UserName.Trim() && x.Password.Trim() == user.Password.Trim()).FirstOrDefaultAsync();
        //    return result;
        //}

        public async Task<Owner> UpdateOwner(Owner owner)
        {
            var updateOwner = await db.Owners.FirstOrDefaultAsync(o => o.OwnerId == owner.OwnerId);
            if(updateOwner != null)
            {
                updateOwner.UserName = owner.UserName;
                updateOwner.Mobile = owner.Mobile;
                updateOwner.LuckyMultiply = owner.LuckyMultiply;
                updateOwner.DefaultMaxAmmountToPlay = owner.DefaultMaxAmmountToPlay;
                updateOwner.DeadlineHourAM = owner.DeadlineHourAM;
                updateOwner.DeadlineMinutesAM = owner.DeadlineMinutesAM;
                updateOwner.DeadlineHourPM = owner.DeadlineHourPM;
                updateOwner.DeadlineMinutesPM = owner.DeadlineMinutesPM;
                updateOwner.IsActive = owner.IsActive;
                updateOwner.UpdatedDate = DateTime.UtcNow.AddMinutes(390);

                db.Owners.Update(updateOwner);
                await db.SaveChangesAsync();

                return updateOwner;
            }

            return null;
        }

        public async Task<Owner> CheckOwnerOldPasswordCorrect(int ownerId, string password)
        {
            var requestOwner = await db.Owners.FirstOrDefaultAsync(x => x.OwnerId == ownerId && x.Password == password);
            return requestOwner;
        }

        public async Task<Owner> ChangeAndResetOwnerPassword(Owner owner)
        {
            var requestOwner = await db.Owners.FirstOrDefaultAsync(x => x.OwnerId == owner.OwnerId);
            if (requestOwner != null)
            {
                requestOwner.Password = owner.Password.Trim();
                db.Update(requestOwner);
                await db.SaveChangesAsync();
                return requestOwner;
            }
            else
            {
                return null;
            }
        }
    }
}
