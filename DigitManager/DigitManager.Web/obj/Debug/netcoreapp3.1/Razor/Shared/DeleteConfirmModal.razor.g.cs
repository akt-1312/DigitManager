#pragma checksum "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f633c63c766b6dc2d7a9f8dc710bde12d5a1335"
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
    public partial class DeleteConfirmModal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n    .modal-content {\r\n        background-color: lemonchiffon;\r\n    }\r\n</style>\r\n\r\n");
#nullable restore
#line 8 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
 if (ShowConfirmation)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "modal fade show d-block");
            __builder.AddAttribute(4, "id", "exampleModalCenter");
            __builder.AddAttribute(5, "tabindex", "-1");
            __builder.AddAttribute(6, "role", "dialog");
            __builder.AddAttribute(7, "aria-labelledby", "exampleModalCenterTitle");
            __builder.AddAttribute(8, "aria-hidden", "true");
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "modal-dialog");
            __builder.AddAttribute(12, "role", "document");
            __builder.AddMarkupContent(13, "\r\n            ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "modal-content");
            __builder.AddMarkupContent(16, "\r\n                ");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "modal-header");
            __builder.AddMarkupContent(19, "\r\n                    ");
            __builder.OpenElement(20, "h5");
            __builder.AddAttribute(21, "class", "modal-title text-danger text-center d-block w-100 font-weight-bold");
            __builder.AddAttribute(22, "id", "exampleModalLongTitle");
#nullable restore
#line 14 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
__builder.AddContent(23, ConfirmationTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    ");
            __builder.OpenElement(25, "button");
            __builder.AddAttribute(26, "type", "button");
            __builder.AddAttribute(27, "class", "close");
            __builder.AddAttribute(28, "data-dismiss", "modal");
            __builder.AddAttribute(29, "aria-label", "Close");
            __builder.AddAttribute(30, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
                                      ()=> OnConfirmationChanged(false)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(31, "\r\n                        ");
            __builder.AddMarkupContent(32, "<span aria-hidden=\"true\">&times;</span>\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "modal-body bg-dark");
            __builder.AddMarkupContent(37, "\r\n                    ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "style", "color:yellow;");
            __builder.AddMarkupContent(40, "\r\n                        ");
#nullable restore
#line 22 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
__builder.AddContent(41, ConfirmationMessage);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(42, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                ");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "class", "modal-footer justify-content-between");
            __builder.AddMarkupContent(47, "\r\n                    ");
            __builder.OpenElement(48, "button");
            __builder.AddAttribute(49, "type", "button");
            __builder.AddAttribute(50, "class", "btn btn-secondary");
            __builder.AddAttribute(51, "data-dismiss", "modal");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
                                                                                                   ()=> OnConfirmationChanged(false)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(53, "Cancel");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n                    ");
            __builder.OpenElement(55, "button");
            __builder.AddAttribute(56, "type", "button");
            __builder.AddAttribute(57, "class", "btn btn-danger");
            __builder.AddAttribute(58, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
                                                                           ()=> OnConfirmationChanged(true)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(59, "Delete");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n");
#nullable restore
#line 32 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\DeleteConfirmModal.razor"
       
    [Parameter]
    public EventCallback<bool> ConfirmationChanged { get; set; }

    [Parameter]
    public string ConfirmationTitle { get; set; } = "Delete Confirmation";

    [Parameter]
    public string ConfirmationMessage { get; set; } = "Are You Sure To Delete This Record!";

    public bool ShowConfirmation { get; set; }

    public void Show()
    {
        ShowConfirmation = true;
        StateHasChanged();
    }

    protected async Task OnConfirmationChanged(bool value)
    {
        ShowConfirmation = false;
        await ConfirmationChanged.InvokeAsync(value);
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
