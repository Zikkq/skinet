using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public sealed class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string BasketId { get; set; }
        public Address Address { get; set; }
    }
}