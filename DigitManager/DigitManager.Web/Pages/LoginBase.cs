using Blazored.LocalStorage;
using Blazored.SessionStorage;
using DigitManager.ModelLibrary;
using DigitManager.Web.Auth;
using DigitManager.Web.Models;
using DigitManager.Web.Services;
using DigitManager.Web.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DigitManager.ModelLibrary.CryptoExtensions;

namespace DigitManager.Web.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public ILoginUserService LoginUserService { get; set; }

        public LoginViewModel LoginUser { get; set; }

        public string LoginButtonName { get; set; } = "Login";

        public bool IsDisabledButton { get; set; }

        public AlertMessageDialogBox DeleteConfirmAlertMessageBox { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoginUser = new LoginViewModel();
            LoginUser.UserName = "adminakt";
            LoginUser.Password = "adminakt131218";
            return base.OnInitializedAsync();
        }


        protected async Task ValidateUser()
        {
            LoginButtonName = "Please Wait";
            IsDisabledButton = true;
            LoginUserData user = new LoginUserData();
            user.UserName = LoginUser.UserName.Trim();
            user.Password = LoginUser.Password.Trim().EncryptPassword();
            if (LoginUser.Role == LoginUserRoleEnum.Owner)
            {
                try
                {
                    var result = await LoginUserService.LoginOwner(user);
                    if (result == null)
                    {
                        string alertMessage = "Incorrect username or password";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                        //LoginUser = new LoginViewModel();
                        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                    }
                    else
                    {
                        await LocalStorage.SetItemAsync("accessToken", result.AccessToken);
                        await LocalStorage.SetItemAsync("refreshToken", result.RefreshToken);
                        if (LoginUser.IsRemember)
                        {
                            await LocalStorage.SetItemAsync("userName", result.UserName.EncryptPassword());
                            //await LocalStorage.SetItemAsync("ownerId", result.OwnerId.ToString());
                            await LocalStorage.SetItemAsync("userRole", LoginUser.Role.ToString().EncryptPassword());                       
                        }
                        else
                        {
                            await SessionStorage.SetItemAsync("userName", result.UserName.EncryptPassword());
                            //await SessionStorage.SetItemAsync("ownerId", result.OwnerId.ToString());
                            await SessionStorage.SetItemAsync("userRole", LoginUser.Role.ToString().EncryptPassword());
                        }
                        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsAuthenticated(result.UserName, LoginUser.Role.ToString());


                        NavigationManager.NavigateTo("/ownerPage");

                        //if (LoginUser.Role == LoginUserRoleEnum.Owner)
                        //{
                        //    NavigationManager.NavigateTo("/ownerPage");
                        //}
                        //else if (LoginUser.Role == LoginUserRoleEnum.Agent)
                        //{
                        //    NavigationManager.NavigateTo("/agentPage");
                        //}
                        //else
                        //{
                        //    InvalidLoginErrorMessage = "The role you choose is not supported";
                        //    //LoginUser = new LoginViewModel();
                        //    ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                        //}
                        //else if (LoginUser.Role == LoginUserRoleEnum.Player)
                        //{
                        //    NavigationManager.NavigateTo("/playerPage");
                        //}

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Response status code does not indicate success: 404 (Not Found).")
                    {
                        string infoMessage = "Invalid UserName or Password";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                    }
                    else
                    {
                        string infoMessage = "Cannot connect to server";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                    }
                    //LoginUser = new LoginViewModel();
                    ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                }
            }
            else if (LoginUser.Role == LoginUserRoleEnum.Agent)
            {
                try
                {
                    var result = await LoginUserService.LoginAgent(user);
                    if (result == null)
                    {
                        string infoMessage = "Incorrect username or password";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                        //LoginUser = new LoginViewModel();
                        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                    }
                    else
                    {
                        await LocalStorage.SetItemAsync("accessToken", result.AccessToken);
                        await LocalStorage.SetItemAsync("refreshToken", result.RefreshToken);
                        if (LoginUser.IsRemember)
                        {
                            await LocalStorage.SetItemAsync("userName", result.UserName.EncryptPassword());
                            //await LocalStorage.SetItemAsync("ownerId", result.OwnerId.ToString());
                            await LocalStorage.SetItemAsync("userRole", LoginUser.Role.ToString().EncryptPassword());
                        }
                        else
                        {
                            await SessionStorage.SetItemAsync("userName", result.UserName.EncryptPassword());
                            //await SessionStorage.SetItemAsync("ownerId", result.OwnerId.ToString());
                            await SessionStorage.SetItemAsync("userRole", LoginUser.Role.ToString().EncryptPassword());
                        }

                        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsAuthenticated(result.UserName, LoginUser.Role.ToString());

                        NavigationManager.NavigateTo("/agentPage");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Response status code does not indicate success: 404 (Not Found).")
                    {
                        string infoMessage = "Invalid UserName or Password";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                    }
                    else
                    {
                        string infoMessage = "Cannot connect to server";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                    }
                    //LoginUser = new LoginViewModel();
                    ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                }
            }
            else if(LoginUser.Role == LoginUserRoleEnum.Player)
            {
                try
                {
                    var result = await LoginUserService.LoginPlayer(user);
                    if (result == null)
                    {
                        string alertMessage = "Incorrect username or password";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                        //LoginUser = new LoginViewModel();
                        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                    }
                    else
                    {
                        await LocalStorage.SetItemAsync("accessToken", result.AccessToken);
                        await LocalStorage.SetItemAsync("refreshToken", result.RefreshToken);
                        if (LoginUser.IsRemember)
                        {
                            await LocalStorage.SetItemAsync("userName", result.UserName.EncryptPassword());
                            //await LocalStorage.SetItemAsync("ownerId", result.OwnerId.ToString());
                            await LocalStorage.SetItemAsync("userRole", LoginUser.Role.ToString().EncryptPassword());
                        }
                        else
                        {
                            await SessionStorage.SetItemAsync("userName", result.UserName.EncryptPassword());
                            //await SessionStorage.SetItemAsync("ownerId", result.OwnerId.ToString());
                            await SessionStorage.SetItemAsync("userRole", LoginUser.Role.ToString().EncryptPassword());
                        }
                        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsAuthenticated(result.UserName, LoginUser.Role.ToString());


                        NavigationManager.NavigateTo("/agentPage");

                        //if (LoginUser.Role == LoginUserRoleEnum.Owner)
                        //{
                        //    NavigationManager.NavigateTo("/ownerPage");
                        //}
                        //else if (LoginUser.Role == LoginUserRoleEnum.Agent)
                        //{
                        //    NavigationManager.NavigateTo("/agentPage");
                        //}
                        //else
                        //{
                        //    InvalidLoginErrorMessage = "The role you choose is not supported";
                        //    //LoginUser = new LoginViewModel();
                        //    ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                        //}
                        //else if (LoginUser.Role == LoginUserRoleEnum.Player)
                        //{
                        //    NavigationManager.NavigateTo("/playerPage");
                        //}

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Response status code does not indicate success: 404 (Not Found).")
                    {
                        string infoMessage = "Invalid UserName or Password";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                    }
                    else
                    {
                        string infoMessage = "Cannot connect to server";
                        await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                    }
                    //LoginUser = new LoginViewModel();
                    ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
                }
            }
            else
            {
                string infoMessage = "The role you choosed is not supported";
                await DeleteConfirmAlertMessageBox.ShowOrHideDialogBox(infoMessage, true, true);
                //LoginUser = new LoginViewModel();
                ((CustomAuthenticationStateProvider)AuthenticationStateProvider).DigitUserAsLogOut();
            }

            LoginButtonName = "Login";
            IsDisabledButton = false;
        }
    }
}
