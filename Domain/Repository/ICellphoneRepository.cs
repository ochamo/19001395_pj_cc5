using Infrastructure.Dto.Cellphone;
using Infrastructure.Model.Cellphone;
using System;
namespace Domain.Repository
{
    public interface ICellphoneRepository
    {
        public Task CreateCellphone(CreateCellphoneDto cellphoneDto);
        
        public Task<List<CelularModel>> GetCellphoneDetail(GetCellphoneDetailDTO getCellPhoneDto);

        public Task UpdateStockCellphone(UpdateStockDto updateStockDto);
    }
}
