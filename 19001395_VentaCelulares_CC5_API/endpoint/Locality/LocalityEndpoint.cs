using Domain.UseCase.Locality;
using Infrastructure;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.Locality
{
    public static class LocalityEndpoint
    {
        public static void ConfigureLocalityEndpoint(this WebApplication app)
        {
            app.MapGet("/Locality", GetLocalities);
        }

        private static async Task<IResult> GetLocalities(GetLocalitiesUseCase getLocalitiesUseCase)
        {
            var result = await getLocalitiesUseCase.Execute(new None());
            if (result.Success)
            {
                return Results.Ok(result.Value);
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

    }
}
