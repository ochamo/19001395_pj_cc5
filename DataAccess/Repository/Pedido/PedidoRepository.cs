using Domain.Repository;
using Infrastructure.Dto.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Pedido
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ISqlDataAccess Db;

        public PedidoRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<int> CreatePedido(CreatePedidoDto pedidoDto) => Db.SaveData(Procedures.CreatePedido, pedidoDto);
    }
}
