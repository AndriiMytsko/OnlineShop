using System;
using System.Collections.Generic;

namespace OnlineShop.Shops.StructureShop.Categories
{
    public class Category : Component
    {
        private readonly List<Component> _components = new List<Component>();
        public IEnumerable<Component> Components => _components;
        public Categories Type { get; }
        public Category(string name, Categories type)
        : base(name)
        {
            Type = type;
        }

        public void Add(Component component)
        {
            _components.Add(component);
        }

        public void Remove(Component component)
        {
            _components.Remove(component);
        }
    }
}
