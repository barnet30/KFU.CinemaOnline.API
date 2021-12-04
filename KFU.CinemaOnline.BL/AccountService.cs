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

        public AccountEntity AuthenticateUser(string username, string password)
        {
            return _accountRepository.GetByUsernameAndPassword(username, password);
        }
    }
}
