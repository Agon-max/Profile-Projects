using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models
{
    public class FoodType
    {
        public FoodType()
        {
            Foods = new List<Food>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<Food> Foods { get; set; }
    }
}