using Microsoft.AspNetCore.Identity;

namespace NetCore_BurgerOrder.Models.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }

        //Relational Properties
        public List<Order>? Orders { get; set; }
    }
}
