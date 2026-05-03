using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCRM.Data;
using SmartCRM.Models;

namespace SmartCRM.Controllers {
    public class SalesController : Controller {
        private readonly AppDbContext _db;
        public SalesController(AppDbContext db) { _db = db; }

        public IActionResult Index() {
            var today = DateTime.Today;
            ViewBag.MonthlyTotal = _db.Sales
                .Where(s => s.SaleDate.Month == today.Month && s.SaleDate.Year == today.Year)
                .Sum(s => (decimal?)s.Amount) ?? 0;
            return View(_db.Sales.Include(s => s.Customer).ToList());
        }

        public IActionResult Edit(int id) => View(_db.Sales.Find(id));

        [HttpPost]
        public IActionResult Edit(Sale s) {
            _db.Sales.Update(s);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}