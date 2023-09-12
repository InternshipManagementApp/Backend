using Backend.Data.Model;
using Backend.Data.Request;
using Backend.Data.Response;
using Backend.Repository.Interfaces;
using Backend.Service.Interfaces;

namespace Backend.Service.Classes
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public RoomsResponse GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public RoomResponse GetRoomById(int id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public RoomResponse AddNewRoom(RoomRequest room)
        {
            Room newRoom = new Room()
            {
                Name = room.Name,
                XStart = room.XStart,
                XEnd = room.XEnd,
                YStart = room.YStart,
                YEnd = room.YEnd
            };
            return _roomRepository.AddNewRoom(newRoom);
        }

        public RoomDeleteResponse DeleteRoomById(int id)
        {
            return _roomRepository.DeleteRoomById(id);
        }

        public RoomResponse UpdateRoom(int id, RoomRequest room)
        {
            Room updatedRoom = new Room()
            {
                Name = room.Name,
                XStart = room.XStart,
                XEnd = room.XEnd,
                YStart = room.YStart,
                YEnd = room.YEnd
            };
            return _roomRepository.UpdateRoom(id, updatedRoom);
        }
    }
}
