using NetCore_BurgerOrder.Models.ViewModels;

namespace NetCore_BurgerOrder.Sessions
{
    public class CartSession
    {
        //Bir Oturum ...'sı olur.
        //Bu nesne Server'da Session olarak tutulacak

        //Sepet
        public Dictionary<int, CartVM> MyCart = new Dictionary<int, CartVM>();
        //ID Product

        //Sepete Ürün Ekleme
        public void AddToCart(int productId, CartVM cart)
        {
            if (MyCart.ContainsKey(productId))
            {
                MyCart[productId].Quantity++;
                return;
            }
            MyCart.Add(productId, cart);
        }

        //Sepet güncelleme
        public void UpdateCart(int productId, int quantity)
        {
            if (MyCart.ContainsKey(productId))
            {
                MyCart[productId].Quantity = quantity;
            }
        }

        //Sepet silme
        public void DeleteCart(int productId) 
        {
            if (MyCart.ContainsKey(productId))
            {
                MyCart.Remove(productId);
            }
        }
    }
}
