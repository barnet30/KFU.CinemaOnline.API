using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Identity;

namespace KFU.CinemaOnline.BL.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private 

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthenticateResponseModel Authenticate(AuthenticateRequestModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<AuthenticateResponseModel> Register(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
