using DemoCovadis.Services;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var createdUser = userService.CreateUser(user);

            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            return Ok();
        }
    }
}


public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Id { get; internal set; }
}

