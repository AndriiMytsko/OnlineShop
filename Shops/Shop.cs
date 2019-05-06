using OnlineShop.Shops.StructureShop.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Shops
{
    public class Shop
    {
        private Dictionary<Categories, Category> _categories = new Dictionary<Categories, Category>();

        private List<User> _users = new List<User>();

        private User _currentSignedUser;

        public Shop(User admin)
        {
            var user = new User
            {
                Name = admin.Name,
                Password = admin.Password,
                AccessLevel = AccessLevel.Admin
            };

            _users.Add(user);
        }

        public void AddToBacket(Component component)
        {
            if (_currentSignedUser == null)
            {
                throw new Exception("please sign in");
            }

            _currentSignedUser.Basket = _currentSignedUser.Basket ?? new List<Component>();
            _currentSignedUser.Basket.Add(component);
        }
        
        public void Add(Component component, Categories category)
        {
            if (!HasAccess())
            {
                return;
            }

            if (!_categories.ContainsKey(category))
            {
                throw new Exception($"category {category} not exists");
            }

            _categories[category].Add(component);
        }

        public void Add(Category category)
        {
            if (!HasAccess())
            {
                return;
            }

            if (_categories.ContainsKey(category.Type))
            {
                throw new Exception($"category arleady {category} exists");
            }

            _categories.Add(category.Type, category);
        }

        public void Remove(Category category)
        {
            if (!HasAccess())
            {
                return;
            }

            if (!_categories.ContainsKey(category.Type))
            {
                throw new Exception($"category {category} not exists");
            }

            _categories.Remove(category.Type);
        }

        public void RemoveFromBucket(Component component)
        {
            if (_currentSignedUser == null)
            {
                throw new Exception("please sign in");
            }

            _currentSignedUser.Basket.Remove(component);
        }

        public void Remove(Component component, Categories category)
        {
            if (HasAccess())
            {
                return;
            }

            if (!_categories.TryGetValue(category, out var components))
            {
                throw new Exception($"category {category} not exists");
            }

            components.Remove(component);
        }

        public IEnumerable<User> GetUsers()
        {
            if (!HasAccess())
            {
                return Enumerable.Empty<User>();
            }

            return _users;
        }

        public IEnumerable<Component> GetBusket()
        {
            return _currentSignedUser?.Basket;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categories.Values;
        }

        public IEnumerable<Categories> GetCategories()
        {
            return _categories.Keys;
        }

        public IEnumerable<Component> GetComponents(Categories type)
        {
            if (_categories.TryGetValue(type, out var category))
            {
                return category.Components;
            }

            return Enumerable.Empty<Component>();
        }

        public bool SignIn(string name, string password)
        {
            _currentSignedUser = _users.FirstOrDefault(x => x.Name == name && x.Password == password);
            return _currentSignedUser != null;
        }

        public void Registry(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("user name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("user password cannot be null or empty");
            }

            if (_users.FirstOrDefault(x => x.Name == name) != null)
            {
                throw new Exception($"user with {name} already exists");
            }

            var user = new User
            {
                Name = name,
                Password = password
            };
            _currentSignedUser = user;
            _users.Add(user);
        }

        private bool HasAccess()
        {
            return _currentSignedUser?.AccessLevel == AccessLevel.Admin;
        }
    }
}