#pragma checksum "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "069ccb5dee9e8fe97e37379a384558abb294b1f9"
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
    public partial class KeypadNum : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n    .btnSellingDigit {\r\n        border: 1px solid silver;\r\n        border-radius: 0.2rem;\r\n        width: 30px;\r\n    }\r\n</style>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "style", "margin-bottom:5px; display:inline-block;");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "button");
            __builder.AddAttribute(7, "class", "btnSellingDigit");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("1")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "1");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "button");
            __builder.AddAttribute(12, "class", "btnSellingDigit");
            __builder.AddAttribute(13, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("2")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(14, "2");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "button");
            __builder.AddAttribute(17, "class", "btnSellingDigit");
            __builder.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("3")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(19, "3");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n        ");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "class", "btnSellingDigit");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("4")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(24, "4");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n        ");
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "class", "btnSellingDigit");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("5")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(29, "5");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n    ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "style", "margin-bottom:5px; display:inline-block");
            __builder.AddMarkupContent(34, "\r\n        ");
            __builder.OpenElement(35, "button");
            __builder.AddAttribute(36, "class", "btnSellingDigit");
            __builder.AddAttribute(37, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("6")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(38, "6");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n        ");
            __builder.OpenElement(40, "button");
            __builder.AddAttribute(41, "class", "btnSellingDigit");
            __builder.AddAttribute(42, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("7")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(43, "7");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n        ");
            __builder.OpenElement(45, "button");
            __builder.AddAttribute(46, "class", "btnSellingDigit");
            __builder.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("8")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(48, "8");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n        ");
            __builder.OpenElement(50, "button");
            __builder.AddAttribute(51, "class", "btnSellingDigit");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("9")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(53, "9");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n        ");
            __builder.OpenElement(55, "button");
            __builder.AddAttribute(56, "class", "btnSellingDigit");
            __builder.AddAttribute(57, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("0")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(58, "0");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n    ");
            __builder.OpenElement(61, "div");
            __builder.AddAttribute(62, "style", "margin-bottom:5px; display:inline-block;");
            __builder.AddMarkupContent(63, "\r\n        ");
            __builder.OpenElement(64, "button");
            __builder.AddAttribute(65, "class", "btnSellingDigit");
            __builder.AddAttribute(66, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick(".")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(67, ".");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n        ");
            __builder.OpenElement(69, "button");
            __builder.AddAttribute(70, "class", "btnSellingDigit");
            __builder.AddAttribute(71, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("/")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(72, "/");
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n        ");
            __builder.OpenElement(74, "button");
            __builder.AddAttribute(75, "class", "btnSellingDigit");
            __builder.AddAttribute(76, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 29 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("*")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(77, "*");
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\r\n        ");
            __builder.OpenElement(79, "button");
            __builder.AddAttribute(80, "class", "btnSellingDigit");
            __builder.AddAttribute(81, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 30 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("+")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(82, "+");
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n        ");
            __builder.OpenElement(84, "button");
            __builder.AddAttribute(85, "class", "btnSellingDigit");
            __builder.AddAttribute(86, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 31 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("-")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(87, "-");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n        ");
            __builder.OpenElement(89, "button");
            __builder.AddAttribute(90, "class", "btnSellingDigit");
            __builder.AddAttribute(91, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
                                                    () => OnTouchButtonClick("Back")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(92, "<span class=\"oi oi-arrow-thick-left\"></span>");
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "D:\Old Data\DM_Back\DM_2020_12_14\DigitManager\DigitManager.Web\Shared\KeypadNum.razor"
       

    [Parameter]
    public string NumString { get; set; }

    [Parameter]
    public EventCallback<string> NumStringChanged { get; set; }

    private string BoundValue
    {
        get => NumString;
        set => NumStringChanged.InvokeAsync(value);
    }

    private Task OnTouchButtonClick(string inputStr)
    {
        if (inputStr != null)
        {
            if (inputStr.StringCompareFormat() != "back")
            {
                NumString += inputStr;
            }
            else
            {
                if (NumString.Length > 0)
                {
                    NumString = NumString.Substring(0, NumString.Length - 1);
                }
            }
        }

        return NumStringChanged.InvokeAsync(NumString);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
