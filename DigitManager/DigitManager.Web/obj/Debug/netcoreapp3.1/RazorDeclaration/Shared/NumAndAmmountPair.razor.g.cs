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
#line 13 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.ModelLibrary.MainAndSubRelation;

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
#line 15 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\_Imports.razor"
using DigitManager.ModelLibrary.ViewModels;

#line default
#line hidden
#nullable disable
    public partial class NumAndAmmountPair : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\NumAndAmmountPair.razor"
       
    [Parameter]
    public string NumKey { get; set; }

    [Parameter]
    public string Ammount { get; set; }

    [Parameter]
    public EventCallback<string> OnDbClickTwoNum { get; set; }

    public async Task OnDigitDbClick(string towNum)
    {
        await OnDbClickTwoNum.InvokeAsync(towNum);
        StateHasChanged();
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
