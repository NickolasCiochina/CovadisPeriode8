using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCovadis.Shared
{
    public class ChauffeurDto
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string TelefoonNummer { get; set; }

        public string BeginAdres { get; set; }

        public string EindAdres { get; set; }

        public virtual ICollection<AutoDto>? Autos { get; set; }
    }
}
