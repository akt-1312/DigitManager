using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.Api.Repository;
using DigitManager.ModelLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitManager.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentRepository agentRepository;

        public AgentsController(IAgentRepository agentRepository)
        {
            this.agentRepository = agentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAgents()
        {
            try
            {
                var result = (await agentRepository.GetAgents()).Select(x => { x.Password = null; return x; });
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Agent>> GetAgent(int id)
        {
            try
            {
                var result = await agentRepository.GetAgent(id);
                if(result == null)
                {
                    return NotFound();
                }
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("profile/{id:int}")]
        public async Task<ActionResult<Agent>> GetAgentProfile(int id)
        {
            try
            {
                var result = await agentRepository.GetAgent(id);
                if (result == null)
                {
                    return NotFound();
                }
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("checkpassword")]
        public async Task<ActionResult<Agent>> CheckAgentOldPasswordCorrect(int agentId, string password)
        {
            try
            {
                var result = await agentRepository.CheckAgentOldPasswordCorrect(agentId, password);
                if (result != null)
                {
                    result.Password = null;
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Agent>> AddAgent(Agent agent)
        {
            try
            {
                if(agent == null)
                {
                    return BadRequest();
                }

                bool isAgentExist = await agentRepository.IsAgentAlreadyExist(agent.UserName);
                if (isAgentExist)
                {
                    ModelState.AddModelError("UserName", "This name already exist. Please choose another name");
                    return BadRequest(ModelState);
                }

                var createdAgent = await agentRepository.AddAgent(agent);

                createdAgent.Password = null;
                return CreatedAtAction(nameof(GetAgent), new { id = createdAgent.AgentId }, createdAgent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Agent record");
            }
        }

        [HttpPut("resetpassword")]
        public async Task<ActionResult<Agent>> ResetPassword(Agent agent)
        {
            try
            {
                var agentToResetPassword = await agentRepository.GetAgent(agent.AgentId);

                if (agentToResetPassword == null)
                {
                    return NotFound($"Owner with Id = {agent.AgentId} not found");
                }
                agentToResetPassword.Password = agent.Password.Trim();
                var result = await agentRepository.ChangeAndResetAgentPassword(agentToResetPassword);
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpPut("changepassword")]
        public async Task<ActionResult<Agent>> ChangePassword(Agent agent)
        {
            try
            {
                var agentToChangePassword = await agentRepository.GetAgent(agent.AgentId);

                if (agentToChangePassword == null)
                {
                    return NotFound($"Owner with Id = {agent.AgentId} not found");
                }
                agentToChangePassword.Password = agent.Password.Trim();
                var result = await agentRepository.ChangeAndResetAgentPassword(agentToChangePassword);
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Agent>> UpdateAgent(Agent agent)
        {
            try
            {
                var agentToUpdate = await agentRepository.GetAgent(agent.AgentId);

                if (agentToUpdate == null)
                {
                    return NotFound($"Owner with Id = {agent.AgentId} not found");
                }

                bool isAgentExist = await agentRepository.IsAgentAlreadyExist(agent.UserName, agent.AgentId);
                if (isAgentExist)
                {
                    ModelState.AddModelError("UserName", "This name already exist. Please choose another name");
                    return BadRequest(ModelState);
                }

                var result = await agentRepository.UpdateAgent(agent);
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpPut("profile")]
        public async Task<ActionResult<Agent>> UpdateAgentProfile(Agent agent)
        {
            try
            {
                var agentToUpdate = await agentRepository.GetAgent(agent.AgentId);

                if (agentToUpdate == null)
                {
                    return NotFound($"Owner with Id = {agent.AgentId} not found");
                }

                var result = await agentRepository.UpdateAgent(agent);
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Agent>> DeleteAgent(int id)
        {
            try
            {
                var agentToDelete = await agentRepository.GetAgent(id);

                if (agentToDelete == null)
                {
                    return NotFound($"Owner with Id = {id} not found");
                }

                var result = await agentRepository.DeleteAgent(id);
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
