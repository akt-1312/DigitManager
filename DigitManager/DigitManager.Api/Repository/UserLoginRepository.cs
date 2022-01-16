using DigitManager.Api.Models;
using DigitManager.ModelLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly AppDbContext db;

        public UserLoginRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Agent> GetValidateAgent(string userName)
        {
            var result = await db.Agents.Where(x => x.IsActive && x.AgentOrPlayer == AgentOrPlayerEnum.Agent && x.UserName == userName).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Agent> GetValidatePlayer(string userName)
        {
            var result = await db.Agents.Where(x => x.IsActive && x.AgentOrPlayer == AgentOrPlayerEnum.Player && x.UserName == userName).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Agent> LoginAgent(LoginUserData user)
        {
            var result = await db.Agents.Where(x => x.IsActive && x.AgentOrPlayer == AgentOrPlayerEnum.Agent && x.UserName.Trim() == user.UserName.Trim() && x.Password.Trim() == user.Password.Trim()).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Owner> LoginOwner(LoginUserData user)
        {
            var result = await db.Owners.Where(x => x.UserName.Trim() == user.UserName.Trim() && x.Password.Trim() == user.Password.Trim()).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Agent> LoginPlayer(LoginUserData user)
        {
            var result = await db.Agents.Where(x => x.IsActive && x.AgentOrPlayer == AgentOrPlayerEnum.Player && x.UserName.Trim() == user.UserName.Trim() && x.Password.Trim() == user.Password.Trim()).FirstOrDefaultAsync();
            return result;
        }

        //public async Task<OwnerRefreshToken> AddOwnerRefreshToken(OwnerRefreshToken ownerRefreshToken)
        //{
        //    var result = await db.OwnerRefreshTokens.AddAsync(ownerRefreshToken);
        //    await db.SaveChangesAsync();
        //    return result.Entity;
        //}
    }
}
