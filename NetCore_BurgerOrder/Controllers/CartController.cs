using Microsoft.AspNetCore.Mvc;
using NetCore_BurgerOrder.Models.Context;
using NetCore_BurgerOrder.Models.ViewModels;
using NetCore_BurgerOrder.Sessions;

namespace NetCore_BurgerOrder.Controllers
{
    public class CartController : Controller
    {
        private readonly ProjectContext _context;

        public CartController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.Find(id);
            
            if (product != null)
            {
                //Session İşlemleri
                CartSession cartSession = new CartSession();
                if (SessionHelper.GetProductFromJson<CartSession>(HttpContext.Session, "sepet")==null)
                {
                    cartSession = new CartSession();
                }
                else
                {
                    cartSession = SessionHelper.GetProductFromJson<CartSession>(HttpContext.Session, "sepet");
                }

                CartVM cartVM = new CartVM
                {
                    Product = product
                };

                cartSession.AddToCart(product.ID, cartVM);

                SessionHelper.SetProductFromJson(HttpContext.Session, "sepet", cartSession);

                TempData["SuccessStatus"] = $"{product.ProductName} sepete eklendi!";
            }
            return RedirectToAction("Index");
        }

        //MyCart
        public IActionResult Index()
        {
            //Session'a nasıl ulaşırız? 
            var cart = SessionHelper.GetProductFromJson<CartSession>(HttpContext.Session, "sepet");
            if (cart != null)
            {
                return View(cart);
            }
            return RedirectToAction("Index");
        }
    }
}
