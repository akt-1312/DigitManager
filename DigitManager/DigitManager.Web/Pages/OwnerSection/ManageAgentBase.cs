using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.ModelLibrary;
using DigitManager.Web.Services;
using DigitManager.Web.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using DigitManager.ModelLibrary.MainAndSubRelation;
using DigitManager.ModelLibrary.CryptoExtensions;
using System.Web.Http.ModelBinding;
using Blazored.LocalStorage;
using System.Text.RegularExpressions;

namespace DigitManager.Web.Pages.OwnerSection
{
    public class ManageAgentBase : ComponentBase
    {
        [Inject]
        public IAgentService agentService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public ILoginUserService LoginUserService { get; set; }

        public Agent Agent { get; set; } = new Agent();

        //public List<Agent> MainAgentList { get; set; } = new List<Agent>();

        public string MainAgentListString { get; set; } = "";

        public List<Agent> Agents { get; set; } = new List<Agent>();

        public bool IsActiveAgentList { get; set; } = true;

        public bool IsDisabledButton { get; set; }

        public bool IsTableTemplateFiltered { get; set; }

        public int? ToDeleteAgentId { get; set; }

        protected DeleteConfirmModal DeleteConfirmation { get; set; }
        protected AlertMessageDialogBox AlertMessageBox { get; set; }

        private string SearchedUserName { get; set; } = "";
        private string SearchedMobile { get; set; } = "";
        private string SearchedRole { get; set; } = "";
        private string SearchedCommissionRate { get; set; } = "";

        public string AgentDeleteConfirmMessage { get; set; } = "";

        public bool IsResetPasswordClick { get; set; }
        public string ResetPassword { get; set; }
        public string RequiredResetPassword { get; set; } = "";

        public bool IsLoading { get; set; } = true;

