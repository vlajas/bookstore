using System;
using bookstore.Core.Models;
using bookstore.Core.Services;
using bookstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("[action]")]
        public AuthorizationResponse Authorize([FromBody]AuthorizationRequest request)
        {
            AuthorizationResponse response = _authorizationService.Authorize(request);

            return response;
        }

        [HttpPost]
        [Route("[action]")]
        public bool Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
