using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCovadis.Shared.Dtos
{
    public class ChauffeurDto
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string TelefoonNummer { get; set; }
        public string Email { get; set; }
        public ICollection<AutoDto>? Autos { get; set; }
    }

}
