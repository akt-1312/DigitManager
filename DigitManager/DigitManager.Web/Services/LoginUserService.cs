using DigitManager.ModelLibrary;
using DigitManager.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigitManager.Web.Services
{
    public class LoginUserService : ILoginUserService
    {
        private readonly HttpClient httpClient;

        public LoginUserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserOwner> LoginOwner(LoginUserData user)
        {
            var serializeUser = JsonConvert.SerializeObject(user);
            var response = await httpClient.PostAsync("api/digitmanager/login/owner", new StringContent(serializeUser, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserOwner>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.PostJsonAsync<Owner>(, user);
            //return result;
        }

        public async Task<UserAgent> LoginAgent(LoginUserData user)
        {
            var serializeUser = JsonConvert.SerializeObject(user);
            var response = await httpClient.PostAsync("api/digitmanager/login/agent", new StringContent(serializeUser, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserAgent>(responseBody);
                return result;
            }
            return null;
            //var result = await httpClient.PostJsonAsync<Agent>("api/digitmanager/login/agent", user);
            //return result;
        }

        public async Task<UserAgent> LoginPlayer(LoginUserData user)
        {
            var serializeUser = JsonConvert.SerializeObject(user);
            var response = await httpClient.PostAsync("api/digitmanager/login/player", new StringContent(serializeUser, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserAgent>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.PostJsonAsync<Agent>(, user);
            //return result;
        }

        public async Task<Agent> GetValidateAgent(string userName)
        {
            var response = await httpClient.GetAsync($"api/digitmanager/validate/agent/{userName}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<Agent> GetValidatePlayer(string userName)
        {
            var response = await httpClient.GetAsync($"api/digitmanager/validate/player/{userName}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Agent>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<UserAgent> AgentRefreshTokenAsync(RefreshRequest refreshRequest)
        {
            var serializeRefreshRequest = JsonConvert.SerializeObject(refreshRequest);
            var response = await httpClient.PostAsync("api/digitmanager/agent/refreshtoken", new StringContent(serializeRefreshRequest, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserAgent>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<UserOwner> OwnerRefreshTokenAsync(RefreshRequest refreshRequest)
        {
            var serializeRefreshRequest = JsonConvert.SerializeObject(refreshRequest);
            var response = await httpClient.PostAsync("api/digitmanager/owner/refreshtoken", new StringContent(serializeRefreshRequest, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserOwner>(responseBody);
                return result;
            }
            return null;
        }
    }
}
