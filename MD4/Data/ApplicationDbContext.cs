using MD4.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MD4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tika izvelets dotais datubazes variants 

        public DbSet<MD4.Models.Teacher> Teachers { get; set; }
        public DbSet<MD4.Models.Course> Courses { get; set; }
        public DbSet<MD4.Models.Assignment> Assignments { get; set; }
        public DbSet<MD4.Models.Student> Students { get; set; }
        public DbSet<MD4.Models.Submission> Submissions { get; set; }

    }
}
