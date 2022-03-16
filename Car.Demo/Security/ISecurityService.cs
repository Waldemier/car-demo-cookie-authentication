using Car.Demo.DLL.Entities;

namespace Car.Demo.Security;

public interface ISecurityService
{
    string? GetCurrentUserId();
    
    Task Authenticate(User user);
    
    Task SignOut();
}