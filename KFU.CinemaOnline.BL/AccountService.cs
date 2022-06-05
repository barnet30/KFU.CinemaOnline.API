using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.BL
{
    
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountEntity GetByUsernameAndPassword(string username, string password)
        {
            return _accountRepository.GetByUsernameAndPassword(username, password);
        }

        public AccountEntity GetByUsername(string username)
        {
            return _accountRepository.GetByUsername(username);
        }

        public AccountEntity GetByEmail(string email)
        {
            return _accountRepository.GetByEmail(email);
        }

        public async Task<AccountEntity> AddNewUser(AccountEntity account)
        {
            account.Roles = new[] { Role.User };
            return await _accountRepository.CreateAsync(account);
        }

        public async Task<List<AccountEntity>> GetUsers()
        {
            return await _accountRepository.GetAccounts();
        }

        public async Task<AccountEntity> GetUserById(int id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task<AccountEntity> UpdateRoles(int id, Role[] roles)
        {
            var user = await _accountRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            user.Roles = roles;
            return await _accountRepository.UpdateAsync(user);
        }

        public async Task RemoveAccount(int id)
        {
            await _accountRepository.DeleteByIdAsync(id);
        }
    }
}
