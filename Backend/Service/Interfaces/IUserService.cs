using Backend.Data.Request;
using Backend.Data.Response;

namespace Backend.Service.Interfaces
{
    public interface IUserService
    {
        public UserResponse GetUserById(int id);
        public UsersResponse GetAllUsers();
        public UserResponse AddNewUser(UserRequest user);
        public UserResponse UpdateUser(int id, UserRequest user);
        public UserDeleteResponse DeleteUserById(int id);
    }
}
