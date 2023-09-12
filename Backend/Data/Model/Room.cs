using Backend.Data.Model;

namespace Backend.Data.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int XStart { get; set; }
        public int XEnd { get; set; }
        public int YStart { get; set; }
        public int YEnd { get; set; }
        public List<Road> Roads { get; set; }
    }
}
