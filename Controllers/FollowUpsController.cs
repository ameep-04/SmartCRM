using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCRM.Data;
using SmartCRM.Models;

namespace SmartCRM.Controllers {
    public class FollowUpsController : Controller {
        private readonly AppDbContext _db;
        public FollowUpsController(AppDbContext db) { _db = db; }

        public IActionResult Index() {
            var today = DateTime.Today;
            ViewBag.Today = _db.FollowUps.Include(f => f.Lead).ThenInclude(l => l.Customer)
                .Where(f => f.FollowUpDate.Date == today && f.Status == "Pending").ToList();
            ViewBag.Missed = _db.FollowUps.Include(f => f.Lead).ThenInclude(l => l.Customer)
                .Where(f => f.FollowUpDate.Date < today && f.Status == "Pending").ToList();
            return View(_db.FollowUps.Include(f => f.Lead).ThenInclude(l => l.Customer).ToList());
        }

        public IActionResult Create() {
            ViewBag.Leads = _db.Leads.Include(l => l.Customer).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(FollowUp f) {
            _db.FollowUps.Add(f);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id) {
            var f = _db.FollowUps.Find(id);
            if (f != null) { f.Status = "Completed"; _db.SaveChanges(); }
            return RedirectToAction("Index");
        }
    }
}