using Backend.Data.Request;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ABackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("allUsers")]
        public IActionResult GetAllRooms()
        {
            var response = _userService.GetAllUsers();
            return Ok(response.Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var response = _userService.GetUserById(id);
            if (response.ErrorCode == 200)
            {
                return Ok(response.User);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost()]
        public IActionResult AddNewUser(UserRequest user)
        {
            var response = _userService.AddNewUser(user);
            if (response.ErrorCode == 201)
            {
                return Ok(response.User);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserRequest user)
        {
            var response = _userService.UpdateUser(id, user);
            if (response.ErrorCode == 200)
            {
                return Ok(response.User);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var response = _userService.DeleteUserById(id);
            if (response.ErrorCode == 200)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
