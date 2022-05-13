using System;
using System.Collections;
using aspnet_core_dotnet_core.Data;
using Microsoft.Data.SqlClient;

namespace aspnet_core_dotnet_core.repo
{
    public class CommentsRepository
    {
        public ArrayList SearchCommentsByMovieId(int id, string email)
        {
            ArrayList Comments = new ArrayList();

            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT  user_email,comments FROM [dbo].[comments]  WHERE movie_id = " + id + "and user_email = '" + email + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Comments comment = new Comments();

                                comment.Email = reader.GetString(index++);
                                comment.Comment = reader.GetString(index++);
                                Comments.Add(comment);
                            }
                        }
                    }
                }

                return Comments;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }




        public void insertComment(int movieId, string email, string comment)
        {


            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();

                    String sql = "INSERT INTO  [dbo].[comments]   (user_email,comments,movie_id) VALUES ('" + email + "','" + comment + "'," + movieId + ")";




                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        command.Dispose();
                        connection.Close();
                    }

                }



            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());

            }
        }

       




    }
}

