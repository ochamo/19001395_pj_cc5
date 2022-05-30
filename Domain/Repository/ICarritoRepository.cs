using Infrastructure.Dto.Carrito;
using Infrastructure.Model.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICarritoRepository
    {
        public Task InsertItemCarrito(InsertCarritoItemDto insertCarritoItemDto);

        public Task DeleteItemCarritoDto(DeleteItemCarritoDto deleteItemCarritoDto);

        public Task<List<GetCarritoModel>> GetCarrito(GetCarritoDto getCarritoDto);

        public Task DeleteCarrito(DeleteCarritoUsuarioDto deleteCarritoUsuarioDto);


    }
}
