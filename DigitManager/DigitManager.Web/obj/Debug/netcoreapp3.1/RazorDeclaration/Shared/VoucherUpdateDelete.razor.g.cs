// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace DigitManager.Web.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.Web.ExtensionWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using BlazorPro.Spinkit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.ModelLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.ModelLibrary.CryptoExtensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\VoucherUpdateDelete.razor"
using DigitManager.ModelLibrary.MainAndSubRelation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\VoucherUpdateDelete.razor"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\VoucherUpdateDelete.razor"
using DigitManager.ModelLibrary.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\VoucherUpdateDelete.razor"
using DigitManager.Web.Services;

#line default
#line hidden
#nullable disable
    public partial class VoucherUpdateDelete : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 250 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\VoucherUpdateDelete.razor"
       
    [Inject]
    private IJSRuntime JSRuntime { get; set; }

    [Inject]
    private IDigitService digitService { get; set; }

    [Parameter]
    public EventCallback<bool> OnUpdateProcessed { get; set; }

    [Parameter]
    public EventCallback<bool> OnDeleteProcessed { get; set; }

    [Parameter]
    public EventCallback<bool> OnClosedProcessed { get; set; }

    [Parameter]
    public List<MainDigit> MainDigitListToUpdDel { get; set; }

    public List<MainDigit> ToShowUpdDelMainDigits { get; set; }

    private string EditNumString { get; set; } = "";

    private ElementReference txtEditNumString { get; set; }

    private ElementReference btnDeleteSubmit { get; set; }

    private bool IsDeleteClick { get; set; }

    private string DeleteConfirmationMessage { get; set; } = "";

    private bool IsProcessing { get; set; }

    [Parameter]
    public List<Agent> Agents { get; set; }

    private int AgentId { get; set; }

    private MainDigit EditMainDigit { get; set; } = new MainDigit();

    private MainDigit DeleteMainDigit { get; set; } = new MainDigit();

    public ShortKey ShortKey { get; set; } = ShortKey.WrongTyping;

    private string SearchedString { get; set; }

    private string EditNumStringErrorMessage { get; set; } = "";

    public Dictionary<Agent, List<MainDigit>> DicMainDigitGroupByAgent { get; set; } = new Dictionary<Agent, List<MainDigit>>();

    public bool ShowUpdateDeleteVoucherModal { get; set; }

    private List<Action> actionsToRunAfterRender { get; set; } = new List<Action>();
    private void RunAfterRender(Action action) => actionsToRunAfterRender.Add(action);

    protected override void OnParametersSet()
    {
        ReloadMainDigits();
        StateHasChanged();
        base.OnParametersSet();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        foreach (var action in actionsToRunAfterRender)
        {
            action();
        }
        actionsToRunAfterRender.Clear();
        base.OnAfterRender(firstRender);
    }

    protected void SelectAgentChange()
    {
        ReloadMainDigits();
        ClearEditString();
        StateHasChanged();
    }

    protected void SearchMainDigits(ChangeEventArgs args)
    {
        var value = args.Value.ToString();
        SearchedString = value.Trim();
        ReloadMainDigits();
        ClearEditString();
        StateHasChanged();
    }

    protected void ReloadMainDigits()
    {
        if (MainDigitListToUpdDel != null && MainDigitListToUpdDel.Count > 0)
        {
            if (AgentId != 0 || ShortKey != ShortKey.WrongTyping || !string.IsNullOrWhiteSpace(SearchedString))
            {
                ToShowUpdDelMainDigits = MainDigitListToUpdDel ?? new List<MainDigit>();
                if (AgentId != 0)
                {
                    ToShowUpdDelMainDigits = ToShowUpdDelMainDigits.Where(x => x.Agent.AgentId == AgentId).ToList(); ;
                }
                if (ShortKey != ShortKey.WrongTyping)
                {
                    ToShowUpdDelMainDigits = ToShowUpdDelMainDigits.Where(x => x.ShortcutType == ShortKey).ToList(); ;
                }
                //if (!string.IsNullOrWhiteSpace(SearchedString))
                //{
                ToShowUpdDelMainDigits = ToShowUpdDelMainDigits.Where(x => x.DescriptionToShowUser.Replace(",", string.Empty).StringCompareFormat().Contains(SearchedString.StringCompareFormat())).ToList(); ;
                //}
            }
            else
            {
                ToShowUpdDelMainDigits = MainDigitListToUpdDel ?? new List<MainDigit>();
            }

            DicMainDigitGroupByAgent = ToShowUpdDelMainDigits.Select(x => x.Agent.AgentId).Distinct().ToList().Select(x => new
            {
                agent = ToShowUpdDelMainDigits.Where(gp => gp.AgentId == x).Select(a => a.Agent).FirstOrDefault(),
                mainDigits = ToShowUpdDelMainDigits.Where(gp => gp.AgentId == x).ToList()
            }).ToDictionary(k => k.agent, v => v.mainDigits);
        }
        else
        {
            DicMainDigitGroupByAgent = new Dictionary<Agent, List<MainDigit>>();
        }

    }

    public void Show()
    {
        AgentId = 0;
        ShortKey = ShortKey.WrongTyping;
        SearchedString = "";
        EditMainDigit = new MainDigit();
        DeleteMainDigit = new MainDigit();
        EditNumString = "";
        EditNumStringErrorMessage = "";
        ShowUpdateDeleteVoucherModal = true;
        StateHasChanged();
    }

    public async Task Hide()
    {
        AgentId = 0;
        ShortKey = ShortKey.WrongTyping;
        SearchedString = "";
        EditMainDigit = new MainDigit();
        DeleteMainDigit = new MainDigit();
        EditNumStringErrorMessage = "";
        EditNumString = "";
        ShowUpdateDeleteVoucherModal = false;
        StateHasChanged();
        await OnClosedProcessed.InvokeAsync(true);
    }

    protected async Task OnUpdateChangesVoucher()
    {
        EditNumString = EditNumString.StringCompareFormat();
        if (!string.IsNullOrWhiteSpace(EditNumString) && EditMainDigit.MainDigitId != 0 && !IsProcessing)
        {
            IsProcessing = true;
            Regex re = new Regex(NumStringValidateRegex.regexNumStringValidateRegex, RegexOptions.IgnoreCase);
            if (re.IsMatch(EditNumString))
            {
                OwnerViewModel viewModel = new OwnerViewModel()
                {
                    IntendedDate = EditMainDigit.IntendedDate,
                    AgentId = EditMainDigit.AgentId,
                    TimeAmPM = EditMainDigit.MorningOrEvening
                };
                MainDigit mainDigit = new MainDigit();
                mainDigit = EditNumString.GetMainDigitByNumString(viewModel);
                if (mainDigit.ShortcutType != ShortKey.WrongTyping)
                {
                    mainDigit.MainDigitId = EditMainDigit.MainDigitId;
                    try
                    {
                        var result = await digitService.UpdateMainDigit(mainDigit);
                        if (result != null)
                        {
                            EditNumString = "";
                            EditNumStringErrorMessage = "";
                            EditMainDigit = new MainDigit();
                            await OnUpdateProcessed.InvokeAsync(true);
                        }
                        else
                        {
                            await OnUpdateProcessed.InvokeAsync(false);
                        }
                    }
                    catch (Exception)
                    {
                        await OnUpdateProcessed.InvokeAsync(false);
                    }
                }
                else
                {
                    EditNumStringErrorMessage = "Input is not valid!";
                }
            }
            else
            {
                EditNumStringErrorMessage = "Input is not valid!";
            }
        }
        else
        {
            if (EditMainDigit.MainDigitId == 0)
            {
                EditNumStringErrorMessage = "Choose Data To Update!";
            }
        }
        IsProcessing = false;
    }

    protected async Task OnDeleteChangesVoucher()
    {
        IsDeleteClick = false;
        IsProcessing = true;
        if (DeleteMainDigit.MainDigitId != 0)
        {
            var result = await digitService.DeleteMainDigit(DeleteMainDigit.MainDigitId);

            if (result != null)
            {
                await OnDeleteProcessed.InvokeAsync(true);
            }
            else
            {
                await OnDeleteProcessed.InvokeAsync(false);
            }
        }
        else
        {
            await OnDeleteProcessed.InvokeAsync(false);
        }
        IsProcessing = false;
        HideDeleteConfirmation();
    }

    protected void ShowDeleteComfirmation(MainDigit mainDigit)
    {
        EditMainDigit = new MainDigit();
        EditNumString = "";
        EditNumStringErrorMessage = "";
        DeleteMainDigit = new MainDigit();
        DeleteMainDigit = mainDigit;
        DeleteConfirmationMessage = "";
        DeleteConfirmationMessage = mainDigit.DescriptionToShowUser;
        IsDeleteClick = true;
        RunAfterRender(() => JSRuntime.FocusAsync(btnDeleteSubmit));
    }

    protected void HideDeleteConfirmation()
    {
        DeleteConfirmationMessage = "";
        DeleteMainDigit = new MainDigit();
        IsDeleteClick = false;
    }

    protected async Task UpdateClickByKeyboardKey(KeyboardEventArgs args)
    {
        if (args.Key == "F2")
        {
            if (!string.IsNullOrWhiteSpace(EditNumString.StringCompareFormat()) && EditMainDigit.MainDigitId != 0 && !IsProcessing)
            {
                await OnUpdateChangesVoucher();
            }
        }
    }

    protected void EditClick(MainDigit editMainDigit)
    {
        DeleteMainDigit = new MainDigit();
        EditNumString = "";
        EditNumStringErrorMessage = "";
        EditMainDigit = new MainDigit();
        EditMainDigit = editMainDigit;
        EditNumString = editMainDigit.GetOriginalString();
        RunAfterRender(() => JSRuntime.FocusAsync(txtEditNumString));
        StateHasChanged();
    }

    protected void CancelClick()
    {
        EditNumString = "";
        EditNumStringErrorMessage = "";
        EditMainDigit = new MainDigit();
        DeleteMainDigit = new MainDigit();
    }

    protected void ClearEditString()
    {
        EditNumString = "";
        EditNumStringErrorMessage = "";
        EditMainDigit = new MainDigit();
    }

    private void SetElementFocus()
    {
        RunAfterRender(() => JSRuntime.FocusAsync(txtEditNumString));
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
