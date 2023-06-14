using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Controller;
using Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Example.Pages
{
    public class AddModel : PageModel
    {
        public ProductsController Controller;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Controller = new ProductsController();
            if (Controller.Products.Contains(Controller.Products.Find(x => x.Sku == Request.Form["sku"])))
            {
                return Page();
            }
            else
            {
                var type = Type.GetType(Product.classTypes[Request.Form["productType"]]);
                //object[] parameters = new object[3];
                //parameters[0] = Request.Form["sku"];
                //parameters[1] = Request.Form["name"];
                //parameters[2] = Convert.ToDecimal(Request.Form["price"]);
                //System.Diagnostics.Debug.WriteLine(parameters);
                var product = (Product)Activator.CreateInstance(type);

                foreach (var property in product.GetType().GetProperties())
                {
                    if (Int32.TryParse(Request.Form[property.Name], out int result))
                        property.SetValue(product, result);
                    else
                        property.SetValue(product, Request.Form[property.Name].ToString());
                }
                Controller.Products.Add(product);
                Controller.SaveProducts();
                return Redirect("/Index");
            }
        }
    }
}
