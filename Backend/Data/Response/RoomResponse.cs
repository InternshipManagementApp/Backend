using Backend.Data.Model;

namespace Backend.Data.Response
{
    public class RoomResponse
    {
        public Room Room { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }

    public class RoomsResponse
    {
        public List<Room> Rooms { get; set; }
        public int ItemCount { get; set; }
    }

    public class RoomDeleteResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime DeletionTime { get; set; }
    }
}
