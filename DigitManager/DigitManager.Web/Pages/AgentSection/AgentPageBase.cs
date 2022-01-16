using DigitManager.Web.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Pages.AgentSection
{
    public class AgentPageBase : ComponentBase 
    {
        [Inject]
        public IAgentService AgentService { get; set; }
        public string Test { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var test = await AgentService.GetAgents();
            var testStr = JsonConvert.SerializeObject(test);
            Test = testStr;
            await base.OnInitializedAsync();
        }
    }
}
