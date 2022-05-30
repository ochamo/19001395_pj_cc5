using Domain.UseCase.Factura;
using Infrastructure.Dto.Factura;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.Factura
{
    public static class FacturaEndpoint
    {

        public static void ConfigureFacturaEndpoint(this WebApplication app)
        {
            app.MapPost("/Compra", CreateCompra);
        }

        private static async Task<IResult> CreateCompra(FacturaDTO p, CreateFacturaUseCase createFacturaUseCase)
        {
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
