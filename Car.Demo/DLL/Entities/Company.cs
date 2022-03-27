namespace Car.Demo.DLL.Entities;

public class Company : IEntity
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}