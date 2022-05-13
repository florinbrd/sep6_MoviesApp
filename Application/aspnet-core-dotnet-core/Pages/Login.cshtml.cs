using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class LoginModel : PageModel
    {

        public LoginService _LoginService;

        public LoginCredentials _loginCredentials;

        public LoginModel (LoginService loginService, LoginCredentials loginCredentials)
        {
            _LoginService = loginService;
            _loginCredentials = loginCredentials;
        }

        [BindProperty]
        public string Succes { get; set; } = "";

        public void OnGet()
        {
          
        }

        public async void OnPostSubmit(Login login)
        {

            Succes =  _LoginService.SignIn(login.Email, login.Password).Result;
            validateLogin(login.Email);

        }
         
        public async void OnPostRegister(Login login)
        {
            Succes = _LoginService.SignUpAsync(login.Email, login.Password).Result;



        }

        public void validateLogin(string email)
        {
            if (Succes.Equals("Logged in succesfully"))
            {
                _loginCredentials.email = email;
            }


        }
        }

       
    
}