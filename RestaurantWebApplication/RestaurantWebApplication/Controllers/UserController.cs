using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;
using RestaurantWebApplication.Models.ViewModels;

namespace RestaurantWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public UserController(ILogger<HomeController> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            ViewBag.IsUserCreated = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationVm model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.IsUserCreated = false;
                return View("Create");
            }

            var user = new IdentityUser
            {
                UserName = model.EmailAddress,
                Email = model.EmailAddress,
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                LockoutEnabled = false
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                ViewBag.IsUserCreated = true;
                return View("Create");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            ViewBag.IsUserCreated = false;
            return View("Create");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
