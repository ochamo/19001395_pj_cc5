using Infrastructure.Dto.Nit;
using Infrastructure.Model.Nit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface INitRepository
    {
        public Task<List<NitModel>> GetNit(GetNitDto getNitDto);

        public Task InsertNit(CreateNitDto createNitDto);
    }
}
