using Infrastructure.Dto;
using Infrastructure.Model;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace _19001395_VentaCelulares_CC5_API.endpoint.User
{
    public static class UserEndpoint
    {

        public static void ConfigureUserEndpoint(this WebApplication app)
        {
            app.MapPost("/CreateAccount", CreateAccount);
            app.MapPost("/Login", Login);
        }

        private static async Task<IResult> CreateAccount(CreateUserDto p, CreateUserUseCase createUserUseCase)
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

        private static async Task<IResult> Login(LoginDTO p, LoginUseCase loginUseCase, IConfiguration configuration)
        {
            var result = await loginUseCase.Execute(p);

            if (result.Success)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Value.UserId.ToString()),
                    new Claim(ClaimTypes.Email, result.Value.UserName),
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
                return Results.Ok(new AuthModel() { Jwt = tokenString, Xyz = result.Value.UserId });
            }
            else
            {
                return Results.Json(result.Error, statusCode: 404);
            }

        }

    }
}
