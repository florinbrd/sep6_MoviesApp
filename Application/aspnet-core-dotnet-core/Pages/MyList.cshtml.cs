using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class MyList : PageModel
    {
        public LoginCredentials loginCredentials;
        public IList<Movie> movies { get; set; }
        public ListMovieService listMovieService; 
        

        public MyList(LoginCredentials loginCredentials)
        {
            this.loginCredentials = loginCredentials; 
        }
        
        public void OnGet([FromRoute] int id)
        {
            listMovieService = new ListMovieService(); 
            listMovieService.AddMovieToList(loginCredentials.email, id);

            movies = listMovieService.getMovieList(loginCredentials.email).ToList();

        }

        public void OnPostDelete(int id)
        {

            listMovieService = new ListMovieService(); 
            listMovieService.RemoveMovieFromList(loginCredentials.email,id);

            movies = listMovieService.getMovieList(loginCredentials.email).ToList();
        }
        
    }
}