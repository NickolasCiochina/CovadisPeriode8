using DemoCovadis.Models;
using DemoCovadis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCovadis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveringController : ControllerBase
    {
        private readonly ReserveringService reserveringService;

        public ReserveringController(ReserveringService reserveringService)
        {
            this.reserveringService = reserveringService;
        }

        [HttpGet]
        public IActionResult GetReserveringen()
        {
            var reserveringen = reserveringService.GetReserverings();
            return Ok(reserveringen);
        }

        [HttpGet("{id}")]
        public IActionResult GetReserveringById(int id)
        {
            return Ok();
        }

        /*[HttpGet("[action]/{naam}")]
        public IActionResult SearchReservering(string naam)
        {
            var ReserveringName = reserveringService.SearchReservering(naam);
            return Ok(ReserveringName);
        }*/

        [HttpPost]
        public IActionResult CreateReservering([FromBody] Reservering reservering)
        {
            var createdReservering = reserveringService.CreateReservering(reservering);

            return Ok(createdReservering);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservering(int id, [FromBody] Reservering reservering)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteReservering(int id)
        {
            reserveringService.DeleteReservering(id);
        }


    }
}
