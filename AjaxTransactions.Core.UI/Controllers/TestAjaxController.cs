using AjaxTransactions.Core.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace AjaxTransactions.Core.UI.Controllers
{
    public class TestAjaxController : Controller
    {
        Context _context = new Context();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProduct()
        {
            return Json(JsonConvert.SerializeObject(_context.Products.ToList()));
        }
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            var productJson = JsonConvert.SerializeObject(product);
            return Json(productJson);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product products)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == products.Id);
            product.Name = products.Name;
            _context.SaveChanges();
            return Json(JsonConvert.SerializeObject(product));
        }
        [HttpPost]
        public IActionResult AddProduct(Product products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
            return Json(JsonConvert.SerializeObject(products));
        }
    }
}
