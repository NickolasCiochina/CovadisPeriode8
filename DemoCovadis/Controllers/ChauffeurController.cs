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
        public IActionResult GetChauffeur(int id)
        {
            var chauffeur = chauffeurService.GetChauffeurById(id);
            if (chauffeur == null)
            {
                return NotFound();
            }
            return Ok(chauffeur);
        }

        [HttpGet("[action]/{achternaam}")]
        public IActionResult SearchChauffeur(string achternaam)
        {
            var chauffeurName = chauffeurService.SearchChauffeur(achternaam);
            return Ok(chauffeurName);
        }

        [HttpPost]
        public IActionResult CreateChauffeur([FromBody] Chauffeur chauffeur)
        {
            var createdChauffeur = chauffeurService.CreateChauffeur(chauffeur);
            return Ok(createdChauffeur);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChauffeur(int id, [FromBody] Chauffeur chauffeur)
        {
            var updatedChauffeur = chauffeurService.UpdateChauffeur(id, chauffeur);
            return Ok(updatedChauffeur);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChauffeur(int id)
        {
            chauffeurService.DeleteChauffeur(id);
            return NoContent();
        }
    }


}
