using Microsoft.AspNetCore.Identity;

namespace EventWhiz.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
