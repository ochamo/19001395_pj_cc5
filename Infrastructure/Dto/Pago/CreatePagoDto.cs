using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Pago
{
    public class CreatePagoDto
    {
        public string NumTarj { get; set; }

        public decimal Tot { get; set; }

        public CreatePagoDto(string numTarjeta, decimal total)
        {
            NumTarj = numTarjeta;
            Tot = total;
        }

        public CreatePagoDto()
        {
        }
    }
}
