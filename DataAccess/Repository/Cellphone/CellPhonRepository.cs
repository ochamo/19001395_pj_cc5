using Domain.Repository;
using Infrastructure.Dto.Cellphone;
using Infrastructure.Model.Cellphone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Cellphone
{
    public class CellphoneRepository : ICellphoneRepository
    {
        private readonly ISqlDataAccess Db;

        public CellphoneRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task CreateCellphone(CreateCellphoneDto cellphoneDto) => Db.SaveData(Procedures.CreateCellphone, cellphoneDto);

        public Task<CelularModel> GetCellphoneDetail(GetCellphoneDetailDTO getCellPhoneDto) => Db
            .Single<CelularModel, GetCellphoneDetailDTO>(Procedures.GetCellPhoneDetail, getCellPhoneDto);

        public Task<List<CelularModel>> GetCellphones() => Db.LoadData<CelularModel, dynamic>(Procedures.GetCellphones, new { });
        public Task UpdateStockCellphone(UpdateStockDto updateStockDto) => Db.SaveData(Procedures.UpdateStockCellphone, updateStockDto);
    }
}
