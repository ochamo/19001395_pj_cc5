using Domain.Repository;
using Infrastructure.Dto.Carrito;
using Infrastructure.Model.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Carrito
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly ISqlDataAccess Db;

        public CarritoRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task DeleteItemCarritoDto(DeleteItemCarritoDto deleteItemCarritoDto) => Db.DeleteSingle(Procedures.DeleteItemCarrito, deleteItemCarritoDto);

        public Task<List<GetCarritoModel>> GetCarrito(GetCarritoDto getCarritoDto) => Db.LoadData<GetCarritoModel, GetCarritoDto>(Procedures.GetCarrito, getCarritoDto);

        public Task InsertItemCarrito(InsertCarritoItemDto insertCarritoItemDto) => Db.SaveData(Procedures.InsertCarritoUsuario, insertCarritoItemDto);

        public Task DeleteCarrito(DeleteCarritoUsuarioDto deleteCarritoUsuario) => Db.DeleteSingle(Procedures.DeleteCarritoUsuario, deleteCarritoUsuario);

    }
}
