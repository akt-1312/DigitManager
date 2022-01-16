using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.ModelLibrary.MainAndSubRelation;
using Newtonsoft.Json;
using DigitManager.ModelLibrary;
using DigitManager.Web.Services.TableChangeService;
using TableDependency.SqlClient.Base.Enums;
using DigitManager.Web.Services;
using DigitManager.ModelLibrary.ViewModels;
using DigitManager.Web.Shared;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using System.Text.RegularExpressions;
using DigitManager.Web.ExtensionWeb;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.AspNetCore.Authorization;

namespace DigitManager.Web.Pages.OwnerSection
{
    [Authorize(Roles = "Owner")]
    public class OwnerPageBase : ComponentBase, IDisposable
    {

        [Inject]
        private IDigitService digitService { get; set; }

        [Inject]
        private IOwnerService ownerService { get; set; }

        [Inject]
        public IAgentService agentService { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public OwnerViewModel stringToMainDigitVm { get; set; } = new OwnerViewModel();

        protected Owner Owner = new Owner();

        private Dictionary<string, int> NumAndPrice { get; set; } = new Dictionary<string, int>();

        public Dictionary<string, int> NormalNumAndPrice { get; set; } = new Dictionary<string, int>();

        public Dictionary<string, int> OverNumAndPrice { get; set; } = new Dictionary<string, int>();

        public List<MainDigit> MainDigitsSelling { get; set; } = new List<MainDigit>();

        public List<MainDigit> MainDigitsToUpdDel { get; set; } = new List<MainDigit>();

        public bool IsLoadingData { get; set; } = false;

        public bool IsProcessingAction { get; set; } = false;

        public DateTime IntendedDate { get; set; }

        public TimeAMOrPM TimeAMPM { get; set; }

        public int AgentId { get; set; }

        public List<Agent> Agents { get; set; } = new List<Agent>();

        public List<Agent> AllAgents { get; set; } = new List<Agent>();

        public List<Agent> AgentsByOwnerSelf { get; set; } = new List<Agent>();

        public int MultiplyRate { get; set; }

        public long TotalAmmount { get; set; }

        public int CommissionAmmount { get; set; }

        public string CommissionPercentage { get; set; } = "";

        public int OverAmmount { get; set; }

        public long NetAmmount { get; set; }

        public int AgentIdToSell { get; set; }

        public int MaxAmmountToPlay { get; set; }

        public ElementReference InputToFocus { get; set; }

        public ElementReference ddlToSellAgent { get; set; }

        public string ShortcutString = "";

        public string ShortcutStringErrorMessage { get; set; } = "";

        public bool IsShortcutStringValid { get; set; } = true;

        public VoucherUpdateDelete VoucherUpdateDelete { get; set; }

        //protected DeleteConfirmModal DeleteConfirmation { get; set; }
        protected AlertMessageDialogBox AlertMessageBox { get; set; }
        protected ShortcutGuide ShortcutGuide { get; set; }
        protected AgentForOwnerSelf AgentCreateModal { get; set; }
        protected SearchedSpecificNum SearchedSpecificNum { get; set; }

        private ParamsForRequestSubDigit RequestParam { get; set; } = new ParamsForRequestSubDigit();

        private IList<SubDigit> SubDigits { get; set; } = new List<SubDigit>();

        public List<SubDigit> SearchedSubdigits { get; set; } = new List<SubDigit>();

        public string SearchedNum { get; set; } = "";

        private bool IsFetchingDigits { get; set; }

        private string AlertMessage { get; set; } = "";

        public bool IsShowKeypad { get; set; }

        [Inject]
        private ITableChangeBroadcastService TableChangeService { get; set; }

        // store all the actions you want to run **once** after rendering
        public List<Action> actionsToRunAfterRender = new List<Action>();

        /// <summary>
        /// Run an action once after the component is rendered
        /// </summary>
        /// <param name="action">Action to invoke after render</param>
        public void RunAfterRender(Action action) => actionsToRunAfterRender.Add(action);

        protected override async Task OnInitializedAsync()
        {
            IsLoadingData = true;
            Owner = (await ownerService.GetOwners()).FirstOrDefault();
            Owner = Owner ?? new Owner();
            MaxAmmountToPlay = Owner.DefaultMaxAmmountToPlay;
            IntendedDate = DateTime.UtcNow.AddMinutes(390);
            TimeAMPM = (DateTime.UtcNow.AddMinutes(390).ToString("tt", CultureInfo.InvariantCulture).ToUpper()) == "AM" ? TimeAMOrPM.Morning : TimeAMOrPM.Evening;
            MultiplyRate = Owner.LuckyMultiply;
            NumAndPrice = DefaultAllTwoNum.ListOfNum();
            RequestParam = new ParamsForRequestSubDigit
            {
                IntendedDate = IntendedDate,
                AgentId = AgentId,
                AmOrPm = TimeAMPM
            };
            await LoadAllAgents();
            SubDigits = await digitService.GetSubDigitsWithRequestParams(RequestParam);
            LoadData();
            this.TableChangeService.OnTwoDShortcutChanged += this.SubDigitsChanged;
            IsLoadingData = false;
            FocusInput();
            await base.OnInitializedAsync();
        }

        public void OnDbClickTwoNum(string twoNum)
        {
            SearchedNum = twoNum;
            SearchedSpecificNum.Show();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (SubDigits == null)
                {
                    AlertMessage = "Error retrieving data!";
                    await AlertMessageBox.ShowOrHideDialogBox(AlertMessage, true, true);
                }
            }
            foreach (var actionToRun in actionsToRunAfterRender)
            {
                actionToRun();
            }
            // clear the actions to make sure the actions only run **once**
            actionsToRunAfterRender.Clear();
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task OnChangeActionRelativeToSubDigit()
        {
            IsProcessingAction = true;
            await LoadServiceData();
            LoadData();
            IsProcessingAction = false;
        }

        public void OnMaxAmmountChange(ChangeEventArgs args)
        {
            string value = args.Value.ToString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (int.TryParse(value, out int maxAmmountToPlay))
                {
                    MaxAmmountToPlay = maxAmmountToPlay;
                    LoadData();
                }
            }
        }

