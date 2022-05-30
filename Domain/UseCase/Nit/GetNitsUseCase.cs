using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Nit;
using Infrastructure.Model;
using Infrastructure.Model.Nit;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Nit
{
    public class GetNitsUseCase : BaseUseCase<GetNitDto, Result<List<NitModel>>>
    {
        private readonly INitRepository NitRepository;

        public GetNitsUseCase(INitRepository nitRepository)
        {
            NitRepository = nitRepository;
        }

        public override async Task<Result<List<NitModel>>> Execute(GetNitDto p)
        {
            try
            {
                var result = await NitRepository.GetNit(p);
                return Result.Ok(result);
            } catch (Exception ex)
            {
                return Result.Fail<List<NitModel>>(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
