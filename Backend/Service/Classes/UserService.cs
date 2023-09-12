using Backend.Data.Model;
using Backend.Data.Request;
using Backend.Data.Response;
using Backend.Repository;
using Backend.Repository.Interfaces;
using Backend.Service.Interfaces;

namespace Backend.Service.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public UsersResponse GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserResponse GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public UserResponse AddNewUser(UserRequest user)
        {
            User newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Type = user.Type,
                Password = user.Password,
                Telephone = user.Telephone
            };
            return _userRepository.AddNewUser(newUser);
        }

        public UserDeleteResponse DeleteUserById(int id)
        {
            return _userRepository.DeleteUserById(id);
        }

        public UserResponse UpdateUser(int id, UserRequest user)
        {
            User updatedUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Type = user.Type,
                Password = user.Password,
                Telephone = user.Telephone
            };
            return _userRepository.UpdateUser(id, updatedUser);
        }
    }
}
