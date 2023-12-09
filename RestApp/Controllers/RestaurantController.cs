using Microsoft.AspNetCore.Mvc;
using RestApp.ReservationDto;
using RestApp.Services.Contract;

[ApiController]
[Route("api/RestApp/Restaurant")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    // GET all
    [HttpGet("Restaurants")]
    public async Task<ActionResult<List<RestaurantDto>>> GetRestaurants()
    {
        var restaurants = await _restaurantService.GetAll();
        return Ok(restaurants);
    }

    // GETBYid/{id}
    [HttpGet("GETBYid/{id}")]
    public async Task<ActionResult<RestaurantDto>> GetRestaurant(int id)
    {
        var restaurant = await _restaurantService.GetById(id);
        return restaurant != null ? Ok(restaurant) : NotFound();
    }

    // GETBYname
    [HttpGet("GETBYname/{name}")]
    public async Task<ActionResult<RestaurantDto>> GetByName(string name)
    {
        var restaurant = await _restaurantService.GetByName(name);
        return restaurant != null ? Ok(restaurant) : NotFound(null);
    }

    // POST: Create
    [HttpPost("Create")]
    public async Task<ActionResult<RestaurantDto>> CreateRestaurant([FromBody] RestaurantDto restaurantDto)
    {
        var createdRestaurant = await _restaurantService.Create(restaurantDto);
        return Ok(createdRestaurant);
    }

    // PUT
    [HttpPut("Put")]
    public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantDto restaurantDto)
    {
        var updatedRestaurant = await _restaurantService.Update(restaurantDto);
        return updatedRestaurant != null ? Ok(updatedRestaurant) : NotFound();
    }

    // DELETE: Delete{id}
    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var result = await _restaurantService.Delete(id);
        return result ? Ok(result) : NotFound();
    }
}
