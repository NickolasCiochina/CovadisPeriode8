using DemoCovadis.Shared.Dtos;

public class ReserveringDto
{
    public int Id { get; set; }
    public AutoDto Auto { get; set; }
    public ChauffeurDto Chauffeur { get; set; }
    public DateTime Datum { get; set; }
    public string StartAdres { get; set; }
    public string EindAdres { get; set; }
    public string BeginKilometerStand { get; set; }
    public string EindKilometerStand { get; set; }
}
