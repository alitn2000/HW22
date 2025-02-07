using System.ComponentModel.DataAnnotations;

namespace MVCApp.EndPoints.Validations;

public class DateValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
        {
            if (date < DateTime.Now)
            {
                return false;
            }
        }
        return true;
    }
}
