namespace Car.Demo.DLL.Entities;

public class Subscription : IEntity
{
    public Guid UserId { get; set; }
    
    public Guid CompanyId { get; set; }
    
    public User? User { get; set; }
    
    public Company? Company { get; set; }
    
    public bool IsActive { get; set; }
}