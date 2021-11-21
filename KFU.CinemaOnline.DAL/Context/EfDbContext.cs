using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.DAL.Context
{
    public abstract class EfDbContext : DbContext
    {
        protected EfDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
