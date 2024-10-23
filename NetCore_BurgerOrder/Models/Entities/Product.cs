namespace NetCore_BurgerOrder.Models.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        //Relational Properties
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
