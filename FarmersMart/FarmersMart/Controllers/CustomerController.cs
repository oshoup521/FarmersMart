using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmersMart.DAL;
using FarmersMart.Models;

namespace FarmersMart.Controllers
{
    public class CustomerController : Controller
    {
        private string _connectionString = "Server=localhost;Port=3306;Database=farmersmart;Uid=root;Pwd=welcome@123;";
        CustomerDAL _customerDAL;
        Customer customer;
        public CustomerController()
        {
            _customerDAL = new CustomerDAL(_connectionString);
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            List<Customer> customers = _customerDAL.GetAllCustomers();
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _customerDAL.InsertCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = _customerDAL.GetCustomerById(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _customerDAL.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _customerDAL.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
