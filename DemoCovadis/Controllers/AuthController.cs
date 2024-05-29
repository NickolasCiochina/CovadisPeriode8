
using DemoCovadis.Services;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{

    [AllowAnonymous]
    [Controller]
    [Route("[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = authService.Login(request);

            if (response == null)
            {
                return Unauthorized();
            }

            return Ok(response);
        }
    }
}
