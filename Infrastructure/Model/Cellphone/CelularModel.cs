using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Cellphone
{
    public class CelularModel
    {
        public int IdCelular { get; set; }
        public int Cantidadd { get; set; }
        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public string Caracteristicas { get; set; }

        public string Model { get; set; }

        public decimal Precio { get; set; }
        public string NumSerie { get; set; }
        public string IsDisponible { get; set; }
    }
}
