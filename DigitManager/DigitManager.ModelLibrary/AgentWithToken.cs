using System;
using System.Collections.Generic;
using System.Text;

namespace DigitManager.ModelLibrary
{
    public class AgentWithToken : Agent
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public AgentWithToken(Agent agent)
        {
            this.AgentId = agent.AgentId;
            this.UserName = agent.UserName;
            this.Password = agent.Password;
            this.Mobile = agent.Mobile;
            this.AgentGuid = agent.AgentGuid;
            this.AgentCommissionMultiply = agent.AgentCommissionMultiply;
            this.IsActive = agent.IsActive;
            this.IsByOwner = agent.IsByOwner;
            this.CreatedDate = agent.CreatedDate;
            this.UpdatedDate = agent.UpdatedDate;
        }
    }
}
