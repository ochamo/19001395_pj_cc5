using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Pago
{
    public class PagoModel
    {
        public int IdPago { get; set; }
        public string NumTarjeta { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Total { get; set; }

        public PagoModel(int idPago, string numTarjeta, decimal total, DateTime fechaPago)
        {
            IdPago = idPago;
            NumTarjeta = numTarjeta;
            FechaPago = fechaPago;
            Total = total;
        }

        public PagoModel()
        {
        }
    }
}
