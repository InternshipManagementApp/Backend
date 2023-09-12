using Backend.Data.Request;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("allRooms")]
        public IActionResult GetAllRooms()
        {
            var response = _roomService.GetAllRooms();
            return Ok(response.Rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var response = _roomService.GetRoomById(id);
            if (response.ErrorCode == 200)
            {
                return Ok(response.Room);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost()]
        public IActionResult AddNewRoom(RoomRequest room)
        {
            var response = _roomService.AddNewRoom(room);
            if (response.ErrorCode == 201)
            {
                return Ok(response.Room);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, RoomRequest song)
        {
            var response = _roomService.UpdateRoom(id, song);
            if (response.ErrorCode == 200)
            {
                return Ok(response.Room);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoomById(int id)
        {
            var response = _roomService.DeleteRoomById(id);
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
