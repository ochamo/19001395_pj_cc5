using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class GetPagoDto
    {
        public int PagoId;

        public GetPagoDto(int pagoId)
        {
            PagoId = pagoId;
        }
    }
}
