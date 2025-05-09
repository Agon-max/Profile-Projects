using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebApplication.Models
{
    public class Food
    {
        public Food()
        {
            FoodOrderDetails = new List<FoodOrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("FoodType")]
        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }

        public List<FoodOrderDetail> FoodOrderDetails { get; set; }
    }
}
