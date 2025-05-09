using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;
using RestaurantWebApplication.Models.ViewModels;

namespace RestaurantWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var foods = _dbContext.Foods.Include(r => r.FoodType).ToList();

            return View(foods);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact(bool? isSent)
        {
            ViewBag.IsSent = isSent == true;

            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact data)
        {
            if (data == null)
                return RedirectToAction("Contact", "Home");

            data.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _dbContext.Contacts.Add(data);
                _dbContext.SaveChanges();

                return RedirectToAction("Contact", "Home", new { isSent = true });
            }

            return View("Contact");
        }

        [HttpPost]
        public IActionResult OrderSubmission(OrderSubmissionVm data)
        {
            if (data == null)
                return Json(new
                {
                    status = false,
                    message = "Të dhënat e kërkuara nuk janë dërguar, ju lutem të provoni përsëri me porositë."
                });

            if (ModelState.IsValid)
            {
                var newFoodOrder = new FoodOrder
                {
                    FullName = string.Concat(data.FirstName, " ", data.LastName),
                    PhoneNumber = data.PhoneNumber,
                    EmailAddress = data.EmailAddress,
                    Address = data.Address,
                    TotalPrice = data.TotalPrice,
                    FoodOrderStatusId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null,
                    DeletedAt = null
                };

                _dbContext.FoodOrders.Add(newFoodOrder);
                _dbContext.SaveChanges();

                foreach (var dataProduct in data.Products)
                {
                    var allOrderedProducts = _dbContext.Foods
                        .Where(r => r.Id == dataProduct)
                        .ToList();

                    foreach (var orderedProduct in allOrderedProducts)
                    {
                        var newFoodOrderDetail = new FoodOrderDetail
                        {
                            FoodOrderId = newFoodOrder.Id,
                            FoodId = orderedProduct.Id,
                            Price = orderedProduct.Price,
                            CreatedAt = DateTime.Now,
                            DeletedAt = null
                        };

                        _dbContext.FoodOrderDetails.Add(newFoodOrderDetail);
                        _dbContext.SaveChanges();
                    }
                }

                return Json(new
                {
                    status = true,
                    message =
                        "Porosia u realizua me sukses, së shpejti do pranoni një telefonatë për konfirmimin e porosisë."
                });
            }

            return Json(new
            {
                status = false,
                message = "Porosia dështoj, ju lutem të provoni përsëri."
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
