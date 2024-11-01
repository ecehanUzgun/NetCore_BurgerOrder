using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder.Models.Data
{
    public class ProductData
    {
        public static List<Product> Products = new List<Product>
        {
            new Product{ID=1, ProductName="Cheeseburger", UnitPrice= 250, CategoryId=1},
            new Product{ID=2, ProductName="BBQ Burger", UnitPrice= 300, CategoryId=1},
            new Product{ID=3, ProductName="Mushroom Burger", UnitPrice= 350, CategoryId=1},
            new Product{ID=4, ProductName="Vegan Burger", UnitPrice= 300, CategoryId=1},
            new Product{ID=5, ProductName="French fries", UnitPrice= 70, CategoryId=2},
            new Product{ID=6, ProductName="Onion rings", UnitPrice= 70, CategoryId=2},
            new Product{ID=7, ProductName="Coke", UnitPrice= 80, CategoryId=3},
            new Product{ID=8, ProductName="Soda", UnitPrice= 80, CategoryId=3},
            new Product{ID=9, ProductName="Juice", UnitPrice= 80, CategoryId=3},
            new Product{ID=10, ProductName="Water", UnitPrice= 20, CategoryId=3},
            new Product{ID=11, ProductName="Ketchup", UnitPrice= 10, CategoryId=4},
            new Product{ID=12, ProductName="Mayonnaise", UnitPrice= 10, CategoryId=4},
            new Product{ID=13, ProductName="BBQ", UnitPrice= 10, CategoryId=4},
            new Product{ID=14, ProductName="Hot sauce", UnitPrice= 10, CategoryId=4},
            new Product{ID=15, ProductName="Ranch sauce", UnitPrice= 10, CategoryId=4}
        };
    }
}
