using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebApplication.Models
{
    public class FoodOrder
    {
        public FoodOrder()
        {
            FoodOrderDetails = new List<FoodOrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("FoodOrderStatus")]
        public int FoodOrderStatusId { get; set; }
        public FoodOrderStatus FoodOrderStatus { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<FoodOrderDetail> FoodOrderDetails { get; set; }
    }
}