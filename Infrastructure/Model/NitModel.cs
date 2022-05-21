using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class NitModel
    {
        public int IdNit { get; set; }
        public int IdUsuario { get; set; }
        public string NombreNit { get; set; }
        public string Nit { get; set; }

        public NitModel(int idNit, int idUsuario, string nombreNit, string nit)
        {
            IdNit = idNit;
            IdUsuario = idUsuario;
            NombreNit = nombreNit;
            Nit = nit;
        }

        public NitModel()
        {
        }
    }
}
