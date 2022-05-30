using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Pedido
{
    public class CreatePedidoDto
    {
        public int IdDirecc { get; set; }
        public int IdEstatu { get; set; }

        public CreatePedidoDto(int idDirecc, int idEstatu = 1)
        {
            IdDirecc = idDirecc;
            IdEstatu = idEstatu;
        }

        public CreatePedidoDto()
        {
        }
    }
}
