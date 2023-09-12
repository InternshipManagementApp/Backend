using Backend.Data.Model;

namespace Backend.Data.Response
{
    public class RoadResponse
    {
        public Road Road { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }

    public class RoadOfUserResponse
    {
        public List<Road> Roads { get; set; }
        public int ItemCount { get; set; }
    }

    public class RoadsResponse
    {
        public List<Road> Roads { get; set; }
        public int ItemCount { get; set; }
    }

    public class RoadDeleteResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime DeletionTime { get; set; }
    }
}
