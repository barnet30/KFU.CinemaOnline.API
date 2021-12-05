namespace KFU.CinemaOnline.Core.Account
{
    public interface IAccountService
    {
        AccountEntity GetByUsernameAndPassword(string username, string password);
        AccountEntity GetByUsername(string username);
        AccountEntity GetByEmail(string email);
    }
}
