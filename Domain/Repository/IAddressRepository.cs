using Infrastructure.Dto;
using Infrastructure.Model;

namespace Domain.Repository
{
    public interface IAddressRepository
    {
        public Task<List<AddressModel>> GetAddresses(GetAddressDto getAddressDto);

        public Task InsertAddress(CreateAddressDto addressDto); 

    }
}
