using System;
using System.Collections.Generic;

namespace OnlineShop.Shops
{
    public abstract class Component
    {
        public string Name { get; }

        public Component(string name)
        {
            Name = name;
        }
    }
   
    public class ComponentStorage
    {
        public string Name { get; }

        //public List<Component> GenerateComponents(int count)
        //{
        //    List < Component > col = new List<Component>();
        //    for ()
        //    {

        //    }
        //}
    }
}
