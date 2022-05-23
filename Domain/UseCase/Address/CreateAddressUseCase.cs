using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Address;
using Infrastructure.Model;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Address
{
    public class CreateAddressUseCase : BaseUseCase<CreateAddressDto, Result>
    {
        private readonly IAddressRepository AddressRepository;

        public CreateAddressUseCase(IAddressRepository addressRepository)
        {
            this.AddressRepository = addressRepository;
        }

        public override async Task<Result> Execute(CreateAddressDto p)
        {
            try
            {
                await AddressRepository.InsertAddress(p);
                return Result.Ok();
            } catch(Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.GeneralError));

            }
        }
    }
}
