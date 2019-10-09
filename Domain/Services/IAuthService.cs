using System.Security.Principal;

namespace Domain.Services
{
    public interface IAuthService
    {
        IIdentity Identity { get; }
    }
}
