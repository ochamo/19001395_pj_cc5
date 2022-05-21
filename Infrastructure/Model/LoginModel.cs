using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class LoginModel
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Correo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Dpi { get; set; }
        public string Pass { get; set; }

        public LoginModel(int idUsuario, int idRol, string correo, string nombres, string apellidos, DateTime fechaNacimiento, DateTime fechaCreacion, string dpi, string pass)
        {
            IdUsuario = idUsuario;
            IdRol = idRol;
            Correo = correo;
            Nombres = nombres;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            FechaCreacion = fechaCreacion;
            Dpi = dpi;
            Pass = pass;
        }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public LoginModel()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
        }
    }
}
