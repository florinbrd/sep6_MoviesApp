using System.Text.Json.Serialization;

namespace aspnet_core_dotnet_core.Data
{
    public class MovieDetails
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        
        [JsonPropertyName("Year")]
        public string Year { get; set; }
        
        [JsonPropertyName("Genre")]
        public string Genre { get; set; }
        
        [JsonPropertyName("Plot")]
        public string Plot { get; set; }
        
        [JsonPropertyName("Awards")]
        public string Awards { get; set; }
        
        [JsonPropertyName("Poster")]
        public string Poster { get; set; }
        
        [JsonPropertyName("Country")]
        public string Country { get; set; }
        
        [JsonPropertyName("Language")]
        public string Language { get; set; }
        
    }
}