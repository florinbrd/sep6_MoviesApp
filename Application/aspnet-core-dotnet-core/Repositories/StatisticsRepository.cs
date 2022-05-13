using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using aspnet_core_dotnet_core.Data;


namespace aspnet_core_dotnet_core.repo
{
    public class StatisticsRepository
    {
        public const string dbConnectionString =
            "Server=tcp:sep6movies.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=Florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";

        public Movie[] getTop10VotedMovies(Filter filter)
        {
            ArrayList Movies = new ArrayList();
            Movie[] movieArr;
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                   

                    String sql = "SELECT TOP(10) id,title,year,rating,votes FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id order by votes desc";

                    if (filter.Value != null)
                    {

                        if (filter.FilterType.Equals("Director"))
                        {
                            sql = "SELECT TOP(10) m.id,title,year,rating,votes, p.name FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id  join[directors] as d on d.movie_id = m.id join[people] as p on d.person_id = p.id WHERE p.name LIKE '" + filter.Value + "' order by votes desc";
                        }
                        if (filter.FilterType.Equals("Year"))
                        {
                            sql = "SELECT TOP(10) m.id,title,year,rating,votes, p.name FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id  join[directors] as d on d.movie_id = m.id join[people] as p on d.person_id = p.id WHERE m.year = " + filter.Value + " order by votes desc";
                        }

                    }

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();
                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);
                                movie.rating = reader.GetDouble(index++);                              
                                movie.votes = reader.GetInt32(index++);
                                Movies.Add(movie);
                            }
                        }
                    }
                }

                if (Movies != null)
                {
                    movieArr = new Movie[Movies.Count];

                    if (Movies.Count != 0)
                    {
                        for (int i = 0; i < Movies.Count; i++)
                        {
                            movieArr[i] = (Movie)Movies[i];
                        }
                        return movieArr;
                    }
                }
                return new Movie[1];
              

               
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return new Movie[1];
            }
        }


        public Movie[] getTop10RatedMovies(Filter filter)
        {
            ArrayList Movies = new ArrayList();
            Movie[] movieArr;
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();


                    String sql = "SELECT TOP(10) id,title,year,rating,votes FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id order by rating desc";
                    if (filter.Value != null)
                    {

                        if (filter.FilterType.Equals("Director"))
                        {
                            sql = "SELECT TOP(10) m.id,title,year,rating,votes, p.name FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id  join[directors] as d on d.movie_id = m.id join[people] as p on d.person_id = p.id WHERE p.name LIKE '" + filter.Value + "' order by rating desc";
                        }
                        if (filter.FilterType.Equals("Year"))
                        {
                            sql = "SELECT TOP(10) m.id,title,year,rating,votes, p.name FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id  join[directors] as d on d.movie_id = m.id join[people] as p on d.person_id = p.id WHERE m.year = " + filter.Value + " order by rating desc";
                        }

                    }
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();
                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);
                                movie.rating = reader.GetDouble(index++);
                                movie.votes = reader.GetInt32(index++);
                                Movies.Add(movie);
                            }
                        }
                    }
                }

                if (Movies != null)
                {
                    movieArr = new Movie[Movies.Count];

                    if (Movies.Count != 0)
                    {
                        for (int i = 0; i < Movies.Count; i++)
                        {
                            movieArr[i] = (Movie)Movies[i];
                        }
                        return movieArr;
                    }
                }
                return new Movie[1];



            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return new Movie[1];
            }
        }


        public Movie[] UsersFavourites(Filter filter)
        {

            ArrayList Movies = new ArrayList();
            Movie[] movieArr;

            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                    String sql = " SELECT top(10) cast(title as varchar(30)), COUNT(m.id)   FROM[dbo].[listmovies] as l join movies as m on m.id = l.movie_id group by cast(title as varchar(30))  order by count(m.id)";
                    if (filter.Value != null)
                    {

                        if (filter.FilterType.Equals("Director"))
                        {
                            sql = "SELECT top(10) cast(title as varchar(30)), COUNT(m.id)   FROM[dbo].[listmovies] as l join movies as m on m.id = l.movie_id join[ratings] as r on m.id = r.movie_id  join[directors] as d on d.movie_id = m.id join[people] as p on d.person_id = p.id WHERE p.name LIKE '" + filter.Value + "' group by cast(title as varchar(30))  order by count(m.id)";


                        }
                        if (filter.FilterType.Equals("Year"))
                        {
                            sql = " SELECT top(10) cast(title as varchar(30)), COUNT(m.id)   FROM[dbo].[listmovies] as l join movies as m on m.id = l.movie_id group by cast(title as varchar(30)) where m.year = " + filter.Value + " order by count(m.id)";
                        }
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int index = 0;
                                    Movie movie = new Movie();

                                    movie.movieTitle = reader.GetString(index++);
                                    movie.movieCount = reader.GetInt32(index++);
                                    Movies.Add(movie);
                                }
                            }
                        }
                    }

                    if (Movies != null)
                    {
                        movieArr = new Movie[Movies.Count];

                        if (Movies.Count != 0)
                        {
                            for (int i = 0; i < Movies.Count; i++)
                            {
                                movieArr[i] = (Movie)Movies[i];
                            }
                            return movieArr;
                        }
                    }
                    return new Movie[1];
                }
            }




            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return new Movie[1];
            }
        }




    }
}


    
