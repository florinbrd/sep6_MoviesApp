using System.Collections;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Services
{
    public class DirectorsService
    {
        private DirectorsRepository directorsRepository = new DirectorsRepository();
        
        public People[] searchMovieById(int movieId)
        {
            ArrayList directors = directorsRepository.SearchDirectorByMovieId(movieId);
            People[] peopleArr = new People[directors.Count];
            
            if (directors.Count!=0)
            {
                for (int i = 0; i < directors.Count; i++)
                {
                    peopleArr[i] = (People) directors[i];
                }
            }
            
            return peopleArr;
        }
    }
}