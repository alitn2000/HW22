using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoints.Models;

public class RegisterModelView
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage ="Firs tName Is required")]
    [StringLength(20, ErrorMessage = "Length error")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name Is required")]
    [StringLength(20, ErrorMessage = "Length error")]
    public string LastName { get; set; }

    [Display(Name = "User Name")]
    [Required(ErrorMessage = "User name Is required")]
    [StringLength(20, ErrorMessage = "Length error")]
    public string UserName { get; set; }

    [Display(Name = "Email ")]
    [Required(ErrorMessage = "Email Is required")]
    [EmailAddress(ErrorMessage ="Email format error")]
    public string Email { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password Is required")]
    [StringLength(4, ErrorMessage = "password Length error(4)")]
    public string Password { get; set; }
}
