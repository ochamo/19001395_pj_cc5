using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class MuniModel
    {
        public int IdMuni { get; set; }
        public string NombreMuni { get; set; }

        public MuniModel(int idMuni, string nombreMuni)
        {
            IdMuni = idMuni;
            NombreMuni = nombreMuni;
        }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public MuniModel()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
        }
    }
}
