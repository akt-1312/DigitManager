using DigitManager.ModelLibrary;
using DigitManager.ModelLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Services
{
    public interface IDigitService
    {
        Task<List<SubDigit>> GetAllDigit();
        //Task<List<SubDigit>> GetAllDigitGroupByAgent();
        Task<List<SubDigit>> GetDigitForAgent(int agentId);

        Task<List<SubDigit>> GetSubDigitsWithRequestParams(ParamsForRequestSubDigit requestParams);

        Task<List<MainDigit>> SaveDigitVoucher(List<MainDigit> mainDigits);

        Task<MainDigit> UpdateMainDigit(MainDigit mainDigit);

        Task<string> DeleteVoucher(string voucherGuid);
        Task<MainDigit> DeleteMainDigit(int mainDigitId);
    }
}
