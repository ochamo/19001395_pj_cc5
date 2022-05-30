using Domain.Repository;
using Infrastructure.Dto.Address;
using Infrastructure.Model.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.User
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ISqlDataAccess Db;

        public AddressRepository(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<AddressModel> GetAddress(GetSingleAddressDto getAddressDto) => Db.Single<AddressModel, GetSingleAddressDto>(Procedures.GetDireccion, getAddressDto);

        public Task<List<AddressModel>> GetAddresses(GetAddressDto getAddressDto) => Db.LoadData<AddressModel, GetAddressDto>(Procedures.GetDireccions, getAddressDto);

        public Task InsertAddress(CreateAddressDto addressDto) => Db.SaveData(Procedures.CreateDireccion, addressDto);
    }
}
