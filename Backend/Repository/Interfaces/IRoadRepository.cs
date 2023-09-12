using Backend.Data.Model;
using Backend.Data.Response;
using Backend.Data.Request;

namespace Backend.Repository.Interfaces
{
    public interface IRoadRepository
    {
        public RoadResponse GetRoadById(int id);
        public RoadsResponse GetAllRoads();
        public RoadResponse AddNewRoad(Road road);
        public RoadDeleteResponse DeleteRoadById(int id);
        public RoadOfUserResponse GetAllRoadsOfUser(int id);
    }
}
