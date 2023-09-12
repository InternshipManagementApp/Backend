using Backend.Data.Request;
using Backend.Data.Response;

namespace Backend.Service.Interfaces
{
    public interface IRoadService
    {
        public RoadResponse GetRoadById(int id);
        public RoadOfUserResponse GetRoadOfUserResponse(int id);
        public RoadsResponse GetAllRoads();
        public RoadResponse AddNewRoad(RoadRequest road);
        public RoadDeleteResponse DeleteRoadById(int id);
    }
}
