using Backend.Data.Request;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadController : ControllerBase
    {
        private readonly IRoadService _roadService;

        public RoadController(IRoadService roadService)
        {
            _roadService = roadService;
        }

        [HttpGet("allRoads")]
        public IActionResult GetAllRoads()
        {
            var response = _roadService.GetAllRoads();
            return Ok(response.Roads);
        }

        [HttpGet("allRoadsOfUser")]
        public IActionResult GetAllRoadOfUser(int id)
        {
            var response = _roadService.GetRoadOfUserResponse(id);
            return Ok(response.Roads);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoadById(int id)
        {
            var response = _roadService.GetRoadById(id);
            if (response.ErrorCode == 200)
            {
                return Ok(response.Road);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost()]
        public IActionResult AddNewRoute(RoadRequest road)
        {
            var response = _roadService.AddNewRoad(road);
            if (response.ErrorCode == 201)
            {
                return Ok(response.Road);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoadById(int id)
        {
            var response = _roadService.DeleteRoadById(id);
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
