using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCRM.Data;
using SmartCRM.Models;

namespace SmartCRM.Controllers {
    public class LeadsController : Controller {
        private readonly AppDbContext _db;
        public LeadsController(AppDbContext db) { _db = db; }

        public IActionResult Index() =>
            View(_db.Leads.Include(l => l.Customer).ToList());

        public IActionResult Create() {
            ViewBag.Customers = _db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lead lead) {
            lead.CreatedDate = DateTime.Now;
            _db.Leads.Add(lead);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status) {
            var lead = _db.Leads.Find(id);
            if (lead != null) {
                lead.Status = status;
                if (status == "Converted") {
                    _db.Sales.Add(new Sale {
                        CustomerId = lead.CustomerId,
                        SaleDate = DateTime.Now,
                        Amount = 0
                    });
                }
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}