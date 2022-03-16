using System.ComponentModel.DataAnnotations;

namespace Car.Demo.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Email field is required")]
    [RegularExpression("^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Password field is required")]
    public string? Password { get; set; }
}