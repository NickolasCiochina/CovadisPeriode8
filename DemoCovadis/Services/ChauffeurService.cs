using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Services
{
    public class ChauffeurService(LeenautoDbContext dbContext)
    {
        private readonly LeenautoDbContext dbContext = dbContext;


        public IEnumerable<ChauffeurDto> GetChauffeurs()
        {
            return dbContext.Chauffeurs.Select(x => new ChauffeurDto
            {
                Id = x.Id,
                Naam = x.Naam,
                TelefoonNummer = x.TelefoonNummer,
                BeginAdres = x.BeginAdres,
                EindAdres = x.EindAdres,
               
            });
        }
        public ChauffeurDto? GetChauffeurById(int id)
        {
            var chauffeur = dbContext.Chauffeurs.Find(id);

            if (chauffeur == null)
            {
                return null;
            }

            return new ChauffeurDto
            {
                Id = chauffeur.Id,
                Naam = chauffeur.Naam,
                TelefoonNummer = chauffeur.TelefoonNummer,
                BeginAdres= chauffeur.BeginAdres,
                EindAdres= chauffeur.EindAdres,
            };
        }
        public ChauffeurDto CreateChauffeur(Chauffeur chauffeur)
        {
            dbContext.Chauffeurs.Add(chauffeur);
            dbContext.SaveChanges();

            return new ChauffeurDto
            {
                Id = chauffeur.Id,
                Naam = chauffeur.Naam,
                TelefoonNummer = chauffeur.TelefoonNummer,
                BeginAdres = chauffeur.BeginAdres,
                EindAdres = chauffeur.EindAdres,
            };
        }
        public ChauffeurDto? UpdateChauffeur (int id, Chauffeur chauffeur)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Chauffeur> SearchChauffeur(string naam)
        {
            return dbContext.Chauffeurs
                    .Where(n => n.Naam
                    .ToLower()
                    .Contains(naam.ToLower()))
                .ToArray();
        }
        public void DeleteChauffeur(int id)
        {
            dbContext.Chauffeurs.Where(x => x.Id == id).ExecuteDelete();
            dbContext.SaveChanges();

        }

    }
}
