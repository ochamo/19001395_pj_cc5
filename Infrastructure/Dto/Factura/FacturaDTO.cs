using Infrastructure.Dto.Pago;
using Infrastructure.Dto.Pedido;
using Infrastructure.Model.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Factura
{
    public class FacturaDTO
    {
        public CreatePagoDto PagoInfo { get; set; }

        public CreatePedidoDto PedidoInfo { get; set; }

        public string NitN { get; set; }

        public string NombreCli { get; set; }

        public int UsuarioId { get; set; }

        public string Email { get; set; }

        public int ItemToPurchase { get; set; }

        public FacturaDTO(CreatePagoDto pagoInfo, CreatePedidoDto pedidoInfo, string nitN, string nombreCli, int usuarioId, string email, int itemToPurchase)
        {
            PagoInfo = pagoInfo;
            PedidoInfo = pedidoInfo;
            NitN = nitN;
            NombreCli = nombreCli;
            UsuarioId = usuarioId;
            Email = email;
            ItemToPurchase = itemToPurchase;
        }

        public FacturaDTO()
        {
        }
    }
}
