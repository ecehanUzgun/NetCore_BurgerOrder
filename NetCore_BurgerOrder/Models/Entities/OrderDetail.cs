namespace NetCore_BurgerOrder.Models.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        //Relational Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
