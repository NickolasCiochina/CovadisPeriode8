namespace DemoCovadis.Models
{
    public class Chauffeur
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string TelefoonNummer { get; set; }

        public string BeginAdres { get; set; }

        public string EindAdres { get; set; }

        public virtual ICollection<Auto>? Autos { get; set; }
    }
}