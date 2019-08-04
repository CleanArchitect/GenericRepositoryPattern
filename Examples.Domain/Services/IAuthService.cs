using System.Security.Principal;

namespace Examples.Domain
{
    public interface IAuthService
    {
        IIdentity Identity { get; }
    }
}
