using Domain.Repository;
using Infrastructure.Dto.Cellphone;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Cellphone
{
    public class CellPhonRepository : ICellphoneRepository
    {
        private readonly ISqlDataAccess Db;

        public CellPhonRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task CreateCellphone(CreateCellphoneDto cellphoneDto) => Db.SaveData(Procedures.CreateCellphone, cellphoneDto);

        public Task GetCellphoneDetail(GetCellphoneDetailDTO getCellPhoneDto) => Db
            .Single<CelularModel, GetCellphoneDetailDTO>(Procedures.GetCellPhoneDetail, getCellPhoneDto);
    }
}
