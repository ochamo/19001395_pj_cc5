
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.User;
using Infrastructure.Model;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UseCase
{
    public class CreateUserUseCase : BaseUseCase<CreateUserDTO, Result>
    {
        private readonly IUserRepository userRepository;

        public CreateUserUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override async Task<Result> Execute(CreateUserDTO p)
        {
            try
            {
                await userRepository.CreateUser(p);
                return Result.Ok(true);
            } catch (Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.CouldNotCreateUser));
            }
        } 
    }
}
