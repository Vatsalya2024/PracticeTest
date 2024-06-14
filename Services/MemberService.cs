using PracticeTest.Models;
using PracticeTest.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeTest.Services
{
    public class MemberService : IMemberService
    {
        private readonly MemberRepository _repository;

        public MemberService(MemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<Member> AddMember(Member member)
        {
            return await _repository.Add(member);
        }

        public async Task<Member> DeleteMember(int memberId)
        {
            return await _repository.Delete(memberId);
        }

        public async Task<Member> GetMember(int memberId)
        {
            return await _repository.Get(memberId);
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _repository.GetAll();
        }

        public async Task<Member> UpdateMember(Member member)
        {
            return await _repository.Update(member);
        }
    }
}