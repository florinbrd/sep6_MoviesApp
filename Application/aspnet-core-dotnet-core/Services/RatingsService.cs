using System.Collections;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Services
{
    public class RatingsServices
    {
        RatingsRepository ratingsRepository = new RatingsRepository();
        
        public Ratings[] GetAllRatings()
        {
            ArrayList ratings = ratingsRepository.GetRatings();
            Ratings[] ratingsArray = new Ratings[ratings.Count];
            
            if (ratings.Count!=0)
            {
                for (int i = 0; i < ratings.Count; i++)
                {
                    ratingsArray[i] = (Ratings) ratings[i];
                }
            }
            
            return ratingsArray;
        }


        public Ratings[] searchMovieByName(int movieId)
        {
            ArrayList ratings = ratingsRepository.SearchRatingByMovieId(movieId);
            Ratings[] ratingsArray = new Ratings[ratings.Count];
            
            if (ratings.Count!=0)
            {
                for (int i = 0; i < ratings.Count; i++)
                {
                    ratingsArray[i] = (Ratings) ratings[i];
                }
            }
            
            return ratingsArray;
        }

         

  
    }
    }
