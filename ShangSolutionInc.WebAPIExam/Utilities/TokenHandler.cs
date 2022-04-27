using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace ShangSolutionInc.WebAPIExam.Utilities
{
    public class TokenHandler
    {
        private string _token = string.Empty;
        public TokenHandler(string token)
        {
            _token = token;
        }

        public bool validate()
        {
            try
            {
                String token = _token.Replace("Bearer ", string.Empty);
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
                var jti = jwtSecurityToken.Claims.First(claim => claim.Type == "Identifier").Value;
                if (jti == "SSI")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}