using Infrastructure.Dto;
using Infrastructure.Model;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        public Task<LoginModel> login(LoginDto loginDto);

        public Task createUser(CreateUserDto userDto);
    }
}
