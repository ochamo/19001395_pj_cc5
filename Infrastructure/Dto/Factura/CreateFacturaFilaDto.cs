using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Factura
{
    public class CreateFacturaFilaDto
    {
        public int FacturaId { get; set; }
        public int CelularId { get; set; }
        public int Cant { get; set; }
        public decimal Prec { get; set; }

        public CreateFacturaFilaDto(int facturaId, int celularId, int cant, decimal prec)
        {
            FacturaId = facturaId;
            CelularId = celularId;
            Cant = cant;
            Prec = prec;
        }

        public CreateFacturaFilaDto()
        {
        }
    }
}
