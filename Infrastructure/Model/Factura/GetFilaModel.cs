using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Factura
{
    public class GetFilaModel
    {
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public string NumSerie { get; set; }
        public string Model { get; set; }

    }
}
