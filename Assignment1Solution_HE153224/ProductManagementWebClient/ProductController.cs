using Microsoft.AspNetCore.Mvc;

namespace ProductManagementWebClient
{
    using System.Net.Http.Headers;
    using System.Text.Json;
    using BusinessObjects;

    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public ProductController()
        {
            this.client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            this.client.DefaultRequestHeaders.Accept.Add(contentType);
            this.productApiUrl = "http://localhost:53633/api/products";
        }
        public async Task<IActionResult> Index()
        {
            var    responseMessage = await this.client.GetAsync(this.productApiUrl);
            var strData         = await responseMessage.Content.ReadAsStringAsync();
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return this.View(listProducts);
        }

        //Get: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return this.NoContent();
        }

        //Get: ProductController/Create
        public ActionResult Create()
        {
            return this.NoContent();
        }
        
        //Post: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            return this.NoContent();
        }
        
        //Get: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return this.NoContent();
        }
        
        //Post: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return this.NoContent();
        }
        
        //Get: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return this.NoContent();
        }
        
        //Post: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return this.NoContent();
        }
    }
}