        // The event handler, will update the HTML view according to new stock value
        private async void SubDigitsChanged(object sender, SubDigitChangeChangeEventArgs args)
        {
            //if (!IsFetchingDigits)
            //{
            await SubDigitChangeReRenderFunction();

            await InvokeAsync(() =>
            {
                base.StateHasChanged();
            });
            //IsFetchingDigits = false;
            //}
        }



        protected async Task SubDigitChangeReRenderFunction()
        {
            //IsFetchingDigits = true;
            await LoadServiceData();
            LoadData();
            //await InvokeAsync(() =>
            //{
            //    base.StateHasChanged();
            //});
        }

        protected async Task LoadServiceData()
        {
            ParamsForRequestSubDigit requestParams = new ParamsForRequestSubDigit
            {
                IntendedDate = IntendedDate,
                AgentId = AgentId,
                AmOrPm = TimeAMPM
            };
            SubDigits = await digitService.GetSubDigitsWithRequestParams(requestParams);
        }

        protected void LoadData()
        {
            if (SubDigits != null)
            {
                Dictionary<string, int> dicNewNumPrice = new Dictionary<string, int>();
                dicNewNumPrice = DefaultAllTwoNum.ListOfNum();
                var realDic = SubDigits.GroupBy(x => x.TwoNum).ToDictionary(y => y.Key, y => y.Sum(z => z.Ammount));
                NumAndPrice = dicNewNumPrice.Concat(realDic).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.Sum(val => val.Value));

                NormalNumAndPrice = NumAndPrice.Select(x => new
                {
                    Num = x.Key,
                    Price = x.Value <= MaxAmmountToPlay ? x.Value : MaxAmmountToPlay
                }).ToDictionary(x => x.Num, x => x.Price);

                OverNumAndPrice = NumAndPrice.Where(x => x.Value > MaxAmmountToPlay).OrderByDescending(x => x.Value).Select(x => new
                {
                    Num = x.Key,
                    Price = x.Value - MaxAmmountToPlay
                }).ToDictionary(x => x.Num, x => x.Price);

                TotalAmmount = NumAndPrice.Sum(x => x.Value);
                var CommissionRealDic = SubDigits.Where(a => a.MainDigit.Agent.AgentOrPlayer == AgentOrPlayerEnum.Agent).ToList()
                    .GroupBy(x => x.TwoNum).ToDictionary(y => y.Key, y => y.Sum(z => z.Ammount));
                long TotalCommissionAmmount = CommissionRealDic.Sum(x => x.Value);
                OverAmmount = OverNumAndPrice.Sum(x => x.Value);

                var activeNowAgents = SubDigits.GroupBy(x => x.MainDigit.AgentId).Select(x => x.Key).Select(x => new
                {
                    agent = SubDigits.Where(y => y.MainDigit.AgentId == x).Select(a => a.MainDigit.Agent).FirstOrDefault()
                }).Select(x => x.agent).ToList();
                float allPercentage = 0f;

                List<string> lstCommissionPercentage = activeNowAgents.Where(x => x.AgentOrPlayer == AgentOrPlayerEnum.Agent).OrderByDescending(o => o.AgentCommissionMultiply).Select(y => y.AgentCommissionMultiply.Value.ToString("0.##")).Distinct().ToList();
                lstCommissionPercentage = lstCommissionPercentage.Count > 0 ? lstCommissionPercentage : new List<string> { "0" };
                CommissionPercentage = String.Join("/", lstCommissionPercentage) + " %";
                if (activeNowAgents.Count > 0)
                {
                    //if (activeNowAgents.Where(y => y.AgentOrPlayer == AgentOrPlayerEnum.Agent).ToList().Count > 0)
                    //{
                    //    allPercentage = activeNowAgents.Where(p => p.AgentOrPlayer == AgentOrPlayerEnum.Agent).Sum(x => x.AgentCommissionMultiply.Value) / activeNowAgents.Where(y => y.AgentOrPlayer == AgentOrPlayerEnum.Agent).ToList().Count;
                    //    //allPercentage = activeNowAgents.Sum(x => x.AgentCommissionMultiply.Value) / activeNowAgents.Count;

                    //}
                    //else
                    //{
                    //    allPercentage = 0f;
                    //}
                    
                    //List<string> lstCommissionPercentage = activeNowAgents.Where(x => x.AgentOrPlayer == AgentOrPlayerEnum.Agent).Select( y=> new { commission = y.AgentCommissionMultiply.Value.ToString() }).ToList();
                    //CommissionPercentage = allPercentage.ToString("0.##") + " %";

                    var commissionByMultiply = SubDigits.GroupBy(x => x.MainDigit.Agent.AgentCommissionMultiply).ToDictionary(y => y.Key.Value, y => y.Sum(s=> s.Ammount));
                    CommissionAmmount = commissionByMultiply.Sum(x => (int)Math.Round((x.Value * x.Key) / 100));
                }
                else
                {
                    var choosedAgentCommission = Agents.Where(x => x.AgentId == AgentId).FirstOrDefault();
                    allPercentage = choosedAgentCommission == null ? 0f : choosedAgentCommission.AgentCommissionMultiply.Value;
                    CommissionPercentage = allPercentage.ToString("0.##") + " %";
                    CommissionAmmount = 0;
                }
                //CommissionPercentage = allPercentage.ToString("0.##") + " %";

                //CommissionAmmount = (int)Math.Round((TotalCommissionAmmount * allPercentage) / 100);
                //CommissionAmmount = (int)Math.Round((TotalAmmount * allPercentage) / 100);
                NetAmmount = TotalAmmount - (CommissionAmmount + OverAmmount);

                List<MainDigit> mainDigits = new List<MainDigit>();
                MainDigitsToUpdDel = SubDigits.Where(x => x.MainDigit.Agent.IsByOwner).GroupBy(x => x.MainDigitId).Distinct().Select(x => new
                {
                    main = SubDigits.Where(s => s.MainDigitId == x.Key).Select(x => x.MainDigit).FirstOrDefault()
                }).Select(x => x.main).ToList();

                SearchedSubdigits = SubDigits.ToList();
            }
            else
            {
                NormalNumAndPrice = DefaultAllTwoNum.ListOfNum();
                MainDigitsToUpdDel = new List<MainDigit>();
                SearchedSubdigits = new List<SubDigit>();
            }
        }

