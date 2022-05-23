using Domain.Repository;
using Infrastructure.Dto.Nit;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Nit
{
    public class NitRepository : INitRepository
    {
        private readonly ISqlDataAccess Db;

        public NitRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<List<NitModel>> GetNit(GetNitDto getNitDto) => Db.LoadData<NitModel, GetNitDto>(Procedures.GetNits, getNitDto);

        public Task InsertNit(CreateNitDto createNitDto) => Db.SaveData(Procedures.CreateNit, createNitDto);
    }
}
