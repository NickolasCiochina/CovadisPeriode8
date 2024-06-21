using DemoCovadis.Context;
using DemoCovadis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutoController : ControllerBase
    {
        private readonly LeenAutoDbContext leenautoDbContext;

        public AutoController(LeenAutoDbContext leenautoDbContext)
        {
            this.leenautoDbContext = leenautoDbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Auto> GetAutos()
        {
            return leenautoDbContext.Auto.ToArray();
        }

        [HttpGet("{id}")]

        public ActionResult<Auto> GetAuto(int id)
        {
            Auto auto = leenautoDbContext.Auto.Include(x => x.Chauffeur).SingleOrDefault(x => x.Id == id);

            return Ok(auto);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Auto> AddAuto(Auto auto)
        {
            leenautoDbContext.Auto.Add(auto);

            //savechanges
            leenautoDbContext.SaveChanges();

            return Ok(auto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuto(int id, Auto auto)
        {
            Auto oldAuto = leenautoDbContext.Auto.SingleOrDefault(x => x.Id == id);

            oldAuto.Merk = auto.Merk;
            oldAuto.Opmerkingen = auto.Opmerkingen;

            //oldAuto.Chauffeur = auto.Chauffeur; omdat virtual is
            oldAuto.KilometersStand = auto.KilometersStand;

            //savechanges
            leenautoDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuto(int id)
        {

            leenautoDbContext.Auto.Where(x => x.Id == id).ExecuteDelete();
            leenautoDbContext.SaveChanges();

            return NoContent();
        }

        [HttpGet("[action]/{merk}")]

        public IEnumerable<Auto> FindAuto(string merk)
        {
            return leenautoDbContext.Auto.Include(x => x.Chauffeur)
                .Where(n => n.Merk
                    .ToLower()
                    .Contains(merk.ToLower()))
                .ToArray();
        }
    }
}