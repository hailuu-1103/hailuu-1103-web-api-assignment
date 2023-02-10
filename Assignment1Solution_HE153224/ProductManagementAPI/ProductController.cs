using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Repositories;

namespace ProductManagementAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        //Get: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => this.repository.GetProducts();

        //Post: ProductController/Products
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            this.repository.SaveProduct(product);
            return this.NoContent();
        }

        //Get: ProductsController/Delete/5
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = this.repository.GetProductById(id);
            if(p == null) return this.NotFound();
            this.repository.DeleteProduct(p);
            return this.NoContent() ;
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, Product product)
        {
           var pTmp = this.repository.GetProductById(id);
            if(pTmp == null) return this.NotFound();
            this.repository.UpdateProduct(product);
            return this.NoContent();
        }
    }
}
