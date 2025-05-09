using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models.ViewModels
{
    public class OrderSubmissionVm
    {
        public OrderSubmissionVm()
        {
            Products = new List<int>();
        }

        [Required,
         StringLength(255, MinimumLength = 1, ErrorMessage = "Ju lutem të shkruani emrin tuaj.")]
        public string FirstName { get; set; }

        [Required,
         StringLength(255, MinimumLength = 1, ErrorMessage = "Ju lutem të shkruani mbiemrin tuaj.")]
        public string LastName { get; set; }

        [Required,
         StringLength(12, MinimumLength = 9, ErrorMessage = "Ju lutem të shkruani numrin tuaj të telefonit.")]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress,
         StringLength(255, MinimumLength = 7, ErrorMessage = "Ju lutem të shkruani email adresen tuaj.")]
        public string EmailAddress { get; set; }

        [Required,
         StringLength(255, MinimumLength = 10,
             ErrorMessage = "Ju lutem të shkruani adresen tuaj (deri në 10 karaktere minimalisht).")]
        public string Address { get; set; }

        [Required,
         Range(0.01, double.MaxValue, ErrorMessage = "Ju lutem të specifikoni produktin/et.")]
        public decimal TotalPrice { get; set; }

        [Required] public List<int> Products { get; set; }
    }
}
