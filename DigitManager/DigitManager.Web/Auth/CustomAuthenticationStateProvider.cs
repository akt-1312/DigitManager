using Blazored.LocalStorage;
using Blazored.SessionStorage;
using DigitManager.ModelLibrary;
using DigitManager.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DigitManager.ModelLibrary.CryptoExtensions;
using DigitManager.Web.Services;

namespace DigitManager.Web.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly ISessionStorageService sessionStorageService;
        private readonly NavigationManager navigationManager;
        private readonly ILoginUserService loginUserService;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService,
                                                 ISessionStorageService sessionStorageService,
                                                 NavigationManager navigationManager,
                                                 ILoginUserService loginUserService)
        {
            this.localStorageService = localStorageService;
            this.sessionStorageService = sessionStorageService;
            this.navigationManager = navigationManager;
            this.loginUserService = loginUserService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userName = await sessionStorageService.GetItemAsync<string>("userName") ?? await localStorageService.GetItemAsync<string>("userName");
            var role = await sessionStorageService.GetItemAsync<string>("userRole") ?? await localStorageService.GetItemAsync<string>("userRole");
            var accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            var refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
            ClaimsIdentity identity;
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                DigitUserAsLogOut();
                navigationManager.NavigateTo("/");

                identity = new ClaimsIdentity();
                var unauthorizedUser = new ClaimsPrincipal(identity);
                return await Task.FromResult(new AuthenticationState(unauthorizedUser));
            }
            //var userId = await sessionStorageService.GetItemAsync<string>("ownerId") ?? await localStorageService.GetItemAsync<string>("ownerId");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(role))
            {
                userName = userName.DecryptPassword();
                role = role.DecryptPassword();

                if (role.Trim() == "Player" || role.Trim() == "Agent")
                {
                    var agent = new Agent();
                    if (role.Trim() == "Agent")
                    {
                        agent = await loginUserService.GetValidateAgent(userName);
                    }
                    else
                    {
                        agent = await loginUserService.GetValidatePlayer(userName);
                    }

                    if (agent == null)
                    {
                        DigitUserAsLogOut();
                        navigationManager.NavigateTo("/");

                        identity = new ClaimsIdentity();
                        var unauthorizedUser = new ClaimsPrincipal(identity);
                        return await Task.FromResult(new AuthenticationState(unauthorizedUser));
                    }
                }

                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, role)
                }, "apiauth_type");


                var requestUri = navigationManager.Uri;
                var baseUri = navigationManager.BaseUri;

                if (baseUri == requestUri)
                {
                    if (Enum.TryParse(role, out LoginUserRoleEnum owner) && owner == LoginUserRoleEnum.Owner)
                    {
                        navigationManager.NavigateTo("/ownerPage");
                    }
                    else if (Enum.TryParse(role, out LoginUserRoleEnum agent)
                        && agent == LoginUserRoleEnum.Agent || agent == LoginUserRoleEnum.Player)
                    {
                        navigationManager.NavigateTo("/agentPage");
                    }
                    //else if(Enum.TryParse(role, out LoginUserRoleEnum player) && player == LoginUserRoleEnum.Player)
                    //{
                    //    navigationManager.NavigateTo("/agentPage");
                    //}
                    else
                    {
                        //LoginUser = new LoginViewModel();
                        DigitUserAsLogOut();
                        navigationManager.NavigateTo("/");

                        identity = new ClaimsIdentity();
                        var unauthorizedUser = new ClaimsPrincipal(identity);
                        return await Task.FromResult(new AuthenticationState(unauthorizedUser));
                    }
                    //else if (Enum.TryParse(role, out LoginUserRoleEnum player) && player == LoginUserRoleEnum.Player)
                    //{
                    //    navigationManager.NavigateTo("/playerPage");
                    //}

                }
                else
                {
                    navigationManager.ToBaseRelativePath(requestUri);
                }
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void DigitUserAsAuthenticated(string userName, string role)
        {
            //var identity = new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Name, userOwner.OwnerName),
            //}, "apiauth_type");
            //var user = new ClaimsPrincipal(identity);

            var identity = GetClaimsIdentity(userName, role);
            var claimPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimPrincipal)));
        }

        public void DigitUserAsLogOut()
        {
            sessionStorageService.RemoveItemAsync("userName");
            localStorageService.RemoveItemAsync("userName");
            sessionStorageService.RemoveItemAsync("userRole");
            localStorageService.RemoveItemAsync("userRole");
            localStorageService.RemoveItemAsync("accesstoken");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(string userName, string role)
        {
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            }, "apiauth_type");
            return claimsIdentity;
        }
    }
}
