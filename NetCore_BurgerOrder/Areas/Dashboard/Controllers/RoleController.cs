using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppRole appRole)
        {
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded) 
            { 
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }
    }
}
