using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models.ViewModels
{
    public class UserRegistrationVm
    {
        [Required, EmailAddress,
         StringLength(255, MinimumLength = 7, ErrorMessage = "Ju lutem të shkruani email adresen.")]
        public string EmailAddress { get; set; }

        [Required,
         StringLength(12, MinimumLength = 6,
             ErrorMessage = "Ju lutem të shkruani fjalëkalimin (prej 6 deri në 12 karaktere maksimalisht).")]
        public string Password { get; set; }
    }
}
