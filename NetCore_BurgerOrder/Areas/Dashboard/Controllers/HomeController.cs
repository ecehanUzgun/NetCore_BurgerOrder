using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();

            return View(_userManager.Users.ToList());
        }

        //User role update
        public async Task<IActionResult> Update(string id) 
        { 
            var user = await _userManager.FindByIdAsync(id);

            //SelectListItem

            //ViewBag.Roles
            ViewBag.Roles = _roleManager.Roles.Select(x => new SelectListItem
            {
                //Value: Seçim esnasında değer olarak ne tutulsun?
                //Text: Checkbox label içerisinde ne yazılacak?

                Text = x.Name,
                Value = x.Id.ToString()
                //Cannot implicitly convert type 'int' to 'string' =>Hatasını çözmek için ToString()
            });

            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUser appUser, string[] selectedRoleName)
        {
            var user = await _userManager.FindByIdAsync(appUser.Id.ToString());
            
            if (user != null) 
            {
                var roles = await _userManager.GetRolesAsync(user);

                var userAccount = await _userManager.FindByIdAsync(appUser.Id.ToString());
                //Önceki roller kaldırılır
                foreach (var deletedRole in roles) 
                { 
                    await _userManager.RemoveFromRoleAsync(user, deletedRole);
                }

                //Yeni roller eklenir
                foreach (var role in selectedRoleName)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }

                if (ModelState.IsValid)
                {
                    userAccount.UserName = appUser.UserName;
                    userAccount.BirthDate = appUser.BirthDate;
                    userAccount.Email = appUser.Email;

                    var result = await _userManager.UpdateAsync(userAccount);
                }

                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);
            }
            return RedirectToAction("Index");
        }

        //User Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //User Delete
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _userManager.FindByIdAsync(id);
            if (deleted != null)
            {
                return View(deleted);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppUser appUser)
        {
            _userManager.DeleteAsync(appUser);
            TempData["Status"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
