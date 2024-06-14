using Microsoft.EntityFrameworkCore;
using PracticeTest.Context;
using PracticeTest.Exceptions;
using PracticeTest.Interfaces;
using PracticeTest.Models;

namespace PracticeTest.Repositories
{
    public class MemberRepository : IRepository<int, Member>
    {
        private readonly PracticeContext _practiceContext;

        public MemberRepository(PracticeContext practiceContext)
        {
            _practiceContext = practiceContext;
        }
        public async Task<Member> Add(Member item)
        {
            _practiceContext.Add(item);
            await _practiceContext.SaveChangesAsync();
            return item;
        }

        public async Task<Member?> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _practiceContext.Remove(user);
                _practiceContext.SaveChanges();
                return user;
            }
            return null;
        }

        public async Task<Member?> Get(int key)
        {
            var getUsers = await GetAll();
            var getUser = getUsers.FirstOrDefault(g => g.MemberId == key);
            if (getUser != null)
            {
                return getUser;
            }
            throw new NoSuchUserException();
        }

        public async Task<List<Member>?> GetAll()
        {
            var users = await _practiceContext.Members.ToListAsync();
            return users;
        }

        public async Task<Member> Update(Member item)
        {
            var user = await Get(item.MemberId);
            if (user != null)
            {
                _practiceContext.Entry<Member>(item).State = EntityState.Modified;
                _practiceContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
