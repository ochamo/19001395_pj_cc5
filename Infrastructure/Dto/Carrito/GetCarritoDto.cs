using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Carrito
{
    public class GetCarritoDto
    {
        public int UsuarioId { get; set; }

        public GetCarritoDto(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public GetCarritoDto()
        {
        }
    }
}
