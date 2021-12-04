using System.Linq;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Sql;

namespace KFU.CinemaOnline.DAL.Account
{
    public class AccountRepository : EfRepository<AccountEntity>, IAccountRepository
    {
        private readonly AccountDbContext _context;
        public AccountRepository(AccountDbContext context) : base(context)
        {
            _context = context;
        }

        public AccountEntity GetByUsernameAndPassword(string username, string password)
        {
            return _context.Accounts.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
