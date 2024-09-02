
using UserTable.Models;

namespace jwt_token_auth.anotherAPI.Models
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Username = user.Username;
            Token = token;
        }
    }
}
