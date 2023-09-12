using Backend.Data.Model;
using Backend.Data.Response;
using Backend.Data;
using Backend.Repository.Interfaces;

namespace Backend.Repository.Classes
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqliteDbContext context;

        public RoomRepository(SqliteDbContext context)
        {
            this.context = context;
        }
        public RoomsResponse GetAllRooms()
        {
            var rooms = context.Rooms.ToList();
            var response = new RoomsResponse();
            response.Rooms = rooms;
            response.ItemCount = rooms.Count();
            return response;
        }
        public RoomResponse GetRoomById(int id)
        {
            var room = context.Rooms.Find(id);
            var response = new RoomResponse();
            if (room != null)
            {
                response.Room = room;
                response.Message = id.ToString();
                response.ErrorCode = 200;
            }
            else
            {
                response.Message = "No room with id: " + id.ToString();
                response.ErrorCode = 404;
            }

            return response;
        }

        public RoomResponse AddNewRoom(Room room)
        {
            var addResponse = context.Rooms.Add(room);
            context.SaveChanges();
            var theRoom = context.Rooms.First(x => x.RoomId == addResponse.Entity.RoomId);
            var response = new RoomResponse();

            if (theRoom != null)
            {
                response.Room = theRoom;
                response.Message = "Room added";
                response.ErrorCode = 201;
            }
            else
            {
                response.Room = room;
                response.Message = "Room was not created";
                response.ErrorCode = 400;
            }
            return response;
        }

        public RoomDeleteResponse DeleteRoomById(int id)
        {
            RoomDeleteResponse response = new RoomDeleteResponse();
            var room = context.Rooms.Find(id);
            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
                response.ErrorCode = 200;
                response.Message = "Success deleted";
                response.DeletionTime = DateTime.Now;
            }
            else
            {
                response.ErrorCode = 404;
                response.Message = "No room with id: " + id.ToString();
                response.DeletionTime = DateTime.Now;
            }
            return response;
        }

        public RoomResponse UpdateRoom(int id, Room updatedRoom)
        {
            var room = context.Rooms.Find(id);
            var response = new RoomResponse();
            if (room != null)
            {
                if (updatedRoom.Name != "string")
                {
                    room.Name = updatedRoom.Name;
                }
                context.Rooms.Update(room);
                context.SaveChanges();
                response.Room = room;
                response.Message = "Room  updated";
                response.ErrorCode = 200;
            }
            else
            {
                response.Room = updatedRoom;
                response.Message = "No room with id: " + id.ToString();
                response.ErrorCode = 404;

            }
            return response;
        }
    }
}
