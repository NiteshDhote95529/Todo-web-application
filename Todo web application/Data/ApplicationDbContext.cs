using Microsoft.EntityFrameworkCore;
using Todo_web_application.Models.Entities;

namespace Todo_web_application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskMaster> TaskMasters { get; set; }
    }
}
