

using Microsoft.AspNetCore.Mvc;
using PracticeTest.Models;
using PracticeTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var members = await _memberService.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _memberService.GetMember(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            var newMember = await _memberService.AddMember(member);
            return CreatedAtAction(nameof(GetMember), new { id = newMember.MemberId }, newMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }
            await _memberService.UpdateMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var member = await _memberService.DeleteMember(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
    }
}