using System;
using System.Collections.Generic;

namespace OnlineShop.Shops
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }

        public List<Component> Basket;
    }
}