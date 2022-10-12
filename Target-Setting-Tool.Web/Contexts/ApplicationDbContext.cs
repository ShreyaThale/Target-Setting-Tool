using Microsoft.EntityFrameworkCore;
using TargetSettingTool.Web.Models;

namespace TargetSettingTool.Web.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context):base(context)
        {
                
        }
        public DbSet<Rights> MST_RightsTBl { get; set; }
    }
}
