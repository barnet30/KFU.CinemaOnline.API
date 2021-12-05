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
            throw new System.NotImplementedException();
        }

        public AccountEntity GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
