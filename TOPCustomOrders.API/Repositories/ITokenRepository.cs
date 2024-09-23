using Microsoft.AspNetCore.Identity;

namespace TOPCustomOrders.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
