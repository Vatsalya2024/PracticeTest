using PracticeTest.Exceptions;
using PracticeTest.Interfaces;
using PracticeTest.Models;
using PracticeTest.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeTest.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<User?> DeleteUser(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<User?> GetUser(int userId)
        {
            try
            {
                return await _userRepository.Get(userId);
            }
            catch (NoSuchUserException)
            {
                return null;
            }
        }

        public async Task<List<User>?> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }
    }
}