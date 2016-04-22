using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    using ProductService;
    using ProductService.Models;

    class Program
    {
        static void ListAllProducts(Container container)
        {
            foreach (var p in container.Products)
            {
                Console.WriteLine("{0} | {1} | {2}", p.Name, p.Price, p.Category);
            }
        }

        static void AddProduct(Container container, Product product)
        {
            container.AddToProducts(product);
            var serviceResponses = container.SaveChanges();
            foreach (var response in serviceResponses)
            {
                Console.WriteLine("Response: {0}", response.StatusCode);
            }
        }

        static void Main(string[] args)
        {
            var container = new Container(new Uri("http://localhost:62640/"));

            //AddProduct(container, new Product
            //{
            //    Id = 999,
            //    Name = "Cell phone",
            //    Price = 9999,
            //    Category = "3C"
            //});

            ListAllProducts(container);
        }
    }
}
