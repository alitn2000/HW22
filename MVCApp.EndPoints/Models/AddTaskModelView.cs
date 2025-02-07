using MVCApp.EndPoints.Validations;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoints.Models;

public class AddTaskModelView
{
    [Display(Name = "Title")]
    [Required(ErrorMessage = "Title Is required")]
    [StringLength(30, ErrorMessage = "Length error")]
    public string Title { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Description Is required")]
    [StringLength(100, ErrorMessage = "Length error")]
    public string Description { get; set; }

    [Display(Name = "DeadTime")]
    [Required(ErrorMessage = "DeadTime Is required")]
    [DateValidation(ErrorMessage = "Date must be after today")]
    public DateTime DeadTime { get; set; }

}