        protected override void OnInitialized()
        {
            IsActiveAgentList = true;
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var allAgents = (await agentService.GetAgents());
                if (allAgents == null)
                {
                    RefreshRequest refreshRequest = new RefreshRequest();
                    refreshRequest.AccessToken = await LocalStorage.GetItemAsync<string>("accessToken");
                    refreshRequest.RefreshToken = await LocalStorage.GetItemAsync<string>("refreshToken");

                    var userAgent = await LoginUserService.OwnerRefreshTokenAsync(refreshRequest);
                    if (userAgent != null)
                    {
                        await LocalStorage.SetItemAsync("accessToken", userAgent.AccessToken);
                        allAgents = await agentService.GetAgents();
                    }
                }
                allAgents = allAgents == null ? new List<Agent>() : allAgents.OrderBy(x => x.UserName).ToList();
                MainAgentListString = JsonConvert.SerializeObject(allAgents);
                Agents = allAgents.Where(x => x.IsActive && !x.IsByOwner).ToList();
                await Task.Delay(1000);
                IsLoading = false;
                await SetElementFocus();
                //StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public void ResetPasswordChange(ChangeEventArgs args)
        {
            string value = args.Value.ToString();
            CheckResetPasswordVaid(value);
        }

        public async Task ResetPasswordConfirm()
        {
            bool isValid = CheckResetPasswordVaid(ResetPassword);
            if (isValid)
            {
                Agent.Password = ResetPassword.EncryptPassword();
                var result = await agentService.ResetAgentPassword(Agent);
                if (result != null)
                {
                    string infoMessage = $"Agent name ( {Agent.UserName} ) of password reset is successful!";
                    await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
                    CancelResetPassword();
                }
                else
                {
                    Agent.Password = null;
                    string infoMessage = $"Cannot reset password of Agent ( {Agent.UserName} )! Error.";
                    await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                }
            }
        }

        protected bool CheckResetPasswordVaid(string inputString)
        {
            inputString = inputString ?? "";
            if (!string.IsNullOrWhiteSpace(inputString.Trim()))
            {
                Regex re = new Regex(@"^([A-Za-z0-9]{4,30})*$", RegexOptions.IgnoreCase);
                if (!re.IsMatch(inputString.Trim()))
                {
                    RequiredResetPassword = "Not allow whitespace and special characters. Must be between 4 and 30 characters.";
                    return false;
                }
                else
                {
                    RequiredResetPassword = "";
                    return true;
                }
            }
            else
            {
                RequiredResetPassword = "Please Enter New Password";
                return false;
            }
        }

        public void CancelResetPassword()
        {
            ResetPassword = "";
            RequiredResetPassword = "";
            IsResetPasswordClick = false;
            Agent = new Agent();
        }

        public void ShowResetPasswordBox()
        {
            ResetPassword = "";
            RequiredResetPassword = "";
            IsResetPasswordClick = true;
        }

        protected async Task ValidateAgent()
        {
            IsDisabledButton = true;
            bool isAgentExist;
            if (Agent.AgentId == 0)
            {
                isAgentExist = JsonConvert.DeserializeObject<List<Agent>>(MainAgentListString).ToList()
                                .Where(x => x.UserName.StringCompareFormat() == Agent.UserName.StringCompareFormat()).ToList().Count > 0;
            }
            else
            {
                isAgentExist = JsonConvert.DeserializeObject<List<Agent>>(MainAgentListString).ToList()
                                .Where(x => x.AgentId != Agent.AgentId && x.UserName.StringCompareFormat() == Agent.UserName.StringCompareFormat()).ToList().Count > 0;
            }
            if (isAgentExist)
            {
                string alertMessage = $"Agent name {Agent.UserName} already exist. Please choose another name!";
                await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
            }
            else
            {
                if (Agent.AgentId == 0)
                {

                    var agentAsString = JsonConvert.SerializeObject(Agent);
                    var agent = JsonConvert.DeserializeObject<Agent>(agentAsString);
                    agent.Password = agent.Password.Trim().EncryptPassword();
                    var result = await agentService.AddAgent(agent);
                    if (result != null)
                    {
                        var allAgents = (await agentService.GetAgents()).OrderBy(x => x.UserName).ToList();
                        MainAgentListString = JsonConvert.SerializeObject(allAgents);
                        Agents = allAgents;
                        string infoMessage = $"Agent name ( {Agent.UserName} ) Created Successfully";
                        await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
                        await ResetFormInitialization();
                    }
                    else
                    {
                        string alertMessage = "Cannot create agent. Server Error.";
                        await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                    }
                }
                else
                {

                    var agent = await agentService.UpdateAgent(Agent);
                    if (agent != null)
                    {
                        var allAgents = (await agentService.GetAgents()).OrderBy(x => x.UserName).ToList();
                        MainAgentListString = JsonConvert.SerializeObject(allAgents);
                        Agents = allAgents;
                        string infoMessage = $"Agent name ( {Agent.UserName} ) Updated Successfully";
                        await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
                        await ResetFormInitialization();
                    }
                    else
                    {
                        string alertMessage = "Cannot update agent. Server Error.";
                        await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                    }
                }
            }

            IsDisabledButton = false;
        }

        protected void EditButton_Click(Agent agent)
        {
            CancelResetPassword();
            ToDeleteAgentId = null;
            string searilizedAgent = JsonConvert.SerializeObject(agent);
            Agent = JsonConvert.DeserializeObject<Agent>(searilizedAgent);
            //Agents = GetAgentsAccordingIsActiveOrNot();
            //Agents.Remove(Agents.FirstOrDefault(x => x.AgentId == agent.AgentId));

            //StateHasChanged();
        }

        protected async Task CancelButton_Click()
        {
            //ClearAllSearchedTexbox();
            await ResetFormInitialization();
            await SetElementFocus();
        }

        protected void ClearAllSearchedTexbox()
        {
            SearchedUserName = "";
            SearchedMobile = "";
            SearchedRole = "";
            SearchedCommissionRate = "";
        }

        private async Task ResetFormInitialization()
        {
            Agent = new Agent();
            Agents = GetAgentsAccordingIsActiveOrNot();
            //await SetInputEmpty("txtSearchedGridView");
            await SetElementFocus();
        }

        private List<Agent> GetAgentsAccordingIsActiveOrNot()
        {
            var allAgents = JsonConvert.DeserializeObject<List<Agent>>(MainAgentListString);
            var result = allAgents.Where(x => !x.IsByOwner && x.IsActive == IsActiveAgentList && x.UserName.StringCompareFormat().Contains(SearchedUserName.StringCompareFormat())
                        && x.Mobile.StringCompareFormat().Contains(SearchedMobile.StringCompareFormat())
                        && x.AgentOrPlayer.ToString().StringCompareFormat().Contains(SearchedRole)
                        && x.AgentCommissionMultiply.ToString().StringCompareFormat().Contains(SearchedCommissionRate)).OrderBy(x => x.UserName).ToList();
            return result;
        }

        protected async Task IsActiveAgentList_Click(ChangeEventArgs args)
        {
            ClearAllSearchedTexbox();
            await SetInputEmpty("txtSearchedGridView");
            await ResetFormInitialization();
            //Agents = GetAgentsAccordingIsActiveOrNot();
        }

        protected void Delete_Click(int toDeleteAgentId)
        {
            CancelResetPassword();
            ToDeleteAgentId = toDeleteAgentId;
            var agent = Agents.FirstOrDefault(x => x.AgentId == toDeleteAgentId);
            AgentDeleteConfirmMessage = $"Are you sure to delete agent ( {agent.UserName} ).";
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            IsDisabledButton = true;
            if (deleteConfirmed)
            {
                if (ToDeleteAgentId != null && ToDeleteAgentId.Value != 0)
                {
                    var result = await agentService.DeleteAgent(ToDeleteAgentId.Value);
                    if (result != null)
                    {
                        var allAgents = (await agentService.GetAgents()).OrderBy(x => x.UserName).ToList();
                        MainAgentListString = JsonConvert.SerializeObject(allAgents);
                        Agents = allAgents;
                        string infoMessage = $"Agent name ( {result.UserName} ) Deleted Successfully";
                        await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
                    }
                    else
                    {
                        string alertMessage = "Cannot delete agent.";
                        await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                    }
                }
                else
                {
                    string alertMessage = $"Cannot find Agent who you currently trying to delete.";
                    await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                }
            }
            ToDeleteAgentId = null;

            await ResetFormInitialization();
            IsDisabledButton = false;
        }


        protected void OnAgentSearchTextChange(ChangeEventArgs args, string columnName)
        {
            CancelResetPassword();
            string searchedText = args.Value.ToString();
            IsTableTemplateFiltered = true;

            if (columnName == "UserName")
            {
                SearchedUserName = searchedText.StringCompareFormat();
                Agents = GetAgentsAccordingIsActiveOrNot().Where(x => x.AgentId != Agent.AgentId &&
                x.UserName.StringCompareFormat().Contains(SearchedUserName)).ToList();
            }
            if (columnName == "Mobile")
            {
                SearchedMobile = searchedText.StringCompareFormat();
                Agents = GetAgentsAccordingIsActiveOrNot().Where(x => x.AgentId != Agent.AgentId &&
                x.Mobile.StringCompareFormat().Contains(SearchedMobile)).ToList();
            }

            if (columnName == "CommissionRate")
            {
                SearchedCommissionRate = searchedText.StringCompareFormat();
                Agents = GetAgentsAccordingIsActiveOrNot().Where(x => x.AgentId != Agent.AgentId &&
                x.AgentCommissionMultiply.Value.ToString().StringCompareFormat().Contains(SearchedCommissionRate)).ToList();
            }
            if (columnName == "Role")
            {
                SearchedRole = searchedText.StringCompareFormat();
                Agents = GetAgentsAccordingIsActiveOrNot().Where(x => x.AgentId != Agent.AgentId &&
                x.AgentOrPlayer.ToString().StringCompareFormat().Contains(SearchedRole)).ToList();
            }
        }

        public async Task SetElementFocus()
        {
            StateHasChanged();
            await JSRuntime.InvokeVoidAsync("SetElementFocusWithId", "txtDefaultFocusInput");
        }

        public async Task SetInputEmpty(string className)
        {
            await JSRuntime.InvokeVoidAsync("SetInputEmpty", className);
        }

        protected void OnSearchingFinished(bool isSearchingFinished)
        {
            IsTableTemplateFiltered = isSearchingFinished;
        }       

        public void OnRoleSelectChange(ChangeEventArgs args)
        {
            string role = args.Value.ToString();
            if (!string.IsNullOrWhiteSpace(role) && Enum.TryParse(role, out AgentOrPlayerEnum agentOrPlayer))
            {
                if (agentOrPlayer == AgentOrPlayerEnum.Player)
                {
                    Agent.AgentCommissionMultiply = 0f;
                }
            }
        }
    }
}
