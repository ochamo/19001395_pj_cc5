using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Address
{
    public class CreateAddressDto
    {
        public int UsuarioId { get; set; }
        public int Muni { get; set; }

        public int Zon { get; set; }

        public string DirNom { get; set; }

        public string Ave { get; set; }

        public string Cal { get; set; }

        public CreateAddressDto(int usuarioId, int muni, int zon, string dirNom, string ave, string cal)
        {
            UsuarioId = usuarioId;
            Muni = muni;
            Zon = zon;
            DirNom = dirNom;
            Ave = ave;
            Cal = cal;
        }

        public CreateAddressDto()
        {
        }
    }
}
