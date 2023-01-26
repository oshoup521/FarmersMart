using FarmersMart.DAL;
using FarmersMart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FarmersMart.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = "Server=localhost;Port=3306;Database=farmersmart;Uid=root;Pwd=welcome@123;";
        private readonly ILogger<HomeController> _logger;
        ProductDAL _productDAL;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _productDAL = new ProductDAL(_connectionString);
        }

        public IActionResult Index()
        {
            List<Product> products = _productDAL.GetAllProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}