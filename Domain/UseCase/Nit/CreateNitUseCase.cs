using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Nit;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Domain.UseCase.Nit
{
    public class CreateNitUseCase : BaseUseCase<CreateNitDto, Result>
    {
        private INitRepository NitRepository;

        public CreateNitUseCase(INitRepository nitRepository)
        {
            NitRepository = nitRepository;
        }

        public override async Task<Result> Execute(CreateNitDto p)
        {
            try
            {
                await NitRepository.InsertNit(p);
                return Result.Ok();
            }catch(Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
