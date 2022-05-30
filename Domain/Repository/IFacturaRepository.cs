using Infrastructure.Dto.Factura;
using Infrastructure.Model.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IFacturaRepository
    {
        public Task<int> CreateFactura(CreateFacturaDTO createFacturaDTO);

        public Task CreateFilasFactura(CreateFacturaFilaDto createFacturaFilaDto);

        public Task<List<GetFilaModel>> GetFilasFactura(GetFilaFacturaDto getFilaFacturaDto);

    }
}
