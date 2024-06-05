using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Services
{
    public class ChauffeurService(LeenAutoDbContext dbContext)
    {
        private readonly LeenAutoDbContext dbContext = dbContext;


        public IEnumerable<ChauffeurDto> GetChauffeurs()
        {
            return dbContext.Chauffeur.Select(x => new ChauffeurDto
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
            var chauffeur = dbContext.Chauffeur.Find(id);

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
            dbContext.Chauffeur.Add(chauffeur);
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
            return dbContext.Chauffeur
                    .Where(n => n.Naam
                    .ToLower()
                    .Contains(naam.ToLower()))
                .ToArray();
        }
        public void DeleteChauffeur(int id)
        {
            dbContext.Chauffeur.Where(x => x.Id == id).ExecuteDelete();
            dbContext.SaveChanges();

        }

    }
}
