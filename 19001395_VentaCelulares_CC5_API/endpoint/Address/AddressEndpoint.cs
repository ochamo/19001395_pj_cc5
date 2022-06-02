using _19001395_VentaCelulares_CC5_API.Util;
using Domain.UseCase.Address;
using Infrastructure.Dto.Address;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.Address
{
    public static class AddressEndpoint
    {
        public static void ConfigureAddressEndpoint(this WebApplication app)
        {
            app.MapGet("/GetAddresses", GetAddresses).RequireAuthorization(Policies.ClientPolicy);
            app.MapPost("/Address", CreateAddress).RequireAuthorization(Policies.ClientPolicy);
        }

        private static async Task<IResult> GetAddresses([FromHeader(Name = "Authorization")] string authorization, GetAddressUseCase getAddressesUseCase)
        {
            var token = TokenUtils.GetTokenClaims(authorization);
            var result = await getAddressesUseCase.Execute(new GetAddressDto(token.UserId));

            if (result.Success)
            {
                return Results.Ok(result.Value);
            }
            else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }

        }

        private static async Task<IResult> CreateAddress([FromHeader(Name = "Authorization")] string authorization, CreateAddressDto createAddressDto, CreateAddressUseCase createAddressUseCase)
        {
            var token = TokenUtils.GetTokenClaims(authorization);
            createAddressDto.UsuarioId = token.UserId;
            var result = await createAddressUseCase.Execute(createAddressDto);

            if (result.Success)
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

    }
}
