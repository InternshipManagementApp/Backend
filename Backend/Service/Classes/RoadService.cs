using Backend.Data.Model;
using Backend.Data.Request;
using Backend.Data.Response;
using Backend.Repository.Interfaces;
using Backend.Service.Interfaces;
using System.Xml.Linq;

namespace Backend.Service.Classes
{
    public class RoadService : IRoadService
    {
        private readonly IRoadRepository _roadRepository;

        public RoadService(IRoadRepository roadRepository)
        {
            _roadRepository = roadRepository;
        }

        public RoadsResponse GetAllRoads()
        {
            return _roadRepository.GetAllRoads();
        }

        public RoadOfUserResponse GetRoadOfUserResponse(int id)
        {
            return _roadRepository.GetAllRoadsOfUser(id);
        }

        public RoadResponse GetRoadById(int id)
        {
            return _roadRepository.GetRoadById(id);
        }

        public RoadResponse AddNewRoad(RoadRequest road)
        {
            Road newRoad = new Road()
            {
                RoomId = road.RoomId,
                UserId = road.UserId,
                Date = road.Date,
                Time = road.Time
            };
            return _roadRepository.AddNewRoad(newRoad);
        }

        public RoadDeleteResponse DeleteRoadById(int id)
        {
            return _roadRepository.DeleteRoadById(id);
        }
    }
}
