using Microsoft.AspNetCore.Mvc;
using SmartCRM.Data;

namespace SmartCRM.Controllers {
    public class AccountController : Controller {
        private readonly AppDbContext _db;
        public AccountController(AppDbContext db) { _db = db; }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password) {
            var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null) {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}