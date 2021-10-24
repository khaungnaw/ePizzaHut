using ePizzaHut.Entity;
using ePizzaHut.Services.Interfaces;
using ePizzaHut.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePizzaHut.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentationService _authentationService;
        public AccountController(IAuthentationService authentationService)
        {
            _authentationService = authentationService;
        }

        // GET: /<controller>/
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                var created = _authentationService.CreateUser(user, model.Password);
                if (created)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
