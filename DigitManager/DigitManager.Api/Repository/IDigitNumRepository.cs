using DigitManager.ModelLibrary;
using DigitManager.ModelLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Api.Repository
{
    public interface IDigitNumRepository
    {
        Task<IEnumerable<SubDigit>> GetAllDigit();
        //Task<List<SubDigit>> GetAllDigitGroupByAgent();
        Task<IEnumerable<SubDigit>> GetDigitForAgent(int agentId);

        Task<MainDigit> GetMainDigit(int mainDigitId);

        Task<IEnumerable<SubDigit>> GetSubDigitsWithRequestParams(ParamsForRequestSubDigit requestParams);

        Task<IEnumerable<MainDigit>> SaveDigitVoucher(List<MainDigit> mainDigits);

        Task<MainDigit> UpdateMainDigit(MainDigit mainDigit); 

        Task<string> DeleteVoucher(string voucherGuid);
        Task<MainDigit> DeleteMainDigit(int mainDigitId);
    }
}
