using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EncModel.DHCS
{
    public class DHCSEncounter
    {
        [Key]
        public long EncounterId { get; set; }

        public int FileId { get; set; }
        public string TransactionNumber { get; set; }
        public string EncounterStatus { get; set; }
        public string EncounterReferenceNumber { get; set; }
        public string DHCSEncounterId { get; set; }
    }
}
