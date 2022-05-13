using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using aspnet_core_dotnet_core.Data;


namespace aspnet_core_dotnet_core.repo
{
    public class MoviesRepo
    {
        public const string dbConnectionString =
            "Server=tcp:sep6movies.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=Florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";

        public ArrayList GetMovies()
        {
            ArrayList Movies = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT TOP (200) * FROM [dbo].[movies]";

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


                                Movies.Add(movie);
                            }
                        }
                    }
                }

                return Movies;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Movies;
            }
        }

        public ArrayList SearchMovieByName(string movieName)
        {
            ArrayList Movies = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT TOP (200) * FROM [dbo].[movies]";

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

                                if (movie.movieTitle.Contains(movieName))
                                {
                                    Movies.Add(movie);
                                }


                            }
                        }
                    }
                }

                return Movies;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


        public ArrayList SearchMovieById(int idMovie)
        {
            ArrayList Movies = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT TOP (200) * FROM [dbo].[movies]";

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

                                if (movie.movieId == idMovie)
                                {
                                    Movies.Add(movie);
                                }

                            }
                        }
                    }
                }

                return Movies;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


        public ArrayList SearchMovieByActorName(string actorName)
        {
            ArrayList Movies = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql =
                        "SELECT movies.id, title, year FROM [dbo].[movies] AS movies JOIN [dbo].[stars] AS stars ON movies.id = stars.movie_id JOIN [dbo].[people] AS people ON people.id = stars.person_id WHERE people.name LIKE '%"+actorName+"%'";
                    

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandTimeout = 100; 
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();

                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);

                                Movies.Add(movie);
                                
                            }
                        }
                    }
                }

                return Movies;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
        
        public ArrayList SearchMovieByDirectorName(string directorName)
        {
            ArrayList Movies = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql =
                        "SELECT  movies.id, title, year FROM [dbo].[movies] AS movies JOIN [dbo].[directors] AS directors ON movies.id = directors.movie_id JOIN [dbo].[people] AS people ON people.id = directors.person_id WHERE people.name LIKE '%"+directorName+"%'";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandTimeout = 100; 
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();

                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);

                                Movies.Add(movie);
                                Console.WriteLine(movie.movieTitle);
                                
                            }
                        }
                    }
                }

                return Movies;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}


    
