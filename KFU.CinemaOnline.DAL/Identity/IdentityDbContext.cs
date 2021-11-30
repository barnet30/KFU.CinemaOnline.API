using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Identity;
using KFU.CinemaOnline.Core.Sql;
using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.DAL.Identity
{
    public class IdentityDbContext : EfDbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var userModelBuilder = modelBuilder.Entity<UserEntity>();
            userModelBuilder.HasKey(x => x.Id);
            userModelBuilder.HasIndex(x => x.Email).IsUnique();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}