using DemoCovadis.Context;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Identity.Data;

namespace DemoCovadis.Services
{
    public class AuthService(LeenautoDbContext dbContext, TokenService tokenService)
    {
        public AuthResponse? Login(Shared.LoginRequest request)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user == null || user.Password != request.Password)
            {
                return null;
            }

            return new AuthResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = tokenService.CreateToken(user),
            };
        }
    }
}
