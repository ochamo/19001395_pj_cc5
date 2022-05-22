using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.User
{
    public class CreateCarritoUsuarioDTO
    {
        public int IdCelu { get; set; }
        public int Cant { get; set; }
        public int UsuarioId { get; set; }

        public CreateCarritoUsuarioDTO(int idCelu, int cant, int usuarioId)
        {
            IdCelu = idCelu;
            Cant = cant;
            UsuarioId = usuarioId;
        }

        public CreateCarritoUsuarioDTO()
        {
        }
    }
}
