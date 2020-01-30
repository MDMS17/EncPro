using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EncModel.Raps
{
    public class RapsFile
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string SubmitterId { get; set; }
        public string InterchangeControlNumber { get; set; }
        public string TransactionDate { get; set; }
        public string ProductionIndicator { get; set; }
        public string TotalBatches { get; set; }
        public string CreatedBy { get; set; }
        public DateTime createDate { get; set; }
    }
    public class RapsBatch
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public string BatchId { get; set; }
        public string BatchSequence { get; set; }
        public string PlanNumber { get; set; }
        public string TotalDetails { get; set; }
    }
    public class RapsDetail
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public string BatchId { get; set; }
        public string DetailSequence { get; set; }
        public string SequenceErrorCode { get; set; }
        public string PatientControlNumber { get; set; }
        public string HICN { get; set; }
        public string HICNErrorCode { get; set; }
        public string PatientDOB { get; set; }
        public string DOBErrorCode { get; set; }
        public string ProviderType0 { get; set; }
        public string FromDate0 { get; set; }
        public string ThroughtDate0 { get; set; }
        public string DeleteIndicator0 { get; set; }
        public string DiagnosisCode0 { get; set; }
        public string DiagnosisError01 { get; set; }
        public string DiagnosisError02 { get; set; }
        public string ProviderType1 { get; set; }
        public string FromDate1 { get; set; }
        public string ThroughtDate1 { get; set; }
        public string DeleteIndicator1 { get; set; }
        public string DiagnosisCode1 { get; set; }
        public string DiagnosisError11 { get; set; }
        public string DiagnosisError12 { get; set; }
        public string ProviderType2 { get; set; }
        public string FromDate2 { get; set; }
        public string ThroughtDate2 { get; set; }
        public string DeleteIndicator2 { get; set; }
        public string DiagnosisCode2 { get; set; }
        public string DiagnosisError21 { get; set; }
        public string DiagnosisError22 { get; set; }
        public string ProviderType3 { get; set; }
        public string FromDate3 { get; set; }
        public string ThroughtDate3 { get; set; }
        public string DeleteIndicator3 { get; set; }
        public string DiagnosisCode3 { get; set; }
        public string DiagnosisError31 { get; set; }
        public string DiagnosisError32 { get; set; }
        public string ProviderType4 { get; set; }
        public string FromDate4 { get; set; }
        public string ThroughtDate4 { get; set; }
        public string DeleteIndicator4 { get; set; }
        public string DiagnosisCode4 { get; set; }
        public string DiagnosisError41 { get; set; }
        public string DiagnosisError42 { get; set; }
        public string ProviderType5 { get; set; }
        public string FromDate5 { get; set; }
        public string ThroughtDate5 { get; set; }
        public string DeleteIndicator5 { get; set; }
        public string DiagnosisCode5 { get; set; }
        public string DiagnosisError51 { get; set; }
        public string DiagnosisError52 { get; set; }
        public string ProviderType6 { get; set; }
        public string FromDate6 { get; set; }
        public string ThroughtDate6 { get; set; }
        public string DeleteIndicator6 { get; set; }
        public string DiagnosisCode6 { get; set; }
        public string DiagnosisError61 { get; set; }
        public string DiagnosisError62 { get; set; }
        public string ProviderType7 { get; set; }
        public string FromDate7 { get; set; }
        public string ThroughtDate7 { get; set; }
        public string DeleteIndicator7 { get; set; }
        public string DiagnosisCode7 { get; set; }
        public string DiagnosisError71 { get; set; }
        public string DiagnosisError72 { get; set; }
        public string ProviderType8 { get; set; }
        public string FromDate8 { get; set; }
        public string ThroughtDate8 { get; set; }
        public string DeleteIndicator8 { get; set; }
        public string DiagnosisCode8 { get; set; }
        public string DiagnosisError81 { get; set; }
        public string DiagnosisError82 { get; set; }
        public string ProviderType9 { get; set; }
        public string FromDate9 { get; set; }
        public string ThroughtDate9 { get; set; }
        public string DeleteIndicator9 { get; set; }
        public string DiagnosisCode9 { get; set; }
        public string DiagnosisError91 { get; set; }
        public string DiagnosisError92 { get; set; }
        public string CorrectedHICN { get; set; }
    }
    public class RapsRecord
    {
        public string PatientHICN { get; set; }
        public string PatientDOB { get; set; }
        public string ProviderType { get; set; }
        public string FromDate { get; set; }
        public string ThroughtDate { get; set; }
        public string DeleteIndicator { get; set; }
        public string DiagnosisCode { get; set; }
    }
}
