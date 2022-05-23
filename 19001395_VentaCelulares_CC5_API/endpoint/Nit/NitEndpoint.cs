using _19001395_VentaCelulares_CC5_API.Util;
using Domain.UseCase.Nit;
using Infrastructure.Dto;
using Infrastructure.Dto.Nit;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.Nit
{
    public static class NitEndpoint
    {
        public static void ConfigureNitEndpoint(this WebApplication app)
        {
            app.MapGet("/Nit", GetNits).RequireAuthorization(Policies.ClientPolicy);
            app.MapPost("/Nit", CreateNit).RequireAuthorization(Policies.ClientPolicy);
        }

        private static async Task<IResult> GetNits([FromHeader(Name = "Authorization")] string authorization, GetNitsUseCase getNitsUseCase)
        {
            var token = TokenUtils.GetTokenClaims(authorization);
            var result = await getNitsUseCase.Execute(new GetNitDto(token.UserId));
            if (result.Success)
            {
                return Results.Ok(result.Value);
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

        private static async Task<IResult> CreateNit([FromHeader(Name = "Authorization")] string authorization, CreateNitDto createNitDto, CreateNitUseCase createNitUseCase)
        {
            var token = TokenUtils.GetTokenClaims(authorization);
            createNitDto.UsuarioId = token.UserId;
            var result = await createNitUseCase.Execute(createNitDto);
            if (result.Success)
            {
                return Results.Ok();
            } else {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

    }
}
