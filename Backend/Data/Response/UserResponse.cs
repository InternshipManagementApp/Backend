using Backend.Data.Model;

namespace Backend.Data.Response
{
    public class UserResponse
    {
        public User User { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }

    public class UsersResponse
    {
        public List<User> Users { get; set; }
        public int ItemCount { get; set; }
    }

    public class UserDeleteResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime DeletionTime { get; set; }
    }
}
