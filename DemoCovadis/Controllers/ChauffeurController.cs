using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ChauffeurController : ControllerBase
    {
        private readonly ChauffeurService chauffeurService;

        public ChauffeurController(ChauffeurService chauffeurService)
        {
            this.chauffeurService = chauffeurService;
        }

        [HttpGet]
        public IActionResult GetChauffeurs()
        {
            var chauffeurs = chauffeurService.GetChauffeurs();
            return Ok(chauffeurs);
        }

        [HttpGet("{id}")]
        public IActionResult getChauffeur(int id)
        {
            return Ok();
        }

        [HttpGet("[action]/{naam}")]
        public IActionResult SearchChauffeur(string naam)
        {
            var chauffeurName = chauffeurService.SearchChauffeur(naam);
            return Ok(chauffeurName);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] Chauffeur chauffeur)
        {
            var createdChauffeur = chauffeurService.CreateChauffeur(chauffeur);

            return Ok(createdChauffeur);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChauffeur(int id, [FromBody] Chauffeur chauffeur)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteChauffeur(int id)
        {
            chauffeurService.DeleteChauffeur(id);
        }

    }

}
