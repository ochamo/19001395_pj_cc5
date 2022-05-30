using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Carrito
{
    public class DeleteCarritoUsuarioDto
    {
        public int UsuarioId { get; set; }

        public DeleteCarritoUsuarioDto(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public DeleteCarritoUsuarioDto()
        {
        }
    }
}
