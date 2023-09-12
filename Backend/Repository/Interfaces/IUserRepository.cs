using Backend.Data;
using Backend.Data.Model;
using Backend.Data.Response;

namespace Backend.Repository.Interfaces
{
    public interface IUserRepository
    {
        public UserResponse GetUserById(int id);
        public UsersResponse GetAllUsers();

        public UserResponse AddNewUser(User user);
        public UserResponse UpdateUser(int id, User user);
        public UserDeleteResponse DeleteUserById(int id);
    }
}
