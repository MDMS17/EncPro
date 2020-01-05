using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EncModel.Subcache;

namespace EncModel.SubHistory
{
    public class Hipaa_XML
    {
        [Key]
        public int ID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimID { get; set; }
        public string EncounterId { get; set; }
        public string ClaimHipaaXML { get; set; }
    }
    public class Claim
    {
        public ClaimHeader Header { get; set; }
        public List<ServiceLine> Lines { get; set; }
        public List<ClaimProvider> Providers { get; set; }
        public List<ProviderContact> ProviderContacts { get; set; }
        public List<ClaimSecondaryIdentification> SecondaryIdentifications { get; set; }
        public List<ClaimPWK> PWKs { get; set; }
        public List<ClaimK3> K3s { get; set; }
        public List<ClaimNte> Notes { get; set; }
        public List<ClaimCRC> CRCs { get; set; }
        public List<ClaimHI> His { get; set; }
        public List<ClaimSBR> Subscribers { get; set; }
        public List<ClaimPatient> Patients { get; set; }
        public List<ClaimCAS> Cases { get; set; }
        public List<ClaimLineMEA> Meas { get; set; }
        public List<ClaimLineSVD> SVDs { get; set; }
        public List<ClaimLineLQ> LQs { get; set; }
        public List<ClaimLineFRM> FRMs { get; set; }
        public List<ToothStatus> ToothStatuses { get; set; }
        public Claim()
        {
            Header = new ClaimHeader();
            Lines = new List<ServiceLine>();
            Providers = new List<ClaimProvider>();
            ProviderContacts = new List<ProviderContact>();
            SecondaryIdentifications = new List<ClaimSecondaryIdentification>();
            PWKs = new List<ClaimPWK>();
            K3s = new List<ClaimK3>();
            Notes = new List<ClaimNte>();
            CRCs = new List<ClaimCRC>();
            His = new List<ClaimHI>();
            Subscribers = new List<ClaimSBR>();
            Patients = new List<ClaimPatient>();
            Cases = new List<ClaimCAS>();
            Meas = new List<ClaimLineMEA>();
            SVDs = new List<ClaimLineSVD>();
            LQs = new List<ClaimLineLQ>();
            FRMs = new List<ClaimLineFRM>();
            ToothStatuses = new List<ToothStatus>();
        }
    }
}
