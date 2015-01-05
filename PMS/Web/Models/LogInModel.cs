using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Login is required")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}