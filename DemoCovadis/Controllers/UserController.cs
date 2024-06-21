using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Services;
using DemoCovadis.Shared.Requests;
using DemoCovadis.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
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

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
            {
            var createdUser = userService.CreateUser(user);
            
            return Ok(createdUser);
        }

        [Authorize(Roles = nameof(UserRole.User))]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpDelete("{id}")]
        public void DeleteReservering(int id)
        {
            userService.DeleteUser(id);
        }

        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.User))]
        [HttpPatch("assign-role")]
        public IActionResult AssignRole(AssignRoleRequest request)
        {
            var result = userService.AssignRole(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}




