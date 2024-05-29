﻿
using DemoCovadis.Context;
using DemoCovadis.Shared;
using DemoCovadis.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Services
{
    public class UserService
    {
        private readonly LeenautoDbContext dbContext;

        public UserService(LeenautoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      
        public IEnumerable<UserDto> GetUsers()
        {
            return dbContext.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });
        }

        public UserDto? GetUserById(int id)
        {
            var user = dbContext.Users.Find(id);

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
            dbContext.Users.Add(user);
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
    }
}
