using System;
namespace Example.Models
{
    public class Book : Product
    {
        public int Weight { get; set; }
        public Book(string sku, string name, int price) : base(sku, name, price)
        {
        }

        public Book() : base()
        {
        }

        public override string PrintProductInfo()
        {
            return "Weight: "+ this.Weight+ "KG";
        }
    }
}
