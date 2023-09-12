using Backend.Repository.Interfaces;
using Backend.Data.Response;
using Backend.Data.Model;
using Backend.Data.Request;
using Backend.Data;

namespace Backend.Repository.Classes
{
    public class RoadRepository : IRoadRepository
    {
        private readonly SqliteDbContext context;

        public RoadRepository(SqliteDbContext context)
        {
            this.context = context;
        }
        public RoadsResponse GetAllRoads()
        {
            var roads = context.Roads.ToList();
            var response = new RoadsResponse();
            response.Roads = roads;
            response.ItemCount = roads.Count();
            return response;
        }

        public RoadOfUserResponse GetAllRoadsOfUser(int id)
        {
            var roads = context.Roads.Where(x => x.UserId == id).ToList();
            var response = new RoadOfUserResponse();
            response.Roads = roads;
            response.ItemCount = roads.Count();
            return response;

        }
        public RoadResponse GetRoadById(int id)
        {
            var road = context.Roads.Find(id);
            var response = new RoadResponse();
            if (road != null)
            {
                response.Road = road;
                response.Message = id.ToString();
                response.ErrorCode = 200;
            }
            else
            {
                response.Message = "No route with id: " + id.ToString();
                response.ErrorCode = 404;
            }

            return response;
        }

        public RoadResponse AddNewRoad(Road road)
        {
            var addResponse = context.Roads.Add(road);
            context.SaveChanges();
            var theRoad = context.Roads.First(x => x.RoadId == addResponse.Entity.RoadId);
            var response = new RoadResponse();

            if (theRoad != null)
            {
                response.Road = theRoad;
                response.Message = "Road added";
                response.ErrorCode = 201;
            }
            else
            {
                response.Road = road;
                response.Message = "Road was not created";
                response.ErrorCode = 400;
            }
            return response;
        }

        public RoadDeleteResponse DeleteRoadById(int id)
        {
            RoadDeleteResponse response = new RoadDeleteResponse();
            var road = context.Roads.Find(id);
            if (road != null)
            {
                context.Roads.Remove(road);
                context.SaveChanges();
                response.ErrorCode = 200;
                response.Message = "Success deleted";
                response.DeletionTime = DateTime.Now;
            }
            else
            {
                response.ErrorCode = 404;
                response.Message = "No road with id: " + id.ToString();
                response.DeletionTime = DateTime.Now;
            }
            return response;
        }
    }
}
