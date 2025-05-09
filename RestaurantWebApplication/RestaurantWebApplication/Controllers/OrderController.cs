using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;
using RestaurantWebApplication.Models.ViewModels;

namespace RestaurantWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public OrderController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var orders = _dbContext.FoodOrders.Include(r => r.FoodOrderDetails)
                .ThenInclude(r => r.Food)
                .Include(r => r.FoodOrderStatus)
                .Where(r => r.DeletedAt == null)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            ViewBag.FoodOrderStatuses = _dbContext.FoodOrderStatuses
                .Where(r => r.DeletedAt == null).ToList();

            return View(orders);
        }

        [HttpPost]
        public IActionResult UpdateFoodOrderStatus(int? foodOrderId = 0, int? foodOrderStatusId = 0)
        {
            if (foodOrderId == 0 || foodOrderStatusId == 0)
                return Json(new
                {
                    status = false,
                    message = "Diçka shkoi keq, ju lutem të provoni përsëri."
                });

            var currentFoodOrder = _dbContext.FoodOrders
                .FirstOrDefault(r => r.Id == foodOrderId && r.DeletedAt == null);

            if (currentFoodOrder == null)
                return Json(new
                {
                    status = false,
                    message = "Porosia nuk u gjend, ju lutem të provoni përsëri."
                });

            currentFoodOrder.FoodOrderStatusId = foodOrderStatusId ?? 1;
            currentFoodOrder.UpdatedAt = DateTime.Now;

            _dbContext.FoodOrders.Update(currentFoodOrder);
            _dbContext.SaveChanges();

            return Json(new
            {
                status = true,
                message = "Statusi i porosisë është ndryshuar me sukses."
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
