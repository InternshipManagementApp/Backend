using Backend.Data.Request;
using Backend.Data.Response;

namespace Backend.Service.Interfaces
{
    public interface IRoomService
    {
        public RoomResponse GetRoomById(int id);
        public RoomsResponse GetAllRooms();
        public RoomResponse AddNewRoom(RoomRequest room);
        public RoomResponse UpdateRoom(int id, RoomRequest room);
        public RoomDeleteResponse DeleteRoomById(int id);
    }
}
