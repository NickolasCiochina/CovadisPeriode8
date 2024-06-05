using DemoCovadis.Context;
using DemoCovadis.Shared.Responses;
using DemoCovadis.Shared.Requests;
using Microsoft.AspNetCore.Identity.Data;

namespace DemoCovadis.Services
{
    public class AuthService(LeenAutoDbContext dbContext, TokenService tokenService)
    {
        public AuthResponse? Login(Shared.Requests.LoginRequest request)
        {
            var user = dbContext.User.FirstOrDefault(u => u.Email == request.Email);

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
