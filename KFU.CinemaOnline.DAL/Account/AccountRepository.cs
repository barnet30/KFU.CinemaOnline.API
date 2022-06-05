using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Sql;
using Microsoft.EntityFrameworkCore;

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
            return _context.Accounts.AsNoTracking().FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public AccountEntity GetByUsername(string username)
        {
            return _context.Accounts.AsNoTracking().FirstOrDefault(x => x.Username == username);
        }

        public AccountEntity GetByEmail(string email)
        {
            return _context.Accounts.AsNoTracking().FirstOrDefault(x => x.Email == email);
        }

        public async Task<List<AccountEntity>> GetAccounts()
        {
            return await _context.Accounts.AsNoTracking().OrderBy(x=>x.Id).ToListAsync();
        }
    }
}
