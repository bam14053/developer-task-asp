using System;
using System.Collections.Generic;

namespace Example.Models
{
    public abstract class Product
    {
        public string Sku { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public readonly static IDictionary<string, string> classTypes = new Dictionary<string, string>
        {
            {"Furniture",typeof(Furniture).AssemblyQualifiedName},
            {"Book",typeof(Book).AssemblyQualifiedName},
            {"DVD",typeof(Dvd).AssemblyQualifiedName}
        };

        protected Product()
        { }

        protected Product(string sku, String name, int price)
        {
            this.Sku = sku;
            this.Name = name;
            this.Price = price;
        }

        public abstract String PrintProductInfo();
    }
}
