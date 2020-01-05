using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.Misc
{
    public class CalculatedCounts
    {
        public int RecordCount { get; set; }
        public int ProcessedCount { get; set; }
        public int ExemptInProgressCount { get; set; }
        public int RejectedCount { get; set; }
        public int ExemptDuplicateCount { get; set; }
        public int ExemptMemberNotEligibleCount { get; set; }
        public int EligibileForIehpEditChecks { get; set; }
        public IList<ClaimValidationError> ValidationErrors { get; set; }
        public int InvalidCount { get; set; }
        public int ValidCount { get; set; }
        public DateTime Now { get; set; }
        public float Validity { get; set; }
        public string TransmissionmName { get; set; }
    }
}
