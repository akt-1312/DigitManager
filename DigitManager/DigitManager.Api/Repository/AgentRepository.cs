using DigitManager.Api.Models;
using DigitManager.ModelLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.ModelLibrary.CryptoExtensions;

namespace DigitManager.Api.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext db;

        public AgentRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<Agent> AddAgent(Agent agent)
        {
            Guid guid = Guid.NewGuid();
            agent.CreatedDate = DateTime.UtcNow.AddMinutes(390);
            agent.UpdatedDate = DateTime.UtcNow.AddMinutes(390);
            agent.IsActive = true;
            agent.AgentGuid = guid.ToString();
            agent.Password = !string.IsNullOrWhiteSpace(agent.Password) ? agent.Password.Trim() : agent.Password;
            var result = await db.Agents.AddAsync(agent);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Agent> DeleteAgent(int id)
        {
            var result = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
            if (result != null)
            {
                var allSubdigits = await db.SubDigits.Where(x => x.MainDigit.AgentId == result.AgentId).ToListAsync();
                var allMainDigits = await db.MainDigits.Where(x => x.AgentId == result.AgentId).ToListAsync();
                
                db.SubDigits.RemoveRange(allSubdigits);
                db.MainDigits.RemoveRange(allMainDigits);
                db.Agents.Remove(result);
                await db.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Agent> GetAgent(int id)
        {
            var result = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
            return result;
        }

        public async Task<Agent> GetAgentProfile(int id)
        {
            var result = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
            return result;
        }

        public async Task<IEnumerable<Agent>> GetAgents()
        {
            var result = (await db.Agents.ToListAsync());
            return result;
        }

        public async Task<bool> IsAgentAlreadyExist(string agentName, int? agentId = null)
        {
            var result = new Agent();
            if (agentId == null)
            {
                result = await db.Agents.FirstOrDefaultAsync(x => x.UserName.Replace(" ", string.Empty).ToLower().Trim()
                                                                                == agentName.Replace(" ", string.Empty).ToLower().Trim());
            }
            else
            {
                result = await db.Agents.FirstOrDefaultAsync(x => x.AgentId != agentId && x.UserName.Replace(" ", string.Empty).ToLower().Trim()
                                                                                == agentName.Replace(" ", string.Empty).ToLower().Trim());
            }

            return result == null ? false : true;
        }

        public async Task<Agent> CheckAgentOldPasswordCorrect(int agentId, string password)
        {
            var requestAgent = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == agentId && x.Password == password);
            return requestAgent;
        }

        public async Task<Agent> ChangeAndResetAgentPassword(Agent agent)
        {
            var requestAgent = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == agent.AgentId);
            if(requestAgent != null)
            {
                requestAgent.Password = agent.Password.Trim();
                db.Update(requestAgent);
                await db.SaveChangesAsync();
                return requestAgent;
            }
            else
            {
                return null;
            }
        }

        //public async Task<Agent> GetLoginAgent(string userName, string password)
        //{
        //    password = password == null ? password : password.EncryptPassword();
        //    var result = await db.Agents.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
        //    return result;
        //}

        //public async Task<Agent> LoginAgent(LoginUserData user)
        //{
        //    var result = await db.Agents.Where(x => x.AgentOrPlayer == AgentOrPlayerEnum.Agent && x.UserName.Trim() == user.UserName.Trim() && x.Password.Trim() == user.Password.Trim()).FirstOrDefaultAsync();
        //    return result;
        //}

        //public async Task<Agent> LoginPlayer(LoginUserData user)
        //{
        //    var result = await db.Agents.Where(x => x.AgentOrPlayer == AgentOrPlayerEnum.Player && x.UserName.Trim() == user.UserName.Trim() && x.Password.Trim() == user.Password.Trim()).FirstOrDefaultAsync();
        //    return result;
        //}

        public async Task<Agent> UpdateAgent(Agent agent)
        {
            var toUpdateAgent = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == agent.AgentId);
            if (toUpdateAgent != null)
            {
                toUpdateAgent.UserName = agent.UserName;
                toUpdateAgent.Mobile = agent.Mobile;
                toUpdateAgent.AgentCommissionMultiply = agent.AgentCommissionMultiply;
                toUpdateAgent.IsActive = agent.IsActive;
                toUpdateAgent.IsByOwner = agent.IsByOwner;
                toUpdateAgent.AgentOrPlayer = agent.AgentOrPlayer;
                toUpdateAgent.UpdatedDate = DateTime.UtcNow.AddMinutes(390);

                db.Agents.Update(toUpdateAgent);
                await db.SaveChangesAsync();

                return toUpdateAgent;
            }

            return null;
        }

        public async Task<Agent> UpdateAgentProfile(Agent agent)
        {
            var toUpdateAgent = await db.Agents.FirstOrDefaultAsync(x => x.AgentId == agent.AgentId);
            if (toUpdateAgent != null)
            {
                toUpdateAgent.UserName = agent.UserName;
                toUpdateAgent.Password = agent.Password;
                toUpdateAgent.Mobile = agent.Mobile;
                toUpdateAgent.AgentCommissionMultiply = agent.AgentCommissionMultiply;
                toUpdateAgent.Password = agent.Password;
                toUpdateAgent.IsActive = agent.IsActive;
                toUpdateAgent.IsByOwner = agent.IsByOwner;
                toUpdateAgent.UpdatedDate = DateTime.UtcNow.AddMinutes(390);

                db.Agents.Update(toUpdateAgent);
                await db.SaveChangesAsync();

                return toUpdateAgent;
            }

            return null;
        }
    }
}
