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
                Voornaam = x.Voornaam,
                Achternaam = x.Achternaam,
                TelefoonNummer = x.TelefoonNummer,
                Email = x.Email,
               
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
                Voornaam = chauffeur.Voornaam,
                Achternaam = chauffeur.Achternaam,
                TelefoonNummer = chauffeur.TelefoonNummer, 
                Email = chauffeur.Email,
            };
        }
        public ChauffeurDto CreateChauffeur(Chauffeur chauffeur)
        {
            dbContext.Chauffeur.Add(chauffeur);
            dbContext.SaveChanges();

            return new ChauffeurDto
            {
                Id = chauffeur.Id,
                Voornaam = chauffeur.Voornaam,
                Achternaam = chauffeur.Achternaam,
                TelefoonNummer = chauffeur.TelefoonNummer,
                Email = chauffeur.Email,
            };
        }
        public ChauffeurDto? UpdateChauffeur(int id, Chauffeur chauffeur)
        {
            var existingChauffeur = dbContext.Chauffeur.Find(id);
            if (existingChauffeur == null) return null;

            existingChauffeur.Voornaam = chauffeur.Voornaam;
            existingChauffeur.Achternaam = chauffeur.Achternaam;
            existingChauffeur.TelefoonNummer = chauffeur.TelefoonNummer;
            existingChauffeur.Email = chauffeur.Email;

            dbContext.SaveChanges();

            return new ChauffeurDto
            {
                Id = existingChauffeur.Id,
                Voornaam = existingChauffeur.Voornaam,
                Achternaam = existingChauffeur.Achternaam,
                TelefoonNummer = existingChauffeur.TelefoonNummer,
                Email = existingChauffeur.Email
            };
        }

        public IEnumerable<Chauffeur> SearchChauffeur(string naam)
        {
            return dbContext.Chauffeur
                    .Where(n => n.Achternaam
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
