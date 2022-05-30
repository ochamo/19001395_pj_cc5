using Business.UseCase;
using Domain.UseCase.User;
using Infrastructure.Dto.User;
using Infrastructure.Model;
using Infrastructure.Model.User;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.Endpoint.User
{
    public static class UserEndpoint
    {

        public static void ConfigureUserEndpoint(this WebApplication app)
        {
            app.MapPost("/CreateAccount", CreateAccount);
            app.MapPost("/Login", Login);
            app.MapPut("/Password", UpdatePassword);
        }

        private static async Task<IResult> CreateAccount(CreateUserDTO p, CreateUserUseCase createUserUseCase)
        {
            var result = await createUserUseCase.Execute(p);
            if (result.Success)
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

        private static async Task<IResult> UpdatePassword(UpdatePasswordDTO p, UpdatePasswordUseCase updatePasswordUseCase)
        {
            var result = await updatePasswordUseCase.Execute(p);
            if (result.Success)
            {
                return Results.Ok();
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

        private static async Task<IResult> Login(LoginDTO p, LoginUseCase loginUseCase, IConfiguration configuration)
        {
            var result = await loginUseCase.Execute(p);

            if (result.Success)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Value.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Email, result.Value.Correo),
                    new Claim(ClaimTypes.Role, result.Value.IdRol.ToString())
                };
                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(3),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        SecurityAlgorithms.HmacSha256
                    )
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Results.Ok(new AuthModel() { Jwt = tokenString, Xyz = result.Value.IdUsuario, Yyz = result.Value.IdRol });
            }
            else
            {
                return Results.Json(result.Error, statusCode: 404);
            }

        }
        
    }
}
