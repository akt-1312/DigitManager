using Blazored.LocalStorage;
using DigitManager.ModelLibrary;
using DigitManager.ModelLibrary.ViewModels;
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
    public class DigitService : IDigitService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public DigitService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        protected async Task AssignAccessTokenToRequestHeader()
        {
            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        public async Task<MainDigit> DeleteMainDigit(int mainDigitId)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.DeleteAsync($"api/digitnum/delete/{mainDigitId}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MainDigit>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<string> DeleteVoucher(string voucherGuid)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.DeleteAsync($"api/digitnum/delete/voucher/{voucherGuid}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<string>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<List<SubDigit>> GetAllDigit()
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync("api/digitnum/getdigits");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<SubDigit>>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<List<SubDigit>> GetDigitForAgent(int agentId)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync($"api/digitnum/getdigits/agent/{agentId}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<SubDigit>>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<List<MainDigit>> SaveDigitVoucher(List<MainDigit> mainDigits)
        {
            await AssignAccessTokenToRequestHeader();
            var serializeMainDigit = JsonConvert.SerializeObject(mainDigits);
            var response = await httpClient.PostAsync("api/digitnum/adddigit", new StringContent(serializeMainDigit, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<MainDigit>>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<MainDigit> UpdateMainDigit(MainDigit mainDigit)
        {
            var serializeMainDigit = JsonConvert.SerializeObject(mainDigit);
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.PutAsync("api/digitnum/updatedigit", new StringContent(serializeMainDigit, Encoding.UTF8, "application/json"));
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MainDigit>(responseBody);
                return result;
            }
            return null;
        }

        public async Task<List<SubDigit>> GetSubDigitsWithRequestParams(ParamsForRequestSubDigit requestParams)
        {
            await AssignAccessTokenToRequestHeader();
            var response = await httpClient.GetAsync($"api/digitnum/getdigits/filtered?amOrPm={requestParams.AmOrPm}&intendedDate={requestParams.IntendedDate}&agentId={requestParams.AgentId}");
            if (response.StatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<SubDigit>>(responseBody);
                return result;
            }
            return null;
        }
    }
}
