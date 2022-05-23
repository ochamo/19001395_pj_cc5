using Business.UseCase;
using Domain.Repository;
using Infrastructure;
using Infrastructure.Dto.Address;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Domain.UseCase.Address
{
    public class GetAddressUseCase : BaseUseCase<GetAddressDto, Result<List<AddressModel>>>
    {
        private readonly IAddressRepository addressRepository;

        public GetAddressUseCase(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public override async Task<Result<List<AddressModel>>> Execute(GetAddressDto p)
        {
           try
            {
                var result = await addressRepository.GetAddresses(p);
                return Result.Ok(result);
            } catch(Exception ex)
            {
                return Result.Fail<List<AddressModel>>(new ErrorModel(ErrorCodes.CouldNotLoadAddresses));
            }
            
        }
    }
}
