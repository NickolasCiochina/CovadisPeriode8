﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoCovadis.Services
{
    public class TokenService(IConfiguration configuration)
    {
        private readonly SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

        public string CreateToken(User user)
        {

            var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("name", user.Name),
            new Claim(nameof(User.Email).ToLower(), user.Email),
        };

            var singingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: singingCredentials,
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"]
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
