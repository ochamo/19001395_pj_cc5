using Business.UseCase;
using Domain.Repository;
using Infrastructure;
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
    public class GetCellphonesUseCase : BaseUseCase<None, Result<List<CelularModel>>>
    {
        private ICellphoneRepository CellphoneRepository;

        public GetCellphonesUseCase(ICellphoneRepository cellphoneRepository)
        {
            CellphoneRepository = cellphoneRepository;
        }

        public override async Task<Result<List<CelularModel>>> Execute(None p)
        {
            try
            {
                var result = await CellphoneRepository.GetCellphones();
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<CelularModel>>(new ErrorModel(ErrorCodes.CouldNotLoadAddresses));
            }
        }
    }
}
