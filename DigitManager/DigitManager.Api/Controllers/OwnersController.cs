using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitManager.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitManager.ModelLibrary.CryptoExtensions;
using DigitManager.ModelLibrary;
using DigitManager.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace DigitManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetOwners()
        {
            try
            {
                var result = (await ownerRepository.GetOwners()).Select(x=> { x.Password = null; return x; });
                return Ok((result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            try
            {
                var result = await ownerRepository.GetOwner(id);
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

        [HttpGet("checkpassword")]
        public async Task<ActionResult<Owner>> CheckAgentOldPasswordCorrect(int ownerId, string password)
        {
            try
            {
                var result = await ownerRepository.CheckOwnerOldPasswordCorrect(ownerId, password);
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

        [HttpPut("changepassword")]
        public async Task<ActionResult<Owner>> ChangePassword(Owner owner)
        {
            try
            {
                var ownerToChangePassword = await ownerRepository.GetOwner(owner.OwnerId);

                if (ownerToChangePassword == null)
                {
                    return NotFound($"Owner with Id = {owner.OwnerId} not found");
                }
                ownerToChangePassword.Password = owner.Password.Trim();
                var result = await ownerRepository.ChangeAndResetOwnerPassword(ownerToChangePassword);
                result.Password = null;
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        //[HttpGet("{loginowner}")]
        //public async Task<ActionResult<Owner>> GetLoginOwner(string userName, string password)
        //{
        //    try
        //    {
        //        var result = await ownerRepository.GetLoginOwner(userName, password);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }

        //        result.Password = null;
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        //    }
        //}

        //[HttpPost("login/owner")]
        //public async Task<ActionResult<Owner>> LoginOwner(LoginUserData user)
        //{
        //    try
        //    {
        //        var result = await ownerRepository.LoginOwner(user);
        //        //var result = await ownerRepository.GetLoginOwner(userName, password);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }

        //        result.Password = null;
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        //    }
        //}

        [HttpPut]
        public async Task<ActionResult<Owner>> UpdateOwner(Owner owner)
        {
            try
            {
                var ownerToUpdate = await ownerRepository.GetOwner(owner.OwnerId);

                if(ownerToUpdate == null)
                {
                    return NotFound($"Owner with Id = {owner.OwnerId} not found");
                }

                return await ownerRepository.UpdateOwner(owner);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
    }
}
