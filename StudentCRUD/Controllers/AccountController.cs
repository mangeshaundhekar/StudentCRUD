using Microsoft.AspNetCore.Mvc;
using SimpleCrudDemo.Data;
using System.Linq;

namespace SimpleCrudDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                // Login success
                return RedirectToAction("Index", "Student");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }
    }
}
