using Car.Demo.DLL.Entities;
using Car.Demo.DLL.Repositories;
using Car.Demo.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car.Demo.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class SubscriptionController: ControllerBase
{
    private readonly ISecurityService _securityService;
    private readonly IRepository<Company> _companyRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Subscription> _subscriptionRepository;

    public SubscriptionController(
        ISecurityService securityService, 
        IRepository<Company> companyRepository, 
        IRepository<User> userRepository,
        IRepository<Subscription> subscriptionRepository)
    {
        _securityService = securityService;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    [HttpPost("{companyId:Guid}")]
    public async Task<ActionResult<string>> Subscribe(Guid companyId)
    {
        var userId = Guid.Parse(_securityService.GetCurrentUserId()!);
        var user = await _userRepository.Sql().Include(x => x.Companies).FirstOrDefaultAsync(x => x.Id.Equals(userId));
        var company = await _companyRepository.Sql().FirstOrDefaultAsync(x => x.Id.Equals(companyId))!;

        if (company is null)
        {
            return BadRequest("Company has not been found.");
        }

        if (user!.Companies.Any(x => x.Id.Equals(companyId)))
        {
            return Ok("User already has a subscription to this company");
        }
        
        user!.Companies.Add(company);
        
        user!.Subscriptions.Add(new Subscription()
        {
            UserId = user.Id,
            CompanyId = company.Id,
            IsActive = true
        });
        
        await _userRepository.SaveChangesAsync();

        return Ok("Subscription has been issued successfully.");
    }
}