using _19001395_VentaCelulares_CC5_API.Util;
using Domain.UseCase.Cellphone;
using Infrastructure.Dto.Cellphone;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.CellPhone
{
    public static class CellPhoneEndpoint
    {
        public static void ConfigureCellPhoneEndpoint(this WebApplication app)
        {
            app.MapPost("/Cellphone", CreateCellPhone).RequireAuthorization(Policies.AdminPolicy);
            app.MapPut("/Stock", UpdateCellPhone).RequireAuthorization(Policies.AdminPolicy);
            app.MapPut("/Stock", UpdateCellPhone).RequireAuthorization(Policies.AdminPolicy);
        }

        private static async Task<IResult> CreateCellPhone(CreateCellphoneDto p, CreateCellphoneUseCase createCellPhoneUseCase)
        {
            var result = await createCellPhoneUseCase.Execute(p);

            if (result.Success)
            {
                return Results.Ok();
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }

        }

        private static async Task<IResult> UpdateCellPhone(UpdateStockDto p, UpdateStockUseCase updateStockUseCase)
        {
            var result = await updateStockUseCase.Execute(p);

            if (result.Success)
            {
                return Results.Ok();
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }

        }

        private static async Task<IResult> GetDetalleTelefono(GetCellphoneDetailDTO p, GetCellphoneUseCase getCellphoneUseCase)
        {
            var result = await getCellphoneUseCase.Execute(p);

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
