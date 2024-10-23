using Microsoft.AspNetCore.Identity;

namespace NetCore_BurgerOrder.Models.Entities
{
    public class AppUser:IdentityUser
    {
        public string? Address { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
