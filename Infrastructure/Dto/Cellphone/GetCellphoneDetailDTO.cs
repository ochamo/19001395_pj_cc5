using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Cellphone
{
    public class GetCellphoneDetailDTO
    {
        public int IdCel { get; set; }

        public GetCellphoneDetailDTO(int idCel)
        {
            IdCel = idCel;
        }

        public GetCellphoneDetailDTO()
        {
        }
    }
}
