using Microsoft.AspNetCore.Mvc;
using SmartCRM.Data;
using SmartCRM.Models;

namespace SmartCRM.Controllers {
    public class CustomersController : Controller {
        private readonly AppDbContext _db;
        public CustomersController(AppDbContext db) { _db = db; }

        public IActionResult Index() => View(_db.Customers.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Customer c) {
            _db.Customers.Add(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) => View(_db.Customers.Find(id));

        [HttpPost]
        public IActionResult Edit(Customer c) {
            _db.Customers.Update(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var c = _db.Customers.Find(id);
            if (c != null) { _db.Customers.Remove(c); _db.SaveChanges(); }
            return RedirectToAction("Index");
        }
    }
}