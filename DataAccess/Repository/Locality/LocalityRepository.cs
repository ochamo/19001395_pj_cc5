using Domain.Repository;
using Infrastructure.Dto.Locality;
using Infrastructure.Model.Locality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Locality
{
    public class LocalityRepository : ILocalityRepository
    {
        private readonly ISqlDataAccess Db;

        public LocalityRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<List<DepModel>> GetDepartments()
        {
            return Db.LoadData<DepModel, dynamic>(Procedures.GetDepartments, new { });
        }

        public Task<List<MuniModel>> GetMunis(GetMuniDTO getMuni)
        {
            return Db.LoadData<MuniModel, GetMuniDTO>(Procedures.GetMunis, getMuni);
        }
    }
}
