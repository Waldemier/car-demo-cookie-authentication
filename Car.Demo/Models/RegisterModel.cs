using System.ComponentModel.DataAnnotations;

namespace Car.Demo.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Name field is required")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Email field is required")]
    [RegularExpression("^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Password field is required")]
    [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Z\\d@$!%*?&]{5,}$")]
    public string? Password { get; set; }
    
    [Required(ErrorMessage = "Please repeat your password and try again")]
    [Compare(nameof(Password))]
    public string? PasswordConfirm { get; set; }
    
    public string? PhoneNumber { get; set; }
}