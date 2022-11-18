using Microsoft.EntityFrameworkCore;
using Issue_Tracker.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Issue_Tracker.Models
{
    public class TrackerDbContext :DbContext
    {
      public TrackerDbContext(DbContextOptions<TrackerDbContext> dbContextOptions)
            :base(dbContextOptions)
      { 
       }

       public DbSet<TrackerModels> ISSUE_TRACKER { get; set; }
    }
}
