using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DemoCovadis.Services
{
    public class AutoService(LeenAutoDbContext leenautoDbContext)
    {
        private readonly LeenAutoDbContext leenautoDbContext = leenautoDbContext;

        public IEnumerable<AutoDto> GetAutos()
        {
            return leenautoDbContext.Autos.Select(x=> new AutoDto
            {
                Id = x.Id,
                Merk = x.Merk,
                KilometersStand = x.KilometersStand,
                Opmerkingen = x.Opmerkingen,

            });
        }

        public AutoDto? GetAutoById(int id)
        {
            var auto = leenautoDbContext.Autos.Find(id);

            if (auto == null)
            {
                return null;
            }

            return new AutoDto
            {
                Id = auto.Id,
                Merk = auto.Merk,
                KilometersStand = auto.KilometersStand,
                Opmerkingen = auto.Opmerkingen,

            };
        }

        public AutoDto CreateAuto(Auto auto)
        {
            leenautoDbContext.Autos.Add(auto);
            leenautoDbContext.SaveChanges();

            return new AutoDto
            {
                Id = auto.Id,
                Merk = auto.Merk,
                KilometersStand = auto.KilometersStand,
                Opmerkingen = auto.Opmerkingen,
         /*       Chauffeur = auto.Chauffeur*/
            };
        }

        public AutoDto? UpdateAuto(int id, Auto auto)
        {
            throw new NotImplementedException();
        }

    }
}
