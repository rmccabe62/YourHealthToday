using System.ComponentModel.DataAnnotations;
using Xunit;

namespace YourHealthToday.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email{ get; set; }

    }
}
