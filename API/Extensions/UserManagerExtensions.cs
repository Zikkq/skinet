using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            return await GetUserByClaimsPrincipal(input, user).Include(x => x.Address).SingleOrDefaultAsync();
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            return await GetUserByClaimsPrincipal(input, user).SingleOrDefaultAsync();
        }

        private static IQueryable<AppUser> GetUserByClaimsPrincipal(UserManager<AppUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal?.FindFirstValue(ClaimTypes.Email);
            return userManager.Users.Where(x => x.Email == email);
        }
    }
}