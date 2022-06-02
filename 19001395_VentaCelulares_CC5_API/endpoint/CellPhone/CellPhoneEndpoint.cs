using _19001395_VentaCelulares_CC5_API.Util;
using Domain.UseCase.Cellphone;
using Infrastructure.Dto.Cellphone;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.CellPhone
{
    public static class CellPhoneEndpoint
    {
        public static void ConfigureCellPhoneEndpoint(this WebApplication app)
        {
            app.MapPost("/Cellphone", CreateCellPhone).RequireAuthorization(Policies.AdminPolicy);
            app.MapPut("/Stock", UpdateCellPhoneStock).RequireAuthorization(Policies.AdminPolicy);
            app.MapPut("/Cellphone", UpdateCellphone).RequireAuthorization(Policies.AdminPolicy);
            app.MapGet("/Cellphone/{cellphoneId}", GetDetalleTelefono).RequireAuthorization(Policies.AdminPolicy);
            app.MapGet("/Cellphone/", GetTelefonos).RequireAuthorization();
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

        private static async Task<IResult> UpdateCellPhoneStock(UpdateStockDto p, UpdateStockUseCase updateStockUseCase)
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


        private static async Task<IResult> UpdateCellphone(UpdateCellphoneDto p, UpdateCellphoneUseCase updateCellphoneUseCase)
        {
            var result = await updateCellphoneUseCase.Execute(p);

            if (result.Success)
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }

        }


        private static async Task<IResult> GetDetalleTelefono(int cellphoneId, [FromBody] GetCellphoneDetailDTO p, GetCellphoneUseCase getCellphoneUseCase)
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

        private static async Task<IResult> GetTelefonos(GetCellphonesUseCase getCellphonesUseCase)
        {
            var result = await getCellphonesUseCase.Execute(new Infrastructure.None());

            if (result.Success)
            {
                return Results.Ok(result.Value);
            }
            else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }


    }
}