        public async Task LoadDataAfterClientChangeEventOccur()
        {
            IsProcessingAction = true;
            IsFetchingDigits = true;
            await LoadServiceData();
            LoadData();
            IsProcessingAction = false;
            StateHasChanged();
        }

        public async Task OnSellingInputChange(KeyboardEventArgs args)
        {
            if (args.Key == "F2")
            {
                await SaveSellingNum();
            }
            if (args.Key == "Enter")
            {
                OnSellingAdded();
            }

        }

        public void OnSellingAdded()
        {
            ShortcutString = ShortcutString.StringCompareFormat();
            if (!string.IsNullOrWhiteSpace(ShortcutString))
            {
                Regex re = new Regex(NumStringValidateRegex.regexNumStringValidateRegex, RegexOptions.IgnoreCase);
                if (re.IsMatch(ShortcutString))
                {
                    OwnerViewModel viewModel = new OwnerViewModel()
                    {
                        IntendedDate = IntendedDate,
                        AgentId = AgentIdToSell,
                        TimeAmPM = TimeAMPM
                    };
                    MainDigit mainDigit = new MainDigit();
                    mainDigit = ShortcutString.GetMainDigitByNumString(viewModel);
                    if (mainDigit.ShortcutType != ShortKey.WrongTyping)
                    {
                        MainDigitsSelling.Insert(0, mainDigit);
                        ShortcutString = "";
                        ShortcutStringErrorMessage = "";
                        IsShortcutStringValid = true;
                    }
                    else
                    {
                        ShortcutStringErrorMessage = "Input is not valid!";
                        IsShortcutStringValid = false;
                    }
                }
                else
                {
                    ShortcutStringErrorMessage = "Input is not valid!";
                    IsShortcutStringValid = false;
                }
            }
            FocusInput();
        }

