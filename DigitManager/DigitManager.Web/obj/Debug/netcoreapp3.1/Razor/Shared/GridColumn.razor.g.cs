#pragma checksum "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\GridColumn.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73ac96bd86cc7896c1e3ac3acbc39c233ed5f400"
// <auto-generated/>
#pragma warning disable 1591
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
    public partial class GridColumn : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "th");
            __builder.AddMarkupContent(1, "\r\n    ");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "col-10 row");
            __builder.AddMarkupContent(4, "\r\n        ");
#nullable restore
#line 3 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\GridColumn.razor"
__builder.AddContent(5, ColumnTitle);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "input");
            __builder.AddAttribute(8, "class", "form-control gridColumnSearchInput txtSearchedGridView");
            __builder.AddAttribute(9, "placeholder", "search");
            __builder.AddAttribute(10, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 4 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\GridColumn.razor"
                                                                                                             OnSearchTextChange

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\GridColumn.razor"
       
    [Parameter]
    public string ColumnTitle { get; set; }

    [Parameter]
    public EventCallback<ChangeEventArgs> OnSearchTextChange { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
