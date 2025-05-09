using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Models;

namespace RestaurantWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        // Add DbSet for Contact entity
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodOrderStatus> FoodOrderStatuses { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<FoodOrderDetail> FoodOrderDetails { get; set; }
    }
}
