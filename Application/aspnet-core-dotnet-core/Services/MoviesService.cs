using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Data
{
    public class MoviesService
    {
        MoviesRepo moviesRepo = new MoviesRepo();
        public Movie[] GetAllMovies()
        {
            ArrayList movies = moviesRepo.GetMovies();
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


        public Movie[] searchMovieByName(string movieName)
        {
            ArrayList movies = moviesRepo.SearchMovieByName(movieName);
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

        public Movie[] searchMovieById(int idMovie)
        {
            ArrayList movies = moviesRepo.SearchMovieById(idMovie);
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
        
        public Movie[] searchMovieByActor(string actorName)
        {
            ArrayList movies = moviesRepo.SearchMovieByActorName(actorName);
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
        
        public Movie[] searchMovieByDirector(string directorName)
        {
            ArrayList movies = moviesRepo.SearchMovieByDirectorName(directorName);
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
