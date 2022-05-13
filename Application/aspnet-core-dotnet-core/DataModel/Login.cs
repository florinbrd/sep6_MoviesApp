


using Microsoft.AspNetCore.Mvc;
namespace aspnet_core_dotnet_core.Data
{
    public class Login
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
    }
}