        public async Task SaveSellingNum()
        {
            if (MainDigitsSelling != null && MainDigitsSelling.Count > 0 && AgentIdToSell > 0)
            {
                IsProcessingAction = true;
                try
                {
                    MainDigitsSelling = MainDigitsSelling.Select(x => { x.AgentId = AgentIdToSell; return x; }).ToList();
                    var result = await digitService.SaveDigitVoucher(MainDigitsSelling);
                    if (result != null)
                    {
                        MainDigitsSelling = new List<MainDigit>();
                        AlertMessage = "Save Successful!";
                        await AlertMessageBox.ShowOrHideDialogBox(AlertMessage, true, false);
                        ShortcutStringErrorMessage = "";
                        IsShortcutStringValid = true;
                    }
                    else
                    {
                        AlertMessage = "Error saving data!";
                        await AlertMessageBox.ShowOrHideDialogBox(AlertMessage, true, true);
                    }
                }
                catch (Exception)
                {
                    AlertMessage = "Error saving data!";
                    await AlertMessageBox.ShowOrHideDialogBox(AlertMessage, true, true);
                }
                IsProcessingAction = false;
            }
            else
            {
                if (AgentIdToSell <= 0)
                {
                    ShortcutStringErrorMessage = "Please choose name!";
                    IsShortcutStringValid = false;
                    await JSRuntime.FocusAsync(ddlToSellAgent);
                    StateHasChanged();
                }
                else
                {
                    ShortcutStringErrorMessage = "No data to save!";
                    IsShortcutStringValid = false;
                }
            }
        }

        public void OnVoucherBookClick()
        {
            VoucherUpdateDelete.Show();
        }

        public async Task OnVoucherUpdateCallBack(bool isSuccess)
        {
            if (isSuccess)
            {
                string infoMessage = "Update Successful!";
                await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
            }
            else
            {
                string warningMessage = "Error Updating Data!";
                await AlertMessageBox.ShowOrHideDialogBox(warningMessage, true, true);
            }
        }

