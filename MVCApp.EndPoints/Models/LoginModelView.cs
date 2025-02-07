using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoints.Models
{
    public class LoginModelView
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name Is required")]
        [StringLength(20, ErrorMessage = "Length error")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Is required")]
        [StringLength(4, ErrorMessage = "password Length error(4)")]
        public string Password { get; set; }
    }
}
