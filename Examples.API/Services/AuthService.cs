using Examples.Domain;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace Examples.Presentation.API
{
    internal sealed class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        IIdentity IAuthService.Identity => httpContextAccessor.HttpContext.User.Identity;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}
