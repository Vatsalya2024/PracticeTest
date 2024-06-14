using Microsoft.EntityFrameworkCore;
using PracticeTest.Context;
using PracticeTest.Exceptions;
using PracticeTest.Interfaces;
using PracticeTest.Models;

namespace PracticeTest.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PracticeContext _practiceContext;

        public UserRepository(PracticeContext practiceContext) {
            _practiceContext = practiceContext;
        }
        public async Task<User> Add(User item)
        {
           _practiceContext.Add(item);
            await _practiceContext.SaveChangesAsync();
            return item;
        }

        public async Task<User?> Delete(int key)
        {
            var foundUser = await Get(key);
            if (foundUser != null)
            {
                return null;
            }
            else { 
            _practiceContext.Users.Remove(foundUser);
                await _practiceContext.SaveChangesAsync();
                return foundUser;
            }
        }

        public async Task<User?> Get(int key)
        {
            var getUsers = await GetAll();
            var getUser = getUsers.FirstOrDefault(g => g.UserId == key);
            if (getUser != null)
            {
                return getUser;
            }
            throw new NoSuchUserException();
        }

        public async Task<List<User>?> GetAll()
        {
            var users = await _practiceContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                _practiceContext.Entry<User>(item).State = EntityState.Modified;
                _practiceContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
