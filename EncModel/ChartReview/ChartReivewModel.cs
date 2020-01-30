using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.ChartReview
{
    public class ChartReviewRecord
    {
        public string ClaimType { get; set; }
        public string ProviderNPI { get; set; }
        public string MemberHICN { get; set; }
        public string MemberDOB { get; set; }
        public string DosFromDate { get; set; }
        public string DosToDate { get; set; }
        public string DiagnosisCode { get; set; }
        public string DeleteIndicator { get; set; }
        public string ProcedureCode { get; set; }
        public string RevenueCode { get; set; }
    }
    public class ChartReviewData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LastItem { get; set; }
    }
}
