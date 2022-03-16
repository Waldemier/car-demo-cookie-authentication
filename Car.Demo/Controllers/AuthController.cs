using Car.Demo.DLL.Entities;
using Car.Demo.DLL.Repositories;
using Car.Demo.Models;
using Car.Demo.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car.Demo.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly IRepository<User> _userRepository;
    private readonly ISecurityService _securityService;

    public AuthController(IRepository<User> userRepository, ISecurityService securityService)
    {
        _userRepository = userRepository;
        _securityService = securityService;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var user = await _userRepository.Sql()
            .Where(x => x.Email!.Equals(loginModel.Email))
            .FirstOrDefaultAsync();

        if (user is null) return NotFound("User with such email is not found");

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginModel.Password, user.HashPassword);

        if (!isPasswordValid) return Unauthorized("Credentials are invalid. Try again.");

        await _securityService.Authenticate(user);

        return Ok("User has been logged.");
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        var isUserExists = await _userRepository.Sql()
            .AnyAsync(x => x.Email!.Equals(registerModel.Email));

        if (isUserExists) return BadRequest("User with current email is already exists");

        var newUser = new User()
        {
            Name = registerModel.Name,
            Email = registerModel.Email,
            PhoneNumber = registerModel.PhoneNumber,
            HashPassword = BCrypt.Net.BCrypt.HashPassword(registerModel.Password)
        };
        
        await _userRepository.AddAsync(newUser);

        await _userRepository.SaveChangesAsync();

        await _securityService.Authenticate(newUser);

        return Ok("User has been registered and authenticated.");
    }

    [HttpPost("sign-out")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    public async Task<IActionResult> SignOutApp()
    {
        await _securityService.SignOut();
        return Ok("User has been logged out.");
    } 
}