using System;
using System.Collections.Generic;
using System.IO;
using Example.Models;
using Newtonsoft.Json;

namespace Example.Controller
{
    public class ProductsController
    {
        private static readonly JsonSerializerSettings _options = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, TypeNameHandling  = TypeNameHandling.Auto };
        private readonly string _filename = "products.json";

        public List<Product> Products { get; set; }

        public ProductsController()
        {
            try
            {
                StreamReader reader = new StreamReader(_filename);
                if (reader.EndOfStream)
                    throw new FileNotFoundException();
                var json = reader.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<Product>>(json, _options);
            }
            catch (FileNotFoundException)
            {
                //If there are no products 
                Products = new List<Product>
                {
                    new Book("BODf23", "Bookname", 23) { Weight = 12 },
                    new Book("BO2824", "Book two", 323) { Weight = 32 },
                    new Book("BOG1213", "Bookname", 23) { Weight = 12 },
                    new Book("BO2382", "Book two", 323) { Weight = 32 },
                    new Furniture("FU8142", "Furniture", 2323) { Height = 23, Width = 35, Length = 20 },
                    new Furniture("FU20942", "Furniture pro", 2323) { Height = 23, Width = 35, Length = 20 },
                    new Furniture("FU23142", "Furniture prolife", 2323) { Height = 23, Width = 35, Length = 20 },
                    new Dvd("DV232321", "DVD good", 243342) { Size = 425 },
                    new Dvd("DV233221", "DVD ood", 243342) { Size = 454 },
                    new Dvd("DV222321", "DVD good", 243342) { Size = 415 },
                    new Dvd("DV235421", "DVD good", 243342) { Size = 4135 }
                };
            }
        }

        public void SaveProducts()
        {
            var jsonString = JsonConvert.SerializeObject(Products, Formatting.Indented, _options);
            File.WriteAllText(_filename, jsonString);
        }
    }
}
