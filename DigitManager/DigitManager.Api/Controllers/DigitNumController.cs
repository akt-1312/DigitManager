using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.Api.Repository;
using DigitManager.ModelLibrary;
using DigitManager.ModelLibrary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DigitNumController : ControllerBase
    {
        private readonly IDigitNumRepository digitNumRepository;

        public DigitNumController(IDigitNumRepository digitNumRepository)
        {
            this.digitNumRepository = digitNumRepository;
        }
        [HttpGet("getdigits")]
        public async Task<ActionResult> GetOwnerDigits()
        {
            try
            {
                var result = (await digitNumRepository.GetAllDigit()).Select(x => { x.MainDigit.Agent.Password = null; return x; }).ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("getdigits/agent/{agentId:int}")]
        public async Task<ActionResult> GetAgentDigits(int agentId)
        {
            try
            {
                var result = await digitNumRepository.GetDigitForAgent(agentId);
                if (result != null)
                {
                    result = result.Select(x => { x.MainDigit.Agent.Password = null; return x; }).ToList();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("getdigits/filtered")]
        public async Task<ActionResult> GetSubDigitsWithRequestParams([FromQuery] ParamsForRequestSubDigit requestParams)
        {
            //ParamsForRequestSubDigit requestParams = new ParamsForRequestSubDigit();
            try
            {
                var result = await digitNumRepository.GetSubDigitsWithRequestParams(requestParams);
                if (result != null)
                {
                    result = result.Select(x => { x.MainDigit.Agent.Password = null; return x; }).ToList();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpPost("adddigit")]
        public async Task<ActionResult> AddDigits(List<MainDigit> mainDigits)
        {
            if (mainDigits == null || mainDigits.Count == 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await digitNumRepository.SaveDigitVoucher(mainDigits);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new digit records");
            }
        }

        [HttpPut("updatedigit")]
        public async Task<ActionResult<MainDigit>> UpdateMainDigit(MainDigit mainDigit)
        {
            try
            {
                var main = await digitNumRepository.GetMainDigit(mainDigit.MainDigitId);
                if (main == null)
                {
                    return NotFound($"Voucher with Id = {mainDigit.MainDigitId} not found");
                }

                var result = await digitNumRepository.UpdateMainDigit(mainDigit);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("delete/voucher/{voucherId}")]
        public async Task<ActionResult<string>> DeleteVoucher(string voucherId)
        {
            try
            {
                var reslult = await digitNumRepository.DeleteVoucher(voucherId);
                return reslult;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<MainDigit>> DeleteMainDigit(int id)
        {
            try
            {
                var reslult = await digitNumRepository.DeleteMainDigit(id);
                return reslult;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

    }
}
