using PracticeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeTest.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User?> DeleteUser(int userId);
        Task<User?> GetUser(int userId);
        Task<List<User>?> GetAllUsers();
        Task<User> UpdateUser(User user);
    }
}