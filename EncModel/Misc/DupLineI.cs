using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.Misc
{
    public class DupLineI
    {
        public string MemberId { get; set; }
        public string ServiceDateFrom { get; set; }
        public string ServiceDateTo { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeHour { get; set; }
        public string AttendingProvId { get; set; } //NPI, Medi-Cal Provider Id, State License Number
        public string RenderingProvId { get; set; } //NPI, Medi-Cal Provider Id, State License Number
        public string RevenueCode { get; set; }
        public string ProcedureCode { get; set; }
        public string Modifier1 { get; set; }
        public string Modifier2 { get; set; }
        public string Modifier3 { get; set; }
        public string Modifier4 { get; set; }
        public string NDC { get; set; }

    }
}
