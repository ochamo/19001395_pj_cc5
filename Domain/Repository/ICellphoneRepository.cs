using Infrastructure.Dto.Cellphone;
using System;
namespace Domain.Repository
{
    public interface ICellphoneRepository
    {
        public Task CreateCellphone(CreateCellphoneDto cellphoneDto);
        // TODO
        public Task GetCellphoneDetail(GetCellphoneDetailDTO getCellPhoneDto);
    }
}
