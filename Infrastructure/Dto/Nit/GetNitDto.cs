using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Nit
{
    public class GetNitDto
    {
        public int UsuarioId { get; set; }

        public GetNitDto(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public GetNitDto()
        {
        }
    }
}
