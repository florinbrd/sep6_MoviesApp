

using System.Collections;


namespace aspnet_core_dotnet_core.Data
{
    public class MovieList
    {

        public ArrayList movies { get; set; }
        public MovieList()
        {

        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public void Remove(Movie movie)
        {
            movies.Remove(movie);
        }

        public ArrayList GetMovies()
        {
            return movies;
        }


    }
}
