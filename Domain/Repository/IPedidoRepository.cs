using Infrastructure.Dto.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IPedidoRepository
    {
        public Task<int> CreatePedido(CreatePedidoDto pedidoDto);
    }
}
