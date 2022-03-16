using Car.Demo.DLL.Entities;
using Car.Demo.DLL.Repositories;
using Car.Demo.Security;

namespace Car.Demo.Helpers;

public class HelperService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRepository<User> _userRepository;
    private readonly ISecurityService _securityService;

    public HelperService(IHttpContextAccessor httpContextAccessor, IRepository<User> userRepository,
        ISecurityService securityService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _securityService = securityService;
    }

    public bool ValidateLastChangedTime(DateTime dateTime)
    {
        var userId = _securityService.GetCurrentUserId();
        
        if (string.IsNullOrEmpty(userId)) return false;
        
        var user = _userRepository.Sql().FirstOrDefault(x => x.Id.Equals(Guid.Parse(userId)));

        return user!.LastChanged.Equals(dateTime);
    }
}