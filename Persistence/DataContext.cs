using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: DbContext
    {

        #region CTOR
        public DataContext(DbContextOptions options): base(options)
        { 
        }
        #endregion

        public DbSet<Activity> Activity { get; set; }

    }
}