using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Factura
{
    public class CreateFacturaDTO
    {
        public int UsuarioId { get; set; }
        public int PagoId { get; set; }
        public int PedidoId { get; set; }
        public string NitN { get; set; }
        public string NombreCli { get; set; }

        public CreateFacturaDTO(int usuarioId, int pagoId, int pedidoId, string nitN, string nombreCli)
        {
            UsuarioId = usuarioId;
            PagoId = pagoId;
            PedidoId = pedidoId;
            NitN = nitN;
            NombreCli = nombreCli;
        }

        public CreateFacturaDTO()
        {
        }
    }
}
