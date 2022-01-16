using DigitManager.Api.Models;
using DigitManager.ModelLibrary;
using DigitManager.ModelLibrary.MainAndSubRelation;
using DigitManager.ModelLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Repository
{
    public class DigitNumRepository : IDigitNumRepository
    {
        private readonly AppDbContext db;

        public DigitNumRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<MainDigit> DeleteMainDigit(int mainDigitId)
        {
            var mainDigit = await db.MainDigits.FirstOrDefaultAsync(x => x.MainDigitId == mainDigitId);
            var subDigits = await db.SubDigits.Where(x => x.MainDigitId == mainDigitId).ToListAsync();
            db.SubDigits.RemoveRange(subDigits);
            db.MainDigits.Remove(mainDigit);
            await db.SaveChangesAsync();

            return mainDigit;
        }

        public async Task<string> DeleteVoucher(string voucherGuid)
        {
            var mainDigits = await db.MainDigits.Where(x => x.VoucherId == voucherGuid).ToListAsync();
            var subDigits = await db.SubDigits.Where(x => x.MainDigit.VoucherId == voucherGuid).ToListAsync();
            db.SubDigits.RemoveRange(subDigits);
            db.MainDigits.RemoveRange(mainDigits);
            await db.SaveChangesAsync();

            return voucherGuid;
        }

        public async Task<IEnumerable<SubDigit>> GetAllDigit()
        {
            var allDigits = await db.SubDigits.Where(x=> x.MainDigit.Agent.IsActive).Include(x=> x.MainDigit).ThenInclude(x=> x.Agent).ToListAsync();
            return allDigits;
        }

        //public async Task<List<SubDigit>> GetAllDigitGroupByAgent()
        //{
        //    var allDigitGroup = await db.SubDigits.Include(x => x.MainDigit)
        //        .ThenInclude(x => x.Agent).GroupBy(x=> x.MainDigit.Agent.AgentId).ToListAsync();
        //}

        public async Task<IEnumerable<SubDigit>> GetDigitForAgent(int agentId)
        {
            var agentDigits = await db.SubDigits.Where(x => x.MainDigit.Agent.IsActive).Include(x => x.MainDigit).ThenInclude(x => x.Agent).Where(x => x.MainDigit.Agent.AgentId == agentId).ToListAsync();

            return agentDigits;
        }

        public async Task<MainDigit> GetMainDigit(int mainDigitId)
        {
            var result = await db.MainDigits.FirstOrDefaultAsync(x => x.MainDigitId == mainDigitId);
            return result;
        }

        public async Task<IEnumerable<SubDigit>> GetSubDigitsWithRequestParams(ParamsForRequestSubDigit requestParams)
        {
            List<SubDigit> agentDigits = new List<SubDigit>();
            if(requestParams.AgentId == 0)
            {
                agentDigits = await db.SubDigits.Where(x => x.MainDigit.Agent.IsActive &&
                                x.MainDigit.MorningOrEvening == requestParams.AmOrPm &&
                                x.MainDigit.IntendedDate.Date == requestParams.IntendedDate.Date)
                                .Include(x => x.MainDigit).ThenInclude(x => x.Agent).ToListAsync();
            }
            else
            {
                agentDigits = await db.SubDigits.Where(x => x.MainDigit.Agent.IsActive &&
                                x.MainDigit.Agent.AgentId == requestParams.AgentId &&
                                x.MainDigit.MorningOrEvening == requestParams.AmOrPm &&
                                x.MainDigit.IntendedDate.Date == requestParams.IntendedDate.Date)
                                .Include(x => x.MainDigit).ThenInclude(x => x.Agent).ToListAsync();
            }            

            return agentDigits;
        }

        public async Task<IEnumerable<MainDigit>> SaveDigitVoucher(List<MainDigit> mainDigits)
        {
            List<MainDigit> result = new List<MainDigit>();
            DateTime dateTime = DateTime.UtcNow.AddMinutes(390);
            string guid = Guid.NewGuid().ToString();
            foreach (var maindigit in mainDigits)
            {
                maindigit.VoucherId = guid;
                maindigit.CreatedDate = dateTime;
                maindigit.UpdatedDate = dateTime;
                var addedResult = await db.MainDigits.AddAsync(maindigit);
                await db.SaveChangesAsync();
                result.Add(addedResult.Entity);
                List<SubDigit> subs = new List<SubDigit>();
                List<TwoNumAndPrice> numAndPrices = new List<TwoNumAndPrice>();
                numAndPrices = maindigit.ShortcutType.GenerateTwoNumList(maindigit.NumStr, maindigit.AmmountOne, maindigit.AmmountTwo, out long other);
                subs = numAndPrices.Select(x => new SubDigit
                {
                    TwoNum = x.TwoNumString,
                    Ammount = x.Ammount,
                    MainDigitId = maindigit.MainDigitId,
                    CreatedDate = dateTime,
                    UpdatedDate = dateTime
                }).ToList();
                try
                {
                    await db.SubDigits.AddRangeAsync(subs);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    db.MainDigits.RemoveRange(result);
                    await db.SaveChangesAsync();
                    throw ex;
                }              
            }
            return result;
        }

        public async Task<MainDigit> UpdateMainDigit(MainDigit mainDigit)
        {
            string guid = mainDigit.VoucherId;
            var toRemoveSubDigits = await db.SubDigits.Where(x => x.MainDigit.MainDigitId == mainDigit.MainDigitId).ToListAsync();
            var toUpdateMainDigit = await db.MainDigits.FirstOrDefaultAsync(x => x.MainDigitId == mainDigit.MainDigitId);
            toUpdateMainDigit.AgentId = mainDigit.AgentId;
            toUpdateMainDigit.AmmountOne = mainDigit.AmmountOne;
            toUpdateMainDigit.AmmountTwo = mainDigit.AmmountTwo;
            toUpdateMainDigit.DescriptionToShowUser = mainDigit.DescriptionToShowUser;
            toUpdateMainDigit.IntendedDate = mainDigit.IntendedDate;
            toUpdateMainDigit.MorningOrEvening = mainDigit.MorningOrEvening;
            toUpdateMainDigit.NumStr = mainDigit.NumStr;
            toUpdateMainDigit.ShortcutType = mainDigit.ShortcutType;
            toUpdateMainDigit.TotalAmmount = mainDigit.TotalAmmount;
            toUpdateMainDigit.UpdatedDate = DateTime.UtcNow.AddMinutes(390);
            toUpdateMainDigit.VoucherId = mainDigit.VoucherId;

            db.SubDigits.RemoveRange(toRemoveSubDigits);
            db.MainDigits.Update(toUpdateMainDigit);

            List<SubDigit> subs = new List<SubDigit>();
            List<TwoNumAndPrice> numAndPrices = new List<TwoNumAndPrice>();
            numAndPrices = mainDigit.ShortcutType.GenerateTwoNumList(mainDigit.NumStr, mainDigit.AmmountOne, mainDigit.AmmountTwo, out long other);
            subs = numAndPrices.Select(x => new SubDigit
            {
                TwoNum = x.TwoNumString,
                Ammount = x.Ammount,
                MainDigitId = toUpdateMainDigit.MainDigitId,
                CreatedDate = mainDigit.CreatedDate,
                UpdatedDate = DateTime.UtcNow.AddMinutes(390)
            }).ToList();
            await db.SubDigits.AddRangeAsync(subs);
            await db.SaveChangesAsync();

            return toUpdateMainDigit;
        }
    }
}
