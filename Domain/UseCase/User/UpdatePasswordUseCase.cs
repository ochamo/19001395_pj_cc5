using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.User;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Domain.UseCase.User
{
    public class UpdatePasswordUseCase : BaseUseCase<UpdatePasswordDTO, Result>
    {
        private readonly IUserRepository userRepository;

        public UpdatePasswordUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override async Task<Result> Execute(UpdatePasswordDTO p)
        {
            try
            {
                await userRepository.UpdatePassword(p);
                return Result.Ok();
            } catch (Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
