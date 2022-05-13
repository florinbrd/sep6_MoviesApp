namespace aspnet_core_dotnet_core.Data
{
    public class LoginCredentials
    {
        public string email { get; set; } = "";



        public LoginCredentials()
        {
        
        }
        public LoginCredentials(string email)
        {
            this.email = email; 
        }
    }
}