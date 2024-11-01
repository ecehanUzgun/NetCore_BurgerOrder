using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder.Models.Data
{
    public class CategoryData
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category{ID=1, CategoryName="Burger", Description="Classic Cheeseburger, BBQ Burger, Mushroom Burger, Vegan Burger"},
            new Category{ID=2, CategoryName="Side Item", Description="French fries, onion rings, etc."},
            new Category{ID=3, CategoryName="Beverage", Description="Coke, soda, juice, water, etc."},
            new Category{ID=4, CategoryName="Sauce", Description="Ketchup, mayonnaise, bbq, etc."}
        };
    }
}
