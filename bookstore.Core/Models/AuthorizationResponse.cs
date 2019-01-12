namespace bookstore.Core.Models
{
    public class AuthorizationResponse
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }

        public UserModel User { get; set; }
    }
}
