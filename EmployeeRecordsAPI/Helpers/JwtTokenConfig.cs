using EmployeeRecordsAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeRecordsAPI.Helpers
{
    public static class JwtTokenConfig
    {
        public static string GetToken(User user, IConfiguration configuration)
        {
            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            //obtain JWT secret key to encrypt token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            //generate signin credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //create security token descriptor(builds the token)
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //how many days before token expires
                SigningCredentials = creds
            };

            //build token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            //create token
            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
