﻿namespace KFU.CinemaOnline.Core.Account
{
    public interface IAccountRepository : IEfRepository<AccountEntity>
    {
        AccountEntity GetByUsernameAndPassword(string username, string password);
        AccountEntity GetByUsername(string username);
        AccountEntity GetByEmail(string email);
    }
}
