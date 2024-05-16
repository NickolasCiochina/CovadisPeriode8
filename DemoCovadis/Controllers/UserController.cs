using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly LeenautoDbContext leenautoDbContext;

        public UserController(LeenautoDbContext leenautoDbContext)
        {
            this.leenautoDbContext = leenautoDbContext;
        }

        public static List<User> Users = new List<User>
        {
           new User
           {
               Name = "Test",
               Email = "Mail",
               Password = "Secret password"
           }
        };


        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

            new User();
        }

        [HttpGet(Name = "Users")]
        public IActionResult Get()
        {
            var userDtos = Users.Select(user => new UserDto
            {
                Password = user.Password,
                Email = user.Email
            });
               
            
            return Ok(userDtos);
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            Users.Add(user);
           return Ok();
        }
    }
}

