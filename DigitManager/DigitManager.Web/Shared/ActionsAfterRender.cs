using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitManager.Web.Shared
{
    public class ActionsAfterRender
    {
        // store all the actions you want to run **once** after rendering
        public List<Action> actionsToRunAfterRender = new List<Action>();        
        public void GetRunAfterRender()
        {
            foreach (var actionToRun in actionsToRunAfterRender)
            {
                actionToRun();
            }
            // clear the actions to make sure the actions only run **once**
            actionsToRunAfterRender.Clear();
        }

        /// <summary>
        /// Run an action once after the component is rendered
        /// </summary>
        /// <param name="action">Action to invoke after render</param>
        public void RunAfterRender(Action action) => actionsToRunAfterRender.Add(action);
    }
}
