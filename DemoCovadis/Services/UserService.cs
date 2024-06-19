
using DemoCovadis.Context;
using DemoCovadis.Models;
using Microsoft.EntityFrameworkCore;
using DemoCovadis.Shared.Dtos;
using DemoCovadis.Shared.Requests;
using DemoCovadis.Shared.Responses;

namespace DemoCovadis.Services
{
    public class UserService
    {
        private readonly LeenAutoDbContext dbContext;

        public UserService(LeenAutoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      
        public IEnumerable<UserDto> GetUsers()
        {
            return dbContext.User.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });
        }

        public UserDto? GetUserById(int id)
        {
            var user = dbContext.User.Find(id);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserDto CreateUser(User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserDto? UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservering(int id)
        {
            dbContext.User.Where(x => x.Id == id).ExecuteDelete();
            dbContext.SaveChanges();

        }

        public AssignRoleResponse? AssignRole(AssignRoleRequest request)
        {
            var user = dbContext.User
                .Include(x => x.Roles)
                .FirstOrDefault(x => x.Id == request.UserId);
            var role = dbContext.Role.Find(request.RoleId);

            if (user == null || role == null)
            {
                return null;
            }

            if (user.Roles.Contains(role))
            {
                throw new ArgumentException("User already assigned to role");
            }

            user.Roles.Add(role);
            dbContext.SaveChanges();

            return new AssignRoleResponse
            {
                UserName = user.Name,
                RoleName = role.Name,
            };
        }
    }
}
