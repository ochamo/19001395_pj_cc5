using Infrastructure.Dto.Locality;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ILocalityRepository
    {
        public Task<List<DepModel>> GetDepartments();
        public Task<List<MuniModel>> GetMunis(GetMuniDTO getMuni);
    }
}
