using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class CreateUserDto
    {
        public int Rol { get; set; }

        public string Corr { get; set; }

        public string Nombs { get; set; }

        public DateTime FechaNaci { get; set; }

        public string Dni { get; set; }

        public string Passs { get; set; }

        public CreateUserDto(int rol, string corr, string nombs, DateTime fechaNaci, string dni, string passs)
        {
            Rol = rol;
            Corr = corr;
            Nombs = nombs;
            FechaNaci = fechaNaci;
            Dni = dni;
            Passs = passs;
        }

    }
}
