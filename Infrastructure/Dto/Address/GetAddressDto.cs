using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Address
{
    public class GetAddressDto
    {
        public int UserId { get; set; }

        public GetAddressDto(int userId)
        {
            UserId = userId;
        }

        public GetAddressDto()
        {
        }
    }
}
