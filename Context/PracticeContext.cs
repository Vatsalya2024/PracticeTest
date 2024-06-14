using Microsoft.EntityFrameworkCore;
using PracticeTest.Models;

namespace PracticeTest.Context
{
    public class PracticeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public PracticeContext(DbContextOptions options) : base(options)
        {
           

        }

    }
}
