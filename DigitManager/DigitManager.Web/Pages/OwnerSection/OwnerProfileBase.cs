using DigitManager.ModelLibrary;
using DigitManager.ModelLibrary.MainAndSubRelation;
using DigitManager.Web.Services;
using DigitManager.Web.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitManager.Web.Pages.OwnerSection
{
    [Authorize(Roles = "Owner")]
    public class OwnerProfileBase : ComponentBase
    {
        [Inject]
        public IOwnerService ownerService { get; set; }

        public bool IsEditOwnerData { get; set; }

        public Owner Owner { get; set; } = new Owner();

        public string SerializeOwner = "";

        public bool IsChangePasswordClick { get; set; }

        public string ChangePassword { get; set; }

        public string ConfirmPassword { get; set; }

        public string PasswordValidationMessage { get; set; }

        public string ConfirmPasswordValidationMessage { get; set; }

        public string OldPassword { get; set; }

        public string OldPasswordValidationMessage { get; set; }

        public bool IsLoading { get; set; }

        protected AlertMessageDialogBox AlertMessageBox { get; set; }

        public string TestString { get; set; } = "";

        protected async override Task OnInitializedAsync()
        {
            Owner = (await ownerService.GetOwners()).FirstOrDefault();
            SerializeOwner = Owner == null ? "" : JsonConvert.SerializeObject(Owner);
            await base.OnInitializedAsync();
        }

        public async Task ValidateOwner()
        {
            IsLoading = true;
            try
            {
                var result = await ownerService.UpdateOwner(Owner);
                if(result != null)
                {
                    string infoMessage = "Update Successful!";
                    Owner = new Owner();
                    Owner = (await ownerService.GetOwners()).FirstOrDefault();
                    SerializeOwner = Owner == null ? "" : JsonConvert.SerializeObject(Owner);
                    await AlertMessageBox.ShowOrHideDialogBox(infoMessage, true, false);
                }
                else
                {
                    string alertMessage = "Error updating data!";
                    await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
                }
            }
            catch (Exception)
            {
                string alertMessage = "Error updating data!";
                await AlertMessageBox.ShowOrHideDialogBox(alertMessage, true, true);
            }
            IsLoading = false;
        }

        public void OldPasswordChange(ChangeEventArgs args)
        {
            string value = args.Value.ToString();
            CheckPasswordVaid(value, true);
        }

        public void NewPasswordChange(ChangeEventArgs args)
        {
            string value = args.Value.ToString();
            CheckPasswordVaid(value, false);
        }

        public void ConfirmPasswordChange(ChangeEventArgs args)
        {
            string value = args.Value.ToString();
            CheckCompareConfirmPassword(value);
        }

        public void ChangePasswordConfirm()
        {

        }

        public void ChangePassword_Click()
        {
            IsChangePasswordClick = true;
            InitializeOwner();
        }

        public void CancelUpdate_Click()
        {
            IsChangePasswordClick = false;
            InitializeOwner();
        }

        private void InitializeOwner()
        {
            Owner = new Owner();
            Owner = JsonConvert.DeserializeObject<Owner>(SerializeOwner);
            ChangePassword = "";
            ConfirmPassword = "";
            OldPassword = "";
            PasswordValidationMessage = "";
            ConfirmPasswordValidationMessage = "";
            OldPasswordValidationMessage = "";
        }

        protected bool CheckPasswordVaid(string inputString, bool isOldPassword)
        {
            inputString = inputString ?? "";
            if (!string.IsNullOrWhiteSpace(inputString.Trim()))
            {
                Regex re = new Regex(@"^([A-Za-z0-9]{4,30})*$", RegexOptions.IgnoreCase);
                if (!re.IsMatch(inputString.Trim()))
                {
                    if (isOldPassword)
                    {
                        OldPasswordValidationMessage = "Not allow whitespace and special characters. Must be between 4 and 30 characters.";
                    }
                    else
                    {
                        PasswordValidationMessage = "Not allow whitespace and special characters. Must be between 4 and 30 characters.";
                    }
                    return false;
                }
                else
                {
                    if (isOldPassword)
                    {
                        OldPasswordValidationMessage = "";
                    }
                    else
                    {
                        PasswordValidationMessage = "";
                    }
                    return true;
                }
            }
            else
            {
                if (isOldPassword)
                {
                    OldPasswordValidationMessage = "Please Enter New Password";
                }
                else
                {
                    PasswordValidationMessage = "Please Enter New Password";
                }
                return false;
            }
        }

        protected bool CheckCompareConfirmPassword(string inputString)
        {
            if(inputString == ChangePassword)
            {
                ConfirmPasswordValidationMessage = "";
                return true;
            }
            else
            {
                ConfirmPasswordValidationMessage = "Password and confirm password must match!";
                return false;
            }
        }

        public void OnTestInput(ChangeEventArgs args)
        {
            string value = args.Value.ToString();
            Regex regex = new Regex(NumStringValidateRegex.regexTwoOdd, RegexOptions.IgnoreCase);
            if (regex.IsMatch(value))
            {
                TestString = "";
            }
            else
            {
                TestString = "Invalid regex";
            }
        }
    }
}
