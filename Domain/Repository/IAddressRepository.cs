using Infrastructure.Dto.Address;
using Infrastructure.Model.Address;

namespace Domain.Repository
{
    public interface IAddressRepository
    {
        public Task<List<AddressModel>> GetAddresses(GetAddressDto getAddressDto);
        public Task<AddressModel> GetAddress(GetSingleAddressDto getAddressDto);

        public Task InsertAddress(CreateAddressDto addressDto); 

    }
}
