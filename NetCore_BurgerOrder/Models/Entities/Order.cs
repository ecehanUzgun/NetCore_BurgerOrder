namespace NetCore_BurgerOrder.Models.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; } //Teslim edilmesi istenen tarih
        public DateTime ShippedDate { get; set;} //Yola çıkma tarihi
        public int AppUserId { get; set; }
        //Relational Properties
        public AppUser AppUser { get; set;}
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
