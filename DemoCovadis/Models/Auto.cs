namespace DemoCovadis.Models
{
    public class Auto
    {
        public int Id { get; set; }

        public string Merk { get; set; }

        public double KilometersStand { get; set; }

        public string Opmerkingen { get; set; }

        public virtual Chauffeur? Chauffeur { get; set; }
    }
}
