using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProductService>> GetAll()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductService> Get(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult Create(ProductService product)
        {
            product.Id = Products.Count() + 1;
            Products.Add(product);

            return CreatedAtAction(
                "Get",
                new { id = product.Id},
                product
                );
        }

        private static List<ProductService> Products = new List<ProductService>
        {
            new ProductService
            {
                Id = 1,
                Name = "Nombre de prueba 1",
                Price = 1200,
                Description = "Descripcion de prueba para el ID 1"
            },
            new ProductService
            {
                Id = 2,
                Name = "Nombre de prueba 2",
                Price = 1200,
                Description = "Descripcion de prueba para el ID 2"
            },
            new ProductService
            {
                Id = 3,
                Name = "Nombre de prueba 3",
                Price = 1200,
                Description = "Descripcion de prueba para el ID 3"
            },
        };
    }
}
