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
        public Task<IEnumerable<DepModel>> GetLocalities();
    }
}
