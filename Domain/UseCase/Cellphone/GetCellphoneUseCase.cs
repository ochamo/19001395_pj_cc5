using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Cellphone;
using Infrastructure.Model;
using Infrastructure.Model.Cellphone;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Cellphone
{
    public class GetCellphoneUseCase: BaseUseCase<GetCellphoneDetailDTO, Result<CelularModel>>
    {
        private readonly ICellphoneRepository CellphoneRepository;

        public GetCellphoneUseCase(ICellphoneRepository cellphoneRepository)
        {
            CellphoneRepository = cellphoneRepository;
        }

        public override async Task<Result<CelularModel>> Execute(GetCellphoneDetailDTO p)
        {
            try
            {
                var result = await CellphoneRepository.GetCellphoneDetail(p);
                return Result.Ok(result);
            } catch(Exception ex)
            {
                return Result.Fail<CelularModel>(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
