using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}