namespace Car.Demo.DLL.Entities;

public class Car: IEntity
{
    public Guid Id { get; set; }

    public string? Brand { get; set; }
    
    public string? Model { get; set; }
    
    public string? Country { get; set; }
    
    public double Price { get; set; }
    
    public Guid PublisherId { get; set; }
    
    public User? Publisher { get; set; }
}