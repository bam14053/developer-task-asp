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
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<string> DeleteCheckboxes { get; set; }
        public List<Product> ProductsList { get; set; }
        public ProductsController Controller;

        public void LoadController()
        {
            Controller = new ProductsController();
            ProductsList = Controller.Products;
        }

        public IActionResult OnPost()
        {
            LoadController();
            DeleteCheckboxes.ForEach(i => ProductsList.Remove(ProductsList.Find(x => x.Sku == i)));
            Controller.SaveProducts();
            return Page();
        }

        public void OnGet()
        {
            LoadController();
        }
    }
}
