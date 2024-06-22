namespace DemoCovadis.Models
{
    public class Chauffeur
    {
        public int Id { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string TelefoonNummer { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Auto>? Autos { get; set; }
    }
}