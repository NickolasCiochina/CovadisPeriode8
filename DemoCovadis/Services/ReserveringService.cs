using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Services
{
    public class ReserveringService(LeenAutoDbContext dbContext)
    {
        private readonly LeenAutoDbContext dbContext = dbContext;


        public IEnumerable<ReserveringDto> GetReserverings()
        {
            return dbContext.Reservering.Select(x => new ReserveringDto
            {
                Id = x.Id,
                StartAdres = x.StartAdres,
                EindAdres = x.EindAdres,
                Datum = x.Datum,

            });
        }
        public ReserveringDto? GetReserveringById(int id)
        {
            var reservering = dbContext.Reservering.Find(id);

            if (reservering == null)
            {
                return null;
            }

            return new ReserveringDto
            {
                Id = reservering.Id,
                StartAdres = reservering.StartAdres,
                EindAdres = reservering.EindAdres,
                Datum = reservering.Datum,
               
            };
        }
        public ReserveringDto CreateReservering(Reservering reservering)
        {
            dbContext.Reservering.Add(reservering);
            dbContext.SaveChanges();

            return new ReserveringDto
            {
                Id = reservering.Id,
                StartAdres = reservering.StartAdres,
                EindAdres = reservering.EindAdres,
                Datum = reservering.Datum,
            };
        }
        public ReserveringDto? UpdateReservering(int id, Reservering reservering)
        {
            throw new NotImplementedException();
        }
    /*    public IEnumerable<Reservering> SearchReservering(string naam)
        {
            return dbContext.Chauffeurs
                    .Where(n => n.Naam
                    .ToLower()
                    .Contains(naam.ToLower()))
                .ToArray();
        }*/
        public void DeleteReservering(int id)
        {
            dbContext.Reservering.Where(x => x.Id == id).ExecuteDelete();
            dbContext.SaveChanges();

        }

    }
}
