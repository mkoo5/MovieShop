using System.Collections.Generic;
using System.Security.Claims;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string FullName { get; }
        string ProfilePicture { get; }
        string RemoteIpAddress { get; }
        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }
        IEnumerable<Claim> GetClaimsIdentity();
        IEnumerable<string> Roles { get; }
    }
}