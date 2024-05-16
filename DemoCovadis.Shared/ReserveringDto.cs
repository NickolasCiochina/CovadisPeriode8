using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCovadis.Shared
{
    public class ReserveringDto
    {
        public int Id { get; set; }
        public AutoDto Auto { get; set; }
        public ChauffeurDto Chauffeur { get; set; }
        public DateTime Datum { get; set; }
        public string StartAdres { get; set; }
        public string EindAdres { get; set; }
    }
}
