using Microsoft.AspNetCore.Mvc;
using RestApp.Services.Contract;
using RestApp.ReservationDto;

namespace RestApp.Controllers
{
    [ApiController]
    [Route("api/RestApp/User")]
    
    public class UserController : ControllerBase
    {
        public readonly IUserService _userSevice;

        public UserController(IUserService userSevice)
        {
            _userSevice = userSevice;
        }



        // GET: api/User
        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            var Users = await _userSevice.GetAll();
            return Ok(Users);
        }

        // GET: api/User/5
        [HttpGet("GETBYid{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            return await _userSevice.GetById(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody] UserDto userDto)
        {
            return await _userSevice.Create(userDto);
        }

        // PUT: api/User/5
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            var updateUserDto = await _userSevice.Update(userDto);
            if (updateUserDto == null) { return NotFound(); }
            return Ok(updateUserDto);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userSevice.Delete(id);
            if (!result) { return NotFound(); }
            return Ok(result);
        }
    }
}