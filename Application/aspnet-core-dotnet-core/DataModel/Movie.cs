using System;
using System.Text.Json.Serialization;

namespace aspnet_core_dotnet_core.Data
{
    public class Movie
    {


        public int movieId { get; set; }

        public string movieTitle { get; set; }

        public int movieYear { get; set; }

        public double rating { get; set; }
        public int votes { get; set; }

        public string email { get; set; }

        public int movieCount { get; set; }
    }
}
