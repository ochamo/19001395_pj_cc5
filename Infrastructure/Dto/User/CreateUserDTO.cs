using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.User
{
    public class CreateUserDTO
    {
        public int Rol { get; set; }

        public string Corr { get; set; }

        public string Noms { get; set; }

        public string Apells { get; set; }

        public DateTime FechaNaci { get; set; }

        public string Dni { get; set; }

        public string Passs { get; set; }

        public CreateUserDTO(int rol, string corr, string noms, string apells, DateTime fechaNaci, string dni, string passs)
        {
            Rol = rol;
            Corr = corr;
            Noms = noms;
            Apells = apells;
            FechaNaci = fechaNaci;
            Dni = dni;
            Passs = passs;
        }
    }
}
