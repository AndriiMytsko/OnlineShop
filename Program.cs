using OnlineShop.Shops;
using OnlineShop.Shops.StructureShop.Products;
using OnlineShop.Shops.StructureShop.Categories;
using OnlineShop.Shops.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var admin = new User
            {
                Name = "admin",
                Password = "admin"
            };

            var shop = new Shop(admin);

            //Category
            var gamesCategory = new Category("Game", Categories.Game);
            var booksCategory = new Category("Books", Categories.Book);
            var carsCategory = new Category("Cars", Categories.Car);

            //Product
            var ball = new Ball("ball");
            var book = new Book("book");
            var car = new Car("opel");

            //Add product
            gamesCategory.Add(ball);
            booksCategory.Add(book);
            carsCategory.Add(car);

            shop.Add(gamesCategory);
            shop.Add(booksCategory);
            shop.Add(carsCategory);

            shop.Registry("sdf", "sdf");
            shop.GetBusket();

            Start(shop);

            var components = shop.GetComponents(Categories.Ball);

            Console.Read();
        }


        static string[] singnIn = { "SignIn", "Register" };

        static string[] generalHandler = { "GetUsers", "GetBusket", "GetAllCategories" };

        private static void Start(Shop shop)
        {
            string command = string.Empty;

            while (true)
            {
                PrintMenu.item = singnIn;
                command = PrintMenu.MenuShow();
                SighIn(shop, command);

                PrintMenu.item = generalHandler;
                command = PrintMenu.MenuShow();
                GeneralHandler(shop, command);
  
            }
        }

        private static void SighIn(Shop shop, string value)
        {
            if (value == "SignIn")
            {
                Console.Write("name = ");
                var user = Console.ReadLine();

                Console.Write("password = ");
                var password = Console.ReadLine();

                var success = shop.SignIn(user, password);
                if (!success)
                {
                    Console.WriteLine(":(");
                }
                return;
            }
            else if (value == "Register")
            {
                Console.Write("name = ");
                var user = Console.ReadLine();

                Console.Write("password = ");
                var password = Console.ReadLine();

                shop.Registry(user, password);

                return;
            }
        }

        private static void GeneralHandler(Shop shop, string value)
        {
            if (value == "GetUsers")
            {
                shop.GetUsers();
            }
            else if (value == "GetBusket")
            {
                shop.GetBusket();
            }
            else if (value == "GetAllCategories")
            {
                var categories = shop.GetCategories();
                DisplayCategories(categories.ToList());
                return;
            }
            else if (value == "GetComponents")
            {
            }
            else if (value == "Exit")
            {
                Console.WriteLine("register signIn");
            }
        }

        private static void DisplayCategories(List<Categories> categories)
        {
            for (var x = 0; x < categories.Count; x++)
            {
                Console.WriteLine($"{categories[x]}");
            }
        }

        private static void DisplayComponent(Category category)
        {
            foreach (var c in category.Components)
                Console.WriteLine($"{c.Name}");
        }
    }
}