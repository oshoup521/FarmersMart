using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmersMart.DAL;
using FarmersMart.Models;

namespace FarmersMart.Controllers
{
    public class ProductController : Controller
    {
        private string _connectionString = "Server=localhost;Port=3306;Database=farmersmart;Uid=root;Pwd=welcome@123;";
        ProductDAL _productDAL;
        public ProductController()
        {
            _productDAL = new ProductDAL(_connectionString);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            List<Product> products = _productDAL.GetAllProducts();
            return View(products);
            
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product product = _productDAL.GetProductById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormCollection collection)
        {  
                _productDAL.InsertProduct(product);
                return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productDAL.GetProductById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, IFormCollection collection)
        {  
                _productDAL.UpdateProduct(product);
                return RedirectToAction("Index");      
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _productDAL.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
