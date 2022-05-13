using System.Collections;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Services
{
    public class ActorsService
    {
        private ActorsRepository actorsRepository = new ActorsRepository(); 
        
        public People[] searchMovieById(int movieId)
        {
            ArrayList actors = actorsRepository.SearchActorByMovieId(movieId);
            People[] peopleArr = new People[actors.Count];
            
            if (actors.Count!=0)
            {
                for (int i = 0; i < actors.Count; i++)
                {
                    peopleArr[i] = (People) actors[i];
                }
            }
            
            return peopleArr;
        }
    }
}