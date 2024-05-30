using DemoCovadis.Context;
using DemoCovadis.Models;
using DemoCovadis.Shared;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Services
{
    public class ReserveringService(LeenAutoDbContext dbContext)
    {
        private readonly LeenAutoDbContext dbContext = dbContext;


        public IEnumerable<ReserveringDto> GetReserverings()
        {
            return dbContext.Reserveringen.Select(x => new ReserveringDto
            {
                Id = x.Id,
                StartAdres = x.StartAdres,
                EindAdres = x.EindAdres,
                Datum = x.Datum,

            });
        }
        public ReserveringDto? GetReserveringById(int id)
        {
            var reservering = dbContext.Reserveringen.Find(id);

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
            dbContext.Reserveringen.Add(reservering);
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
            dbContext.Reserveringen.Where(x => x.Id == id).ExecuteDelete();
            dbContext.SaveChanges();

        }

    }
}
