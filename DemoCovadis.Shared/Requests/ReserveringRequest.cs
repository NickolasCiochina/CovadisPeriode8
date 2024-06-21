using DemoCovadis.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCovadis.Shared.Requests
{
    public class ReserveringRequest
    {
        [Required]
        public ChauffeurDto Chauffeur{ get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public string StartAdres { get; set; }
        [Required]
        public string EindAdres { get; set; }
        [Required]
        public string BeginKilometerStand {  get; set; }
        [Required]
        public string EindKilometerStand { get; set; }

        [Required]
        public AutoDto Auto { get; set; }
    }
}
