using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.User;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Business.UseCase
{
    public class LoginUseCase : BaseUseCase<LoginDTO, Result<LoginModel>>
    {
        private readonly IUserRepository userRepository;

        public LoginUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override async Task<Result<LoginModel>> Execute(LoginDTO p)
        {
            try
            {
                var result = await userRepository.Login(p);
                if (result != null)
                {
                    return Result.Ok(result);
                } else
                {
                    return Result.Fail<LoginModel>(new ErrorModel(ErrorCodes.UserNotFound));
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<LoginModel>(new ErrorModel(ErrorCodes.UserNotFound));
            }
        }
    }
}
