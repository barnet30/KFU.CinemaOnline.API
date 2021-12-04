namespace KFU.CinemaOnline.Core.Account
{
    public interface IAccountService
    {
        AccountEntity AuthenticateUser(string username, string password);
    }
}