        public async Task OnVoucherDeleteCallBack(bool isSuccess)
        {
            if (isSuccess)
            {
                string infoMessage = "Delete Successful!";
                await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
            }
            else
            {
                string warningMessage = "Error Deleting Data!";
                await AlertMessageBox.ShowOrHideDialogBox(warningMessage, true, true);
            }
        }

        public void OnVoucherUpdDelClose(bool isClose)
        {
            if (isClose)
            {
                FocusInput();
            }
        }

        public void OnSellingAgentChange()
        {
            if (AgentIdToSell != 0)
            {
                FocusInput();
            }
        }

        public void RemoveSellingMainDigit(MainDigit mainDigit)
        {
            if (MainDigitsSelling != null && MainDigitsSelling.Count > 0)
            {
                MainDigitsSelling.Remove(mainDigit);
            }
            FocusInput();
        }

        public void EditSellingMainDigit(MainDigit mainDigit)
        {
            if (MainDigitsSelling != null && MainDigitsSelling.Count > 0)
            {
                ShortcutString = mainDigit.GetOriginalString();
                MainDigitsSelling.Remove(mainDigit);
            }
            FocusInput();
        }

        public void CloseInvalidShortcutStringMessage()
        {
            ShortcutStringErrorMessage = "";
            IsShortcutStringValid = true;
            FocusInput();
        }

        public void OnSellingInputClear()
        {
            ShortcutString = "";
            FocusInput();
            StateHasChanged();
        }

        private void FocusInput()
        {
            RunAfterRender(() => JSRuntime.InvokeVoidAsync("SetElementFocus", InputToFocus));
            //await JSRuntime.InvokeVoidAsync("SetElementFocus", InputToFocus);
            //StateHasChanged();
        }

        protected void ShowShortcutInfoGuideModal()
        {
            ShortcutGuide.Show();
        }

        protected void ShowAgentCreateModal()
        {
            AgentCreateModal.Show();
        }

        public async Task OnAddAgentCallBack(Dictionary<bool, string> dicStatus)
        {
            bool isSuccess = dicStatus.FirstOrDefault().Key;
            string message = dicStatus.FirstOrDefault().Value;
            if (isSuccess)
            {
                await AlertMessageBox.ShowOrHideDialogBox(message, true, false);
                await LoadAllAgents();
            }
            else
            {
                await AlertMessageBox.ShowOrHideDialogBox(message, true, true);
            }
        }

        public async Task OnUpdateAgentCallBack(Dictionary<bool, string> dicStatus)
        {
            bool isSuccess = dicStatus.FirstOrDefault().Key;
            string message = dicStatus.FirstOrDefault().Value;
            if (isSuccess)
            {
                await AlertMessageBox.ShowOrHideDialogBox(message, true, false);
                await LoadAllAgents();
            }
            else
            {
                await AlertMessageBox.ShowOrHideDialogBox(message, true, true);
            }
        }

        public async Task OnDeleteAgentCallBack(Dictionary<bool, string> dicStatus)
        {
            bool isSuccess = dicStatus.FirstOrDefault().Key;
            string message = dicStatus.FirstOrDefault().Value;
            if (isSuccess)
            {
                await AlertMessageBox.ShowOrHideDialogBox(message, true, false);
                await LoadAllAgents();
            }
            else
            {
                await AlertMessageBox.ShowOrHideDialogBox(message, true, true);
            }
        }

        private async Task LoadAllAgents()
        {
            var agents = await agentService.GetAgents();
            AllAgents = agents != null ? agents.OrderBy(x => x.UserName).ToList() : new List<Agent>();
            Agents = agents != null ? agents.Where(x => x.IsActive).OrderBy(x => x.UserName).ToList() : new List<Agent>();
            AgentsByOwnerSelf = agents != null ? agents.Where(x => x.IsActive && x.IsByOwner).OrderBy(x => x.UserName).ToList() : new List<Agent>();
        }

        public void Dispose()
        {
            this.TableChangeService.OnTwoDShortcutChanged -= this.SubDigitsChanged;
            Console.WriteLine("Disposed");
        }
    }
}
