using DigitManager.ModelLibrary;
using DigitManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Services
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAgents();
        Task<Agent> GetAgent(int id);
        Task<Agent> GetAgentProfile(int id);
        //Task<Agent> GetLoginAgent(string userName, string password);
        Task<Agent> AddAgent(Agent agent);
        Task<Agent> UpdateAgent(Agent agent);
        Task<Agent> UpdateAgentProfile(Agent agent);
        Task<Agent> DeleteAgent(int id);

        Task<Agent> CheckAgentOldPasswordCorrect(int agentId, string password);
        Task<Agent> ResetAgentPassword(Agent agent);
        Task<Agent> ChangeAgentPassword(Agent agent);
        //Task<UserAgent> LoginAgent(LoginUserData user);
        //Task<UserAgent> LoginPlayer(LoginUserData user);
    }
}
