using System;
namespace Example.Models
{
    public class Dvd : Product
    {
        public int Size { get; set; }

        public Dvd(string sku, string name, int price) : base(sku, name, price)
        {
        }

        public Dvd() : base()
        {
        }

        public override string PrintProductInfo()
        {
            return "Size: "+ this.Size+ " MB";
        }
    }
}
