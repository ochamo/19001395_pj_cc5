using Domain.Repository;
using Infrastructure.Dto.Factura;
using Infrastructure.Model.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Factura
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ISqlDataAccess Db;

        public FacturaRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<int> CreateFactura(CreateFacturaDTO createFacturaDTO) => Db.SaveData(Procedures.CreateFactura, createFacturaDTO);
        public Task CreateFilasFactura(CreateFacturaFilaDto createFacturaFilaDto) => Db.SaveData(Procedures.CreateFilasFactura, createFacturaFilaDto);
        public Task<List<GetFilaModel>> GetFilasFactura(GetFilaFacturaDto getFilaFacturaDto) =>
            Db.LoadData<GetFilaModel, GetFilaFacturaDto>(Procedures.GetFilasFactura, getFilaFacturaDto);
    }
}
