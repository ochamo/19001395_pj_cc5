using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Carrito
{
    public class InsertCarritoItemDto
    {
        public int UsuarioId { get; set; }
        public int IdCelu { get; set; }
        public int Cant { get; set; }

        public InsertCarritoItemDto(int usuarioId, int idCelu, int cant)
        {
            UsuarioId = usuarioId;
            IdCelu = idCelu;
            Cant = cant;
        }

        public InsertCarritoItemDto()
        {
        }
    }
}
