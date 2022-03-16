using System.ComponentModel.DataAnnotations;

namespace Car.Demo.Models;

public class CarToUpdate
{
    [Required(ErrorMessage = "CarId must be specified")]
    public Guid CarId { get; set; }
    
    [Required(ErrorMessage = "Brand must be specified")]
    public string? Brand { get; set; }
    
    [Required(ErrorMessage = "Model must be specified")]
    public string? Model { get; set; }
    
    [Required(ErrorMessage = "Price must be specified")]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Country must be specified")]
    public string? Country { get; set; }
}