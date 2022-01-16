using DigitManager.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Repository
{
    public interface IAgentRepository
    {
        Task<IEnumerable<Agent>> GetAgents();
        Task<Agent> GetAgent(int id);
        Task<Agent> GetAgentProfile(int id);
        Task<bool> IsAgentAlreadyExist(string agentName, int? agentId = null);
       // Task<Agent> GetLoginAgent(string userName, string password);
        Task<Agent> AddAgent(Agent agent);
        Task<Agent> UpdateAgent(Agent agent);
        Task<Agent> UpdateAgentProfile(Agent agent);
        Task<Agent> DeleteAgent(int id);
        Task<Agent> CheckAgentOldPasswordCorrect(int agentId, string password);
        Task<Agent> ChangeAndResetAgentPassword(Agent agent);
        //Task<Agent> LoginAgent(LoginUserData user);
        //Task<Agent> LoginPlayer(LoginUserData user);
    }
}
