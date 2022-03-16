using System.ComponentModel.DataAnnotations;

namespace Car.Demo.Models;

public class UserToUpdate
{
    [Required(ErrorMessage = "Name field must be specified")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "PhoneNumber field must be specified")]
    public string? PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Email field must be specified")]
    public string? Email { get; set; }
}