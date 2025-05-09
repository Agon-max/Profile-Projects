using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models
{
    public class FoodOrderStatus
    {
        public FoodOrderStatus()
        {
            FoodOrders = new List<FoodOrder>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<FoodOrder> FoodOrders { get; set; }
    }
}