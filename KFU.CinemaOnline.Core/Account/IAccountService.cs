using System.Collections.Generic;
using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.Account
{
    public interface IAccountService
    {
        AccountEntity GetByUsernameAndPassword(string username, string password);
        AccountEntity GetByUsername(string username);
        AccountEntity GetByEmail(string email);
        Task<AccountEntity> AddNewUser(AccountEntity account);
        Task<List<AccountEntity>> GetUsers();
        Task<AccountEntity> GetUserById(int id);
        Task<AccountEntity> UpdateRoles(int id, Role[] roles);
        Task RemoveAccount(int id);
    }
}
