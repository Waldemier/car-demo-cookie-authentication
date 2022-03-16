using Car.Demo.Common.Enums;

namespace Car.Demo.DLL.Entities;

public class User: IEntity
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }
    
    public string? HashPassword { get; set; }
    
    public RoleTypes Role { get; set; }

    public DateTime LastChanged { get; set; }
    
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}