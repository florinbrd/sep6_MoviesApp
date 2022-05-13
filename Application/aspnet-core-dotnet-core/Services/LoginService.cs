

using Firebase.Auth.Payloads;
using Firebase.Auth;
using System.Threading.Tasks;
using System;


namespace aspnet_core_dotnet_core.Data
{
    public class LoginService
    {
        private readonly IFirebaseAuthService _firebase;

        public LoginService(IFirebaseAuthService firebase)
        {
            _firebase = firebase;
        }
        public async Task<string> SignUpAsync(string username, string password)
        {


            System.Diagnostics.Debug.WriteLine("Sign up works");
            SignUpNewUserRequest request = new SignUpNewUserRequest()
            {
                Email = username,
                Password = password
            };
            try
            {
                System.Diagnostics.Debug.WriteLine("Try works");
                var response = await _firebase.SignUpNewUser(request);
                string message = "Registered";
                return message;

            }
            catch (FirebaseAuthException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR IN CATCH");
                System.Diagnostics.Debug.WriteLine(e.ResponseJson);
                return e.Error.Message;
            }
        }
      
        public async Task<string> SignIn(String username, String password)
        {
            System.Diagnostics.Debug.WriteLine("Sign IN works");
            var request = new VerifyPasswordRequest()
            {
                Email = username,
                Password = password
            };

            System.Diagnostics.Debug.WriteLine(request.Email+" " +request.Password);



            try
            {
                System.Diagnostics.Debug.WriteLine("Try works");
                var response = await _firebase.VerifyPassword(request);
                string message = "Logged in succesfully";
                return message;
            }
            catch (FirebaseAuthException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR IN CATCH");
                System.Diagnostics.Debug.WriteLine(e.ResponseJson);
                return e.Error.Message;
            }

        }



    }


}

