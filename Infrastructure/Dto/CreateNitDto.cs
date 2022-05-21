using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class CreateNitDto
    {
        public int UsuarioId { get; set; }

        public string NitName { get; set; }

        public string NitN { get; set; }

        public CreateNitDto(int usuarioId, string nitName, string nitN)
        {
            UsuarioId = usuarioId;
            NitName = nitName;
            NitN = nitN;
        }

        public CreateNitDto()
        {
        }
    }
}
