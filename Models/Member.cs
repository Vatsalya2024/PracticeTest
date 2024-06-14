using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeTest.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime MembershipExpiry { get; set; }
        public DateTime DOJ { get; set;}
    }
}
