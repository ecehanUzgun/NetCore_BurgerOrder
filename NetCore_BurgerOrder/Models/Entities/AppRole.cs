using Microsoft.AspNetCore.Identity;

namespace NetCore_BurgerOrder.Models.Entities
{
    public class AppRole:IdentityRole<int>
    {
        public string? Description { get; set; }
    }
}
