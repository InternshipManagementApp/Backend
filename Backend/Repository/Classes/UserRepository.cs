using Backend.Data;
using Backend.Data.Model;
using Backend.Data.Response;
using Backend.Repository.Interfaces;

namespace Backend.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly SqliteDbContext context;

        public UserRepository(SqliteDbContext context)
        {
            this.context = context;
        }
        public UsersResponse GetAllUsers()
        {
            var users = context.Users.ToList();
            var response = new UsersResponse();
            response.Users = users;
            response.ItemCount = users.Count();
            return response;
        }
        public UserResponse GetUserById(int id)
        {
            var user = context.Users.Find(id);
            var response = new UserResponse();
            if (user != null)
            {
                response.User = user;
                response.Message = id.ToString();
                response.ErrorCode = 200;
            }
            else
            {
                response.Message = "No user with id: " + id.ToString();
                response.ErrorCode = 404;
            }

            return response;
        }

        public UserResponse AddNewUser(User user)
        {
            var addResponse = context.Users.Add(user);
            context.SaveChanges();
            var theUser = context.Users.First(x => x.UserId == addResponse.Entity.UserId);
            var response = new UserResponse();

            if (theUser != null)
            {
                response.User = theUser;
                response.Message = "User added";
                response.ErrorCode = 201;
            }
            else
            {
                response.User = user;
                response.Message = "User was not created";
                response.ErrorCode = 400;
            }
            return response;
        }

        public UserDeleteResponse DeleteUserById(int id)
        {
            UserDeleteResponse response = new UserDeleteResponse();
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                response.ErrorCode = 200;
                response.Message = "Success deleted";
                response.DeletionTime = DateTime.Now;
            }
            else
            {
                response.ErrorCode = 404;
                response.Message = "No user with id: " + id.ToString();
                response.DeletionTime = DateTime.Now;
            }
            return response;
        }

        public UserResponse UpdateUser(int id, User newUser)
        {
            var user = context.Users.Find(id);
            var response = new UserResponse();
            if (user != null)
            {
                if (newUser.Name != "string")
                {
                    user.Name = newUser.Name;
                }
                if (newUser.Telephone != "string")
                {
                    user.Telephone = newUser.Telephone;
                }
                if (newUser.Email != "string")
                {
                    user.Email = newUser.Email;
                }
                if (newUser.Password != "string")
                {
                    user.Password = newUser.Password;
                }
                if (newUser.Type != "string")
                {
                    user.Type = newUser.Type;
                }
                context.Users.Update(user);
                context.SaveChanges();
                response.User = user;
                response.Message = "User  updated";
                response.ErrorCode = 200;
            }
            else
            {
                response.User = newUser;
                response.Message = "No user with id: " + id.ToString();
                response.ErrorCode = 404;

            }
            return response;
        }
    }
}
