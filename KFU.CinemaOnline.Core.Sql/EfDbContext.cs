using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.Core.Sql
{
    public abstract class EfDbContext : DbContext
    {
        protected EfDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
