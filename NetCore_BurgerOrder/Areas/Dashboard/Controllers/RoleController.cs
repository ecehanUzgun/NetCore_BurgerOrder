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
            return View(_roleManager.Roles.ToList());
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

        //Update
        public async Task<IActionResult> Update(string id)
        {
            var updated = await _roleManager.FindByIdAsync(id);
            if (updated != null)
            {
                return View(updated);
            }
            return RedirectToAction("Index");
            TempData["Message"] = "Kullanıcı Rolü Güncellenemedi!";
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppRole appRole)
        {
            var role = await _roleManager.FindByIdAsync(appRole.Id.ToString());
            if (ModelState.IsValid)
            {
               role.Name = appRole.Name;
               role.Description = appRole.Description;

                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    TempData["Message"] = "Rol başarıyla güncellendi";
                    return RedirectToAction("Index");
                }
            }
            
            return View(appRole);
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
