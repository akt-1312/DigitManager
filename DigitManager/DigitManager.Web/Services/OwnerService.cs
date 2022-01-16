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
    public class OwnerService : IOwnerService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public OwnerService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        protected async Task AssignAccessTokenToRequestHeader()
        {
            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync("api/owners");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Owner>>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.GetJsonAsync<Owner[]>();
            //return result;
        }

        public async Task<Owner> GetOwner(int id)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync("api/owners/" + id);
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Owner>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.GetJsonAsync<Owner>();
            //return result;
        }

        //public async Task<Owner> GetLoginOwner(string userName, string password)
        //{
        //    var result = await httpClient.GetJsonAsync<Owner>($"api/owners/loginowner?userName={userName}&password={password}");
        //    return result;

        //}

        public async Task<Owner> UpdateOwner(Owner owner)
        {
            var serializeOwner = JsonConvert.SerializeObject(owner);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/owners", new StringContent(serializeOwner, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Owner>(responseBody);
                return result;
            }
            return null;

            //var result = await httpClient.PutJsonAsync<Owner>(, owner);
            //return result;
        }

        public async Task<Owner> CheckOwnerOldPasswordCorrect(int ownerId, string password)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync($"owners/checkpassword?ownerId={ownerId}&password={password}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Owner>(responseBody);
                return result;
            }
            return null;
        }
        
        public async Task<Owner> ChangeOwnerPassword(Owner owner)
        {
            var serializeOwner = JsonConvert.SerializeObject(owner);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/owners/changepassword", new StringContent(serializeOwner, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Owner>(responseBody);
                return result;
            }
            return null;
        }
    }
}
