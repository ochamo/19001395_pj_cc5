using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Address
{
    public class GetSingleAddressDto
    {
        public int DireccionId { get; set; }

        public GetSingleAddressDto(int direccionId)
        {
            DireccionId = direccionId;
        }

        public GetSingleAddressDto()
        {
        }
    }
}
