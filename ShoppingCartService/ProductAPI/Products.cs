using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI
{
    internal class Products
    {
        public Product? this[long id]
        {
            get => products.GetValueOrDefault(id);
        }

        private static Dictionary<long, Product> products { get; set; } = new Dictionary<long, Product>();

        static Products()
        {
            products.Add(122, new Product
            {
                Id = 122,
                Description = "The newest starwars walker",
                Name = "Lego Starwars AT-AT",
                Price = 22.4M
            });

            products.Add(123, new Product
            {
                Id = 123,
                Description = "The mandalorian ship",
                Name = "mando's ship",
                Price = 5500M
            });
        }

        public List<Product> GetProducts()
        {
            return products.Select(x => x.Value).ToList();
        }
    }
}
