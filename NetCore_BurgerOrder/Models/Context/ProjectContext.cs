using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder.Models.Context
{
    public class ProjectContext:IdentityDbContext<AppUser>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {
            
        }

        public ProjectContext()
        {
            
        }
    }
}
