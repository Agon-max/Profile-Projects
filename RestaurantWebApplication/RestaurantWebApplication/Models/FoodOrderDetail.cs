using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebApplication.Models
{
    public class FoodOrderDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("FoodOrder")]
        public int FoodOrderId { get; set; }
        public FoodOrder FoodOrder { get; set; }

        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}