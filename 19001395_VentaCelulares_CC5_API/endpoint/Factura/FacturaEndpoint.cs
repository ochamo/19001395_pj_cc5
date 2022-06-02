using _19001395_VentaCelulares_CC5_API.Util;
using Domain.UseCase.Factura;
using Infrastructure.Dto.Factura;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.Factura
{
    public static class FacturaEndpoint
    {

        public static void ConfigureFacturaEndpoint(this WebApplication app)
        {
            app.MapPost("/Compra", CreateCompra).RequireAuthorization(Policies.ClientPolicy);
        }

        private static async Task<IResult> CreateCompra([FromHeader(Name = "Authorization")] string authorization, FacturaDTO p, CreateFacturaUseCase createFacturaUseCase)
        {
            var token = TokenUtils.GetTokenClaims(authorization);
            p.Email = token.Email;
            p.UsuarioId = token.UserId;
            var result = await createFacturaUseCase.Execute(p);

            if (result.Success)
            {
                return Results.Ok();
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result));
            }


        }

    }
}
