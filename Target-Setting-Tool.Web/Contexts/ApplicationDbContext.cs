using Microsoft.EntityFrameworkCore;
using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> context ) : base( context )
        {

        }
        public DbSet<Right> MST_Rights { get; set; }
        public DbSet<Role> MST_Roles { get; set; }
        public DbSet<User> MST_Users { get; set; }
    }
}
