using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.Misc
{
    public class ClaimValidationError
    {
        public string Record { get; set; }
        public string ClaimId { get; set; }
        public int ErrorSequencePerEncounter { get; set; }
        public string ErrorId { get; set; }
        public string ErrorSeverityName { get; set; }
        public string ErrorDescription { get; set; }
        public string LoopNumber { get; set; }
        public string ElementName { get; set; }
    }
}
