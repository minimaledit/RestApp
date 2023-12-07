using Microsoft.AspNetCore.Mvc;
using RestApp.ReservationDto;
using RestApp.Services.Contract;

[ApiController]
[Route("api/RestApp/User")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/RestApp/User/Users
    [HttpGet("Users")]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    // GET: api/RestApp/User/GETBYid/{id}
    [HttpGet("GETBYid/{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _userService.GetById(id);
        return user != null ? Ok(user) : NotFound();
    }

    // POST: api/RestApp/User
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
    {
        var createdUser = await _userService.Create(userDto);
        return Ok(createdUser);
    }

    // PUT: api/RestApp/User
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
    {
        var updatedUser = await _userService.Update(userDto);
        return updatedUser != null ? Ok(updatedUser) : NotFound();
    }

    // DELETE: api/RestApp/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _userService.Delete(id);
        return result ? Ok(result) : NotFound();
    }
}
