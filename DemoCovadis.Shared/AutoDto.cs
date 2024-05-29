using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCovadis.Shared
{
    public class AutoDto
    {
        public int Id { get; set; }

        public string Merk { get; set; }

        public double KilometersStand { get; set; }

        public string Opmerkingen { get; set; }

        public virtual ChauffeurDto? Chauffeur { get; set; }
    }
}
