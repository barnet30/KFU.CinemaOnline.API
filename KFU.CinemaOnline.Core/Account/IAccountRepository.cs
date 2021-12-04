namespace KFU.CinemaOnline.Core.Account
{
    public interface IAccountRepository : IEfRepository<AccountEntity>
    {
        AccountEntity GetByUsernameAndPassword(string username, string password);
    }
}
