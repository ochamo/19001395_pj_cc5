using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Address
{
    public class AddressModel
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }

        public int IdMunicipio { get; set; } 

        public string NombreDir { get; set; }

        public string NombreMuni { get; set; }

        public string NombreDep { get; set; }

        public int Zona { get; set; }

        public string Avenida { get; set; }
        public string Calle { get; set; }

        public AddressModel(int idDireccion, int idUsuario, int idMunicipio, string nombreDir, string nombreMuni, string nombreDep, int zona, string avenida, string calle)
        {
            IdDireccion = idDireccion;
            IdUsuario = idUsuario;
            IdMunicipio = idMunicipio;
            NombreDir = nombreDir;
            NombreMuni = nombreMuni;
            NombreDep = nombreDep;
            Zona = zona;
            Avenida = avenida;
            Calle = calle;
        }

        public AddressModel()
        {
        }
    }
}
