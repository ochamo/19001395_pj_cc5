using Infrastructure.Dto.User;
using Infrastructure.Model;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        public Task<LoginModel> Login(LoginDTO loginDto);

        public Task<int> CreateUser(CreateUserDTO userDto);

        public Task UpdatePassword(UpdatePasswordDTO updatePasswordDto);

    }
}
