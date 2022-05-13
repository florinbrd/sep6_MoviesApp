using System;
using System.Collections;
using aspnet_core_dotnet_core.Data;
using Microsoft.Data.SqlClient;

namespace aspnet_core_dotnet_core.repo
{
    public class RatingsRepository
    {
        private const string dbConnectionString =
            "Server=tcp:sep6movies.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=Florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";

        public ArrayList GetRatings()
        {
            ArrayList Ratings = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT  * FROM [dbo].[ratings]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Ratings rating = new Ratings();
                                rating.movie_id = reader.GetInt32(index++);
                                rating.rating = reader.GetDouble(index++);
                                rating.votes = reader.GetInt32(index++);


                                Ratings.Add(rating);
                            }
                        }
                    }
                }

                return Ratings;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Ratings;
            }
        }


        public ArrayList SearchRatingByMovieId(int movie_id)
        {
            ArrayList Ratings = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT  * FROM [dbo].[ratings]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Ratings rating = new Ratings();
                                rating.movie_id = reader.GetInt32(index++);
                                rating.rating = reader.GetDouble(index++);
                                rating.votes = reader.GetInt32(index++);

                                if (rating.movie_id == movie_id)
                                {
                                    Ratings.Add(rating);

                                }


                            }
                        }
                    }
                }

                return Ratings;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
