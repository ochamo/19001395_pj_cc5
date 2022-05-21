using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class CreateCarritoUsuario
    {
        public int IdCelu { get; set; }
        public int Cant { get; set; }
        public int UsuarioId { get; set; }

        public CreateCarritoUsuario(int idCelu, int cant, int usuarioId)
        {
            IdCelu = idCelu;
            Cant = cant;
            UsuarioId = usuarioId;
        }

        public CreateCarritoUsuario()
        {
        }
    }
}
