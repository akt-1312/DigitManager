using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DigitManager.Api.Models;
using DigitManager.Api.Models.JWTAuth;
using DigitManager.Api.Repository;
using DigitManager.ModelLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DigitManager.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DigitManagerController : ControllerBase
    {
        private readonly IUserLoginRepository userLoginRepository;
        private readonly AppDbContext db;
        private readonly JWTSettings jwtsettings;

        public DigitManagerController(IUserLoginRepository userLoginRepository,
                                        IOptions<JWTSettings> jwtsettings,
                                        AppDbContext db)
        {
            this.userLoginRepository = userLoginRepository;
            this.db = db;
            this.jwtsettings = jwtsettings.Value;
        }

        [HttpGet("validate/agent/{userName}")]
        public async Task<ActionResult<Agent>> ValidateAgent(string userName)
        {
            try
            {
                var result = await userLoginRepository.GetValidateAgent(userName);
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

        [HttpGet("validate/player/{userName}")]
        public async Task<ActionResult<Agent>> ValidatePlayer(string userName)
        {
            try
            {
                var result = await userLoginRepository.GetValidatePlayer(userName);
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

        [HttpPost("login/owner")]
        public async Task<ActionResult<OwnerWithToken>> LoginOwner(LoginUserData user)
        {
            try
            {
                var owner = await userLoginRepository.LoginOwner(user);
                OwnerWithToken ownerWithToken = null;

                if (owner != null)
                {
                    OwnerRefreshToken ownerRefreshToken = GenerateOwnerRefreshToken();
                    owner.OwnerRefreshTokens.Add(ownerRefreshToken);
                    await db.SaveChangesAsync();


                    ownerWithToken = new OwnerWithToken(owner);
                    ownerWithToken.RefreshToken = ownerRefreshToken.Token;
                }

                if (ownerWithToken == null)
                {
                    return NotFound();
                }

                ownerWithToken.AccessToken = GenerateAccessToken(owner.OwnerId);

                return ownerWithToken;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("login/agent")]
        public async Task<ActionResult<AgentWithToken>> LoginAgent(LoginUserData user)
        {
            try
            {
                var agent = await userLoginRepository.LoginAgent(user);
                AgentWithToken agentWithToken = null;

                if (agent != null)
                {
                    AgentRefreshToken agentRefreshToken = GenerateAgentRefreshToken();
                    agent.AgentRefreshTokens.Add(agentRefreshToken);
                    await db.SaveChangesAsync();


                    agentWithToken = new AgentWithToken(agent);
                    agentWithToken.RefreshToken = agentRefreshToken.Token;
                }

                if (agentWithToken == null)
                {
                    return NotFound();
                }

                agentWithToken.AccessToken = GenerateAccessToken(agent.AgentId);

                return agentWithToken;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

            //try
            //{
            //    var result = await userLoginRepository.LoginAgent(user);
            //    //var result = await ownerRepository.GetLoginOwner(userName, password);
            //    if (result == null)
            //    {
            //        return NotFound();
            //    }

            //    result.Password = null;
            //    return result;
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            //}
        }

        [HttpPost("login/player")]
        public async Task<ActionResult<AgentWithToken>> LoginPlayer(LoginUserData user)
        {
            try
            {
                var agent = await userLoginRepository.LoginPlayer(user);
                AgentWithToken agentWithToken = null;

                if (agent != null)
                {
                    AgentRefreshToken agentRefreshToken = GenerateAgentRefreshToken();
                    agent.AgentRefreshTokens.Add(agentRefreshToken);
                    await db.SaveChangesAsync();


                    agentWithToken = new AgentWithToken(agent);
                    agentWithToken.RefreshToken = agentRefreshToken.Token;
                }

                if (agentWithToken == null)
                {
                    return NotFound();
                }

                agentWithToken.AccessToken = GenerateAccessToken(agent.AgentId);

                return agentWithToken;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

            //try
            //{
            //    var result = await userLoginRepository.LoginPlayer(user);
            //    //var result = await ownerRepository.GetLoginOwner(userName, password);
            //    if (result == null)
            //    {
            //        return NotFound();
            //    }

            //    result.Password = null;
            //    return result;
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            //}
        }

        [HttpPost("owner/refreshtoken")]
        public async Task<ActionResult<OwnerWithToken>> OwnerRefreshToken(RefreshRequest refreshRequest)
        {
            Owner owner = await GetOwnerFromAccessToken(refreshRequest.AccessToken);

            if (owner != null && await ValidateOwnerRefreshToken(owner, refreshRequest.RefreshToken))
            {
                OwnerWithToken ownerWithToken = new OwnerWithToken(owner);
                ownerWithToken.AccessToken = GenerateAccessToken(owner.OwnerId);

                return ownerWithToken;
            }

            return null;
        }

        [HttpPost("agent/refreshtoken")]
        public async Task<ActionResult<AgentWithToken>> AgentRefreshToken(RefreshRequest refreshRequest)
        {
            Agent agent = await GetAgentFromAccessToken(refreshRequest.AccessToken);

            if (agent != null && await ValidateAgentRefreshToken(agent, refreshRequest.RefreshToken))
            {
                AgentWithToken agentWithToken = new AgentWithToken(agent);
                agentWithToken.AccessToken = GenerateAccessToken(agent.AgentId);

                return agentWithToken;
            }

            return null;
        }

        private async Task<bool> ValidateOwnerRefreshToken(Owner owner, string refreshToken)
        {
            OwnerRefreshToken ownerRefreshToken = await db.OwnerRefreshTokens.Where(rt => rt.Token == refreshToken)
                                                                            .OrderByDescending(rt => rt.ExpiryDate)
                                                                            .FirstOrDefaultAsync();
            if (ownerRefreshToken != null && ownerRefreshToken.OwnerId == owner.OwnerId
                && ownerRefreshToken.ExpiryDate > DateTime.UtcNow.AddMinutes(390))
            {
                return true;
            }

            return false;
        }

        private async Task<Owner> GetOwnerFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtsettings.SecretKey);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                SecurityToken securityToken;

                var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var ownerId = principal.FindFirst(ClaimTypes.Name)?.Value;
                    var owner = await db.Owners.Where(x => x.OwnerId == Convert.ToInt32(ownerId)).FirstOrDefaultAsync();
                    return owner;
                }
               
            }
            catch (Exception ex)
            {
                return new Owner();
            }
            return new Owner();
        }

        private async Task<bool> ValidateAgentRefreshToken(Agent agent, string refreshToken)
        {
            AgentRefreshToken agentRefreshToken = await db.AgentRefreshTokens.Where(rt => rt.Token == refreshToken)
                                                                            .OrderByDescending(rt => rt.ExpiryDate)
                                                                            .FirstOrDefaultAsync();
            if (agentRefreshToken != null && agentRefreshToken.AgentId == agent.AgentId
                && agentRefreshToken.ExpiryDate > DateTime.UtcNow.AddMinutes(390))
            {
                return true;
            }

            return false;
        }

        private async Task<Agent> GetAgentFromAccessToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtsettings.SecretKey);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                var agentId = principal.FindFirst(ClaimTypes.Name)?.Value;
                var agent = await db.Agents.Where(x => x.AgentId == Convert.ToInt32(agentId)).FirstOrDefaultAsync();
                return agent;
            }

            return null;
        }

        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                //Expires = DateTime.UtcNow.AddSeconds(5),
                Expires = DateTime.UtcNow.AddMinutes(390).AddMonths(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private OwnerRefreshToken GenerateOwnerRefreshToken()
        {
            OwnerRefreshToken ownerRefreshToken = new OwnerRefreshToken();
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                ownerRefreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            ownerRefreshToken.ExpiryDate = DateTime.UtcNow.AddMinutes(390).AddMonths(6);

            return ownerRefreshToken;
        }

        private AgentRefreshToken GenerateAgentRefreshToken()
        {
            AgentRefreshToken agentRefreshToken = new AgentRefreshToken();
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                agentRefreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            agentRefreshToken.ExpiryDate = DateTime.UtcNow.AddMinutes(390).AddMonths(6);

            return agentRefreshToken;
        }

    }
}
