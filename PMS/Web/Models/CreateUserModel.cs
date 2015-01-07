using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using BLL.DomainModel.Enums;

namespace Web.Models
{
    public class CreateUserModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First name is not correct")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last name is not correct")]
        public string LastName { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [StringLength(100, ErrorMessage = "At least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not correct")]
        public string Email { get; set; }

        [Display(Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Skype")]
        public string Skype { get; set; }

        [Display(Name = "Add Avatar")]
        public HttpPostedFileBase Avatar { get; set; }

        [Display(Name = "Role")]
        public Role Role { get; set; }

    }
}