using System.Collections.Generic;
using System.Linq;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class ListOfMovies : PageModel
    {
        public LoginCredentials loginCredentials;
        public IList<Movie> movies { get; set; }
        public ListMovieService listMovieService;

        public ListOfMovies(LoginCredentials loginCredentials)
        {
            this.loginCredentials = loginCredentials; 
        }
        
        public void OnGet()
        {
            listMovieService = new ListMovieService();
            movies = new List<Movie>();
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