using System.Linq;
using bookstore.Core.Models;
using bookstore.Shared;
using bookstore.Shared.Entities;

namespace bookstore.Core.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly BookstoreDbContext _context;

        public AuthorizationService(BookstoreDbContext context)
        {
            _context = context;
        }
        
        public AuthorizationResponse Authorize(AuthorizationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return ErrorResponse();
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return ErrorResponse();
            }

            User user = _context.User.FirstOrDefault(x => x.Username == request.Username);

            if (user == null || user.Password != request.Password)
            {
                return ErrorResponse();
            }

            return SuccessResponse(user);
        }

        private static AuthorizationResponse ErrorResponse() => 
            new AuthorizationResponse
            {
                AuthorizationStatus = AuthorizationStatus.Error
            };

        private static AuthorizationResponse SuccessResponse(User user) =>
            new AuthorizationResponse
            {
                AuthorizationStatus = AuthorizationStatus.Success,
                User = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = user.Roles.Select(x=> x.Name.ToLower()).ToList(),
                    ShoppingCartItems = user.ShoppingCartItems
                }
            };
    }
}