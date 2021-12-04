using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Sql;
using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.DAL.Account
{
    public class AccountDbContext : EfDbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var accountModelBuilder = modelBuilder.Entity<AccountEntity>();
            accountModelBuilder.HasKey(x => x.Id);
            accountModelBuilder.HasIndex(x => x.Email).IsUnique();
            accountModelBuilder.HasIndex(x => x.Username).IsUnique();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}