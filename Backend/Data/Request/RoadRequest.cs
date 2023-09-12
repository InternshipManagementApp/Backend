namespace Backend.Data.Request
{
    public class RoadRequest
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateOnly Date { get; set; }
        public DateTime Time { get; set; }
    }
}
