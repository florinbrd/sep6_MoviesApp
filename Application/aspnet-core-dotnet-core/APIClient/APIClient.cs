using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.Data;

namespace aspnet_core_dotnet_core.APIClient
{
    public class APIClient
    {
        private static HttpClient client = new HttpClient();
        public MovieDetails movieDetails;


        public async Task<MovieDetails> getMovieDetails(int id)
        {
            movieDetails = new MovieDetails();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = client.GetStreamAsync($"http://www.omdbapi.com/?apikey=49c14572&i=tt00{id}&plot=full");
            var options = new JsonSerializerOptions();
            MovieDetails m = await JsonSerializer.DeserializeAsync<MovieDetails>(await streamTask, options);

            movieDetails.Title = m.Title;
            movieDetails.Poster = m.Poster; 
            movieDetails.Year = m.Year; 
            movieDetails.Genre = m.Genre; 
            movieDetails.Plot = m.Plot; 
            movieDetails.Awards = m.Awards; 
            movieDetails.Country = m.Country;
            movieDetails.Language = m.Language;
            
            return movieDetails;
        }

    }
}