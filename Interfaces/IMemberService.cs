using PracticeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeTest.Services
{
    public interface IMemberService
    {
        Task<Member> AddMember(Member member);
        Task<Member> DeleteMember(int memberId);
        Task<Member> GetMember(int memberId);
        Task<List<Member>> GetAllMembers();
        Task<Member> UpdateMember(Member member);
    }
}