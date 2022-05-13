using System.Collections;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Services
{
    public class ListMovieService
    {
        private ListMoviesRepository listMoviesRepository = new ListMoviesRepository();

        public void AddMovieToList(string email, int id)
        {
            listMoviesRepository.AddToMovieList(id, email);
        }

        public void RemoveMovieFromList(string email, int id)
        {
            listMoviesRepository.removeMovieFromList(id, email);
        }

        public Movie[] getMovieList(string email)
        {
            ArrayList movies = listMoviesRepository.GetMoviesList(email); 
            Movie[] moviesArr = new Movie[movies.Count];
            
            if (movies.Count!=0)
            {
                for (int i = 0; i < movies.Count; i++)
                {
                    moviesArr[i] = (Movie) movies[i];
                }
            }
            
            return moviesArr;
        }
        }
        
        
    }
