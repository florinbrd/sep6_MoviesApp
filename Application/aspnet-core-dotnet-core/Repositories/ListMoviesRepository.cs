using System;
using System.Collections;
using aspnet_core_dotnet_core.Data;
using Microsoft.Data.SqlClient;

namespace aspnet_core_dotnet_core.repo
{
    public class ListMoviesRepository
    {
        public const string dbConnectionString =
            "Server=tcp:sep6movies.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=Florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";

        public ArrayList GetMoviesList(string email)
        {
            ArrayList Movies = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql =
                        "SELECT id,title, year FROM [dbo].[movies] as movies JOIN [dbo].[listmovies] AS listmovies ON movies.id = listmovies.movie_id WHERE listmovies.user_email = '" +
                        email + "'";
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
                return Movies;
            }
        }

        public void AddToMovieList(int id, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO [dbo].[listmovies] (user_email, movie_id) VALUES ('" + email + "', " +
                                 id + ")";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.CommandTimeout = 100;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());

            }
        }

        public void removeMovieFromList(int id, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM [dbo].[listmovies] WHERE movie_id =" + id + " AND user_email ='" + email + "'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.CommandTimeout = 100;
                    command.ExecuteNonQuery(); 
                    command.Dispose();
                    connection.Close();

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());

            }
        }
        }
    }

