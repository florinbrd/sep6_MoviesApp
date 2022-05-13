﻿using System;
using System.Collections;
using aspnet_core_dotnet_core.Data;
using Microsoft.Data.SqlClient;

namespace aspnet_core_dotnet_core.repo
{
    public class ActorsRepository
    {
        
        
        public ArrayList SearchActorByMovieId(int id)
        {
            ArrayList Actors = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                { 
                    connection.Open();
                    
                    String sql = "SELECT  name FROM [dbo].[people] AS people JOIN [dbo].[stars] AS stars ON people.id = stars.person_id JOIN [dbo].[movies] AS movies ON movies.id = stars.movie_id WHERE movies.id = '" + id + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                People people = new People();
                                people.name = reader.GetString(index++);

                                Actors.Add(people);
                            }
                        }
                    }
                }

                return Actors; 

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


    }
}