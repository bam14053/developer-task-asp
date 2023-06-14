using System;
namespace Example.Models
{
    public class Furniture : Product
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public Furniture() : base()
        {
        }

        public Furniture(string sku, string name, int price) : base(sku, name, price)
        {
        }
              
        public override string PrintProductInfo()
        {
            return "Dimension: " + this.Height+ "x"+ this.Width+ "x"+ this.Length;
        }
    }
}
