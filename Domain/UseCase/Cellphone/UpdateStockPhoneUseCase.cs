using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Cellphone;
using Infrastructure.Model;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Cellphone
{
    public class UpdateStockUseCase : BaseUseCase<UpdateStockDto, Result>
    {
        private readonly ICellphoneRepository CellphoneRepository;

        public UpdateStockUseCase(ICellphoneRepository cellphoneRepository)
        {
            CellphoneRepository = cellphoneRepository;
        }

        public override async Task<Result> Execute(UpdateStockDto p)
        {
            try
            {
                await CellphoneRepository.UpdateStockCellphone(p);
                return Result.Ok(true);
            }
            catch (Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.CouldNotCreateUser));
            }
        }
    }
}
