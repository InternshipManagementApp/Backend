using Backend.Data.Model;
using Backend.Data.Response;

namespace Backend.Repository.Interfaces
{
    public interface IRoomRepository
    {
        public RoomResponse GetRoomById(int id);
        public RoomsResponse GetAllRooms();

        public RoomResponse AddNewRoom(Room room);
        public RoomResponse UpdateRoom(int id, Room room);
        public RoomDeleteResponse DeleteRoomById(int id);
    }
}
