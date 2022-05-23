using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Locality
{
    public class GetMuniDTO
    {
        public int IdDepartamento { get; set; }

        public GetMuniDTO(int idDepartamento)
        {
            IdDepartamento = idDepartamento;
        }

        public GetMuniDTO()
        {
        }
    }
}
