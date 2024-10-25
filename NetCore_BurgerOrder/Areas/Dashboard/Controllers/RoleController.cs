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
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(string id) 
        {
            var deleted = await _roleManager.FindByIdAsync(id);
            if (deleted != null)
            {
                return View(deleted);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppRole appRole)
        {
            _roleManager.DeleteAsync(appRole);
            TempData["Status"] = "Ürün başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
