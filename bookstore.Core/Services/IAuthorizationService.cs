using bookstore.Core.Models;

namespace bookstore.Core.Services
{
    public interface IAuthorizationService
    {
        AuthorizationResponse Authorize(AuthorizationRequest request);
    }
}
