using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder.Models.ViewModels
{
    public class CartVM
    {
        //Bir sepetin ...'sı olur.
        public CartVM() 
        {
            Quantity = 1;    
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal? SubTotal
        {
            get 
            {
                return Quantity * Product.UnitPrice;
            }
        }
    }
}
