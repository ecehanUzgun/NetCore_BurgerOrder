using Microsoft.AspNetCore.Mvc;
using NetCore_BurgerOrder.Models.Context;
using NetCore_BurgerOrder.Models.Entities;
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

        public IActionResult UpdateCartItem(int id, int quantity) 
        {
            var cartSession = SessionHelper.GetProductFromJson<CartSession>(HttpContext.Session, "sepet");

            if (cartSession != null) 
            { 
                cartSession.UpdateCart(id,quantity);

                SessionHelper.SetProductFromJson(HttpContext.Session, "sepet", cartSession);
                TempData["SuccessStatus"] = "Sepet güncellendi!";
            }
            else
            {
                TempData["ErrorStatus"] = "Sepetiniz boş!";
            }

            return RedirectToAction("Index");
        }     

        public IActionResult RemoveCartItem(int id) 
        {
            var cartSession = SessionHelper.GetProductFromJson<CartSession>(HttpContext.Session, "sepet");
            if (cartSession != null) 
            {
                cartSession.DeleteCart(id);
                SessionHelper.SetProductFromJson(HttpContext.Session, "sepet", cartSession);
                TempData["SuccessStatus"] = "Ürün sepetten kaldırıldı!";
            }
            else
            {
                TempData["ErrorStatus"] = "Sepetiniz boş!";
            }

            return RedirectToAction("Index");
        }

        //Sipariş Formu - Sepet Boş => Sipariş oluşturulamaz!
        public IActionResult CompleteOrder()
        {
            var order = new Order();

            order.AppUser = new AppUser
            {
                UserName = "ecehan"
            };

            return View(order);
        }

        [HttpPost]
        public IActionResult CompleteOrder(Order order)
        {
            order.AppUserId = 1; //TODO: Dinamik hale getirilecek
            order.ShippedDate = DateTime.Now;

            var cartSession = SessionHelper.GetProductFromJson<CartSession>(HttpContext.Session, "sepet");

            if (cartSession != null) 
            {
                //OrderDetail
                order.OrderDetails = new List<OrderDetail>();

                foreach (var item in cartSession.MyCart)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProductId = item.Value.Product.ID,
                        Quantity = item.Value.Quantity,
                        UnitPrice = item.Value.Product.UnitPrice
                    };
                    order.OrderDetails.Add(orderDetail);
                }

                //DB
                _context.Orders.Add(order);
                _context.SaveChanges();

                //Sipariş tamamlandığında sepet boşaltılır.
                HttpContext.Session.Remove("sepet");
                TempData["SuccessStatus"] = "Sipariş oluşturuldu!";
            }
            else
            {
                TempData["ErrorStatus"] = "Sepette ürün yok!";
            }

            return RedirectToAction("Index","Home");
        }
    }
}
