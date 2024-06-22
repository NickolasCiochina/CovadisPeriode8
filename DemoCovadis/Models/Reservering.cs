    using System.ComponentModel.DataAnnotations;

    namespace DemoCovadis.Models
    {
        public class Reservering
        {
            public int Id { get; set; }
            public Auto Auto { get; set; }
            public Chauffeur Chauffeur { get; set; }
            public DateTime Datum { get; set; }
            public string StartAdres { get; set; }
            public string EindAdres { get; set; }
            public string BeginKilometerStand { get; set; }
            public string EindKilometerStand { get; set; }
        }
    }
