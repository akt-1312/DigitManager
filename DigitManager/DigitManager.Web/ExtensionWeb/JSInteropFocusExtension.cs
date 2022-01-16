using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.ExtensionWeb
{
    public static class JSInteropFocusExtension
    {
        public static ValueTask FocusAsync(this IJSRuntime jsRuntime, ElementReference elementReference)
        {
            return jsRuntime.InvokeVoidAsync("SetElementFocus", elementReference);
        }
    }
}
