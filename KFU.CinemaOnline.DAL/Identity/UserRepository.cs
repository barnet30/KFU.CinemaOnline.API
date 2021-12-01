using KFU.CinemaOnline.Core.Identity;
using KFU.CinemaOnline.Core.Sql;

namespace KFU.CinemaOnline.DAL.Identity
{
    public class UserRepository : EfRepository<UserEntity>, IUserRepository
    {
        public UserRepository(EfDbContext context) : base(context)
        {
        }
    }
}
