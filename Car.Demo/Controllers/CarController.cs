using Car.Demo.Attributes;
using Car.Demo.Common.Enums;
using Car.Demo.DLL.Repositories;
using Car.Demo.Models;
using Car.Demo.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car.Demo.Controllers;

using Car = DLL.Entities.Car;

[ApiController]
[Route("api/car")]
public class CarController: ControllerBase
{
    private readonly IRepository<Car> _carRepository;
    private readonly ISecurityService _securityService;

    public CarController(IRepository<Car> carRepository, ISecurityService securityService)
    {
        _carRepository = carRepository;
        _securityService = securityService;
    }
    
    [HttpGet("all-cars")]
    public async Task<ActionResult<List<Car>>> AllCars([FromQuery] bool withPublisher) => 
        withPublisher ? 
            await _carRepository.Sql().Include(x => x.Publisher).ToListAsync() 
            :
            await _carRepository.Sql().ToListAsync();

    [HttpPost("add-car")]
    [AuthorizeUser(RoleTypes.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    public async Task<ActionResult<Car>> AddCar(CarToCreateModel createModel)
    {
        var carToAdd = new Car()
        {
            Brand = createModel.Brand,
            Country = createModel.Country,
            Model = createModel.Model,
            Price = createModel.Price,
            PublisherId = Guid.Parse(_securityService.GetCurrentUserId()!)
        };
        
        await _carRepository.AddAsync(carToAdd);
        await _carRepository.SaveChangesAsync();

        return Ok(carToAdd);
    }
    
    [HttpPut("update-car")]
    [AuthorizeUser(RoleTypes.Admin, RoleTypes.Manager)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    public async Task<ActionResult<Car>> UpdateCar(CarToUpdate updateModel)
    {
        var carToUpdate = await _carRepository.Sql()
            .FirstOrDefaultAsync(x => x.Id.Equals(updateModel.CarId));
        
        carToUpdate.Brand = updateModel.Brand;
        carToUpdate.Country = updateModel.Country;
        carToUpdate.Model = updateModel.Model;
        carToUpdate.Price = updateModel.Price;
        
        await _carRepository.UpdateAsync(carToUpdate);
        await _carRepository.SaveChangesAsync();

        return Ok(carToUpdate);
    }
    
    [HttpDelete("delete-car/{Id:Guid}")]
    [AuthorizeUser(RoleTypes.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    public async Task<ActionResult<Car>> DeleteCar(Guid Id)
    {
        var car = await _carRepository.Sql().FirstOrDefaultAsync(x => x.Id.Equals(Id));

        if (car is null) return NotFound("Car is not found.");
            
        await _carRepository.DeleteAsync(car);
        await _carRepository.SaveChangesAsync();

        return Ok($"Car with {Id} has been successfully deleted.");
    }
}