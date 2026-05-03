using Microsoft.AspNetCore.Mvc;
using SmartCRM.Data;

namespace SmartCRM.Controllers {
    public class DashboardController : Controller {
        private readonly AppDbContext _db;
        public DashboardController(AppDbContext db) { _db = db; }

        public IActionResult Index() {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");
            var today = DateTime.Today;
            ViewBag.TotalCustomers = _db.Customers.Count();
            ViewBag.TotalLeads = _db.Leads.Count();
            ViewBag.TodayFollowUps = _db.FollowUps.Count(f => f.FollowUpDate.Date == today && f.Status == "Pending");
            ViewBag.MissedFollowUps = _db.FollowUps.Count(f => f.FollowUpDate.Date < today && f.Status == "Pending");
            ViewBag.TotalSales = _db.Sales.Sum(s => (decimal?)s.Amount) ?? 0;
            return View();
        }
    }
}