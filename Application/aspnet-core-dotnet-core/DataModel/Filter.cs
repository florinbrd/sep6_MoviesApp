


using Microsoft.AspNetCore.Mvc;
namespace aspnet_core_dotnet_core.Data
{
    public class Filter
    {
        [BindProperty]
        public string Director { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string FilterType { get; set; }

        public string Value { get; set; }
    }
}