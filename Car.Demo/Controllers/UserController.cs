using Car.Demo.DLL.Entities;
using Car.Demo.DLL.Repositories;
using Car.Demo.Models;
using Car.Demo.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car.Demo.Controllers;

[ApiController]
[Authorize]
[Route("api/user")]
public class UserController: ControllerBase
{
    private readonly IRepository<User> _userRepository;
    private readonly ISecurityService _securityService;

    public UserController(IRepository<User> userRepository, ISecurityService securityService)
    {
        _userRepository = userRepository;
        _securityService = securityService;
    }

    [HttpPut("change-profile")]
    public async Task<ActionResult<User>> ChangeProfile(UserToUpdate userToUpdate)
    {
        var userId = _securityService.GetCurrentUserId();
        var user = await _userRepository.GetByIdAsync(Guid.Parse(userId!));
        
        user.Email = userToUpdate.Email;
        user.PhoneNumber = userToUpdate.PhoneNumber;
        user.Name = userToUpdate.Name;
        user.LastChanged = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();

        return Ok("User has been updated.");
    }
}