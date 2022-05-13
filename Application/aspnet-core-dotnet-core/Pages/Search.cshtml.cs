using System.Collections.Generic;
using System.Linq;
using aspnet_core_dotnet_core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class Search : PageModel
    {
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public string SearchStringActor { get; set; }
        [BindProperty]
        public string SearchStringDirector { get; set; }
        public IList<Movie> listMovies { get; set;  }

        public MoviesService moviesService;

        public LoginCredentials loginCredentials;

        public  Search(LoginCredentials loginCredentials)
        {
            this.loginCredentials = loginCredentials; 
        }
        
        public void OnGet()
        {
            moviesService = new MoviesService();
            listMovies = new List<Movie>(); 
            listMovies = moviesService.GetAllMovies(); 

        }
    
        public void OnPostSubmit()
        {           
            moviesService = new MoviesService();
            listMovies = moviesService.searchMovieByName(SearchString).ToList();
       
        }
        
        public void OnPostRegister()
        {
            moviesService = new MoviesService();
            listMovies = moviesService.searchMovieByActor(SearchStringActor).ToList();

        }
        
        public void OnPostSearch()
        {
            moviesService = new MoviesService();
            listMovies = moviesService.searchMovieByDirector(SearchStringDirector).ToList();
            
        }


    }
}