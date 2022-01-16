using DigitManager.ModelLibrary;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.ModelLibrary.CryptoExtensions;

namespace DigitManager.Api.Extensions
{
    public static class SeedDataExtension
    {
        public static void SeedDefaultOwner(this ModelBuilder modelBuilder)
        {
            string password = "adminakt131218";
            password = password.EncryptPassword();
            modelBuilder.Entity<Owner>().HasData(new Owner()
            {
                OwnerId = 1,
                UserName = "adminakt",
                Password = password,
                Mobile = "099192939495",
                OwnerGuid = Guid.NewGuid().ToString(),
                LuckyMultiply = 80,
                DefaultMaxAmmountToPlay = 1000000,
                DeadlineHourAM = 11,
                DeadlineMinutesAM = 45,
                DeadlineHourPM = 4,
                DeadlineMinutesPM = 0,
                IsActive = true,
                CreatedData = DateTime.UtcNow.AddMinutes(390),
                UpdatedDate = DateTime.UtcNow.AddMinutes(390)
            });
        }
    }
}
