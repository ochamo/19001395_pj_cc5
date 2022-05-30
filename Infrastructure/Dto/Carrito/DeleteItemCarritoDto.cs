using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Carrito
{
    public class DeleteItemCarritoDto
    {
        public int IdCel { get; set; }
        public int UsuarioId { get; set; }

        public DeleteItemCarritoDto(int idCel, int usuarioId)
        {
            IdCel = idCel;
            UsuarioId = usuarioId;
        }

        public DeleteItemCarritoDto()
        {
        }
    }
}
