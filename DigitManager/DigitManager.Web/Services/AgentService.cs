using Blazored.LocalStorage;
using DigitManager.ModelLibrary;
using DigitManager.Web.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DigitManager.Web.Services
{
    public class AgentService : IAgentService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public AgentService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        protected async Task AssignAccessTokenToRequestHeader()
        {
            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<Agent> AddAgent(Agent agent)
        {
            var serializeAgent = JsonConvert.SerializeObject(agent);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PostAsync("api/agents", new StringContent(serializeAgent, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "Created")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
            //var result = await httpClient.PostJsonAsync<Agent>("api/agents", agent);
            //return result;
        }

        public async Task<Agent> DeleteAgent(int id)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.DeleteAsync($"api/agents/{id}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<Agent> GetAgent(int id)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync($"api/agents/{id}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.GetJsonAsync<Agent>();
            //return result;
        }

        public async Task<IEnumerable<Agent>> GetAgents()
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync("api/agents");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var agents = await Task.FromResult(JsonConvert.DeserializeObject<List<Agent>>(responseBody));
                return agents;
            }

            return null;
        }

        //public async Task<Agent> GetLoginAgent(string userName, string password)
        //{
        //    var result = await httpClient.GetJsonAsync<Agent>($"api/agents/loginagent?userName={userName}&password={password}");
        //    return result;
        //}

        public async Task<Agent> UpdateAgent(Agent agent)
        {
            var serializeAgent = JsonConvert.SerializeObject(agent);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/agents", new StringContent(serializeAgent, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.PutJsonAsync<Agent>(, agent);
            //return result;
        }

        public async Task<Agent> UpdateAgentProfile(Agent agent)
        {
            var serializeAgent = JsonConvert.SerializeObject(agent);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/agents/profile", new StringContent(serializeAgent, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.PutJsonAsync<Agent>(, agent);
            //return result;
        }

        public async Task<Agent> GetAgentProfile(int id)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync($"api/agents/profile/{id}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.GetJsonAsync<Agent>();
            //return result;
        }

        public async Task<Agent> CheckAgentOldPasswordCorrect(int agentId, string password)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync($"agents/checkpassword?agentId={agentId}&password={password}");
            if(response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
        }
        public async Task<Agent> ResetAgentPassword(Agent agent)
        {
            var serializeAgent = JsonConvert.SerializeObject(agent);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/agents/resetpassword", new StringContent(serializeAgent, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
        }
        public async Task<Agent> ChangeAgentPassword(Agent agent)
        {
            var serializeAgent = JsonConvert.SerializeObject(agent);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/agents/changepassword", new StringContent(serializeAgent, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
        }
    }
}
