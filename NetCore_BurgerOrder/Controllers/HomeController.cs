using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_BurgerOrder.Models;
using NetCore_BurgerOrder.Models.Context;
using NetCore_BurgerOrder.Models.Entities;
using NetCore_BurgerOrder.Models.ViewModels;
using System.Diagnostics;

namespace NetCore_BurgerOrder.Controllers
{
    public class HomeController : Controller
    {
        //Dependency Injection
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, ProjectContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM user)
        {
            if (ModelState.IsValid)
            {
                //Kullanıcı oluştur
                AppUser appUser = new AppUser()
                {
                    UserName = user.Username,
                    Email = user.Email
                };
                //Veritabanına kaydet
                var result = await _userManager.CreateAsync(appUser, user.ConfirmPassword);
                if (result.Succeeded) 
                { 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }
            else
            { 
                return View(user); 
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
