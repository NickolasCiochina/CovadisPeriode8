using DemoCovadis.Context;
using DemoCovadis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        private readonly LeenautoDbContext leenautoDbContext;

        public ChauffeurController(LeenautoDbContext leenautoDbContext)
        {
            this.leenautoDbContext = leenautoDbContext;
        }

        [HttpGet]
        public IEnumerable<Chauffeur> GetChauffeurs()
        {
            return leenautoDbContext.Chauffeurs.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Chauffeur> getChauffeur(int id)
        {
            Chauffeur chauffeur = leenautoDbContext.Chauffeurs.Include(x=> x.Naam).SingleOrDefault(x => x.Id == id);
            return Ok(chauffeur);
        }

        [HttpGet("[action]/{naam}")]
        public IEnumerable<Chauffeur> SearchChauffeur(string naam)
        {
            return leenautoDbContext.Chauffeurs
                .Include(x => x.Autos)
                .Where(n => n.Naam
                    .ToLower()
                    .Contains(naam.ToLower()))
                .ToArray();
        }

        [HttpPost]
        public ActionResult<Chauffeur> AddChauffeur(Chauffeur chauffeur)
        {
            leenautoDbContext.Chauffeurs.Add(chauffeur);
            leenautoDbContext.SaveChanges();
            return Ok(chauffeur);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateChauffeur(int id, Chauffeur chauffeur)
        {
            Chauffeur oldChauffeur =  leenautoDbContext.Chauffeurs.SingleOrDefault(x=> x.Id == id);

            oldChauffeur.Naam = chauffeur.Naam;
            oldChauffeur.TelefoonNummer = chauffeur.TelefoonNummer;

            leenautoDbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteChauffeur(int id) 
        { 
            leenautoDbContext.Chauffeurs.Where(x=> x.Id == id).ExecuteDelete();
            leenautoDbContext.SaveChanges();
            return Ok();
        }

    }

}
