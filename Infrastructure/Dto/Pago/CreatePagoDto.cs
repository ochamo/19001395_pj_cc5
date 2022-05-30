using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Pago
{
    public class CreatePagoDto
    {
        public string NumTarjeta { get; set; }

        public decimal Total { get; set; }

        public CreatePagoDto(string numTarjeta, decimal total)
        {
            NumTarjeta = numTarjeta;
            Total = total;
        }

        public CreatePagoDto()
        {
        }
    }
}
