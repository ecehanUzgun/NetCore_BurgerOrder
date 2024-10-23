namespace NetCore_BurgerOrder.Models.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public List<Product> Products { get; set; }
    }
}
