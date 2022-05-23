using Infrastructure.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _19001395_VentaCelulares_CC5_API.Util
{
    public static class TokenUtils
    {
        public static TokenModel GetTokenClaims(string authorization)
        {
            var token = authorization.Replace("Bearer ", "");
            var jwtHandler = new JwtSecurityTokenHandler();
            var jsonToken = jwtHandler.ReadToken(token) as JwtSecurityToken;
            var id = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            var email = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var rol = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
            return new TokenModel(userId: int.Parse(id), role: rol, email: email);
        }
    }
}
