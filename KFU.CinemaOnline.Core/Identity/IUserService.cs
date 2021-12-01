using System.Collections.Generic;
using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.Identity
{
    public interface IUserService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model);
        Task<AuthenticateResponseModel> Register(UserModel userModel);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);

    }
}
