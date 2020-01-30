using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EncPro.ParseData
{
    public class Regexes
    {
        public static Regex RapsFile()
        {
            return new Regex(@"AAA(?<SubmitterId>.{6})(?<InterchangeControlNumber>.{10})(?<TransactionDate>.{8})(?<ProductionIndicator>.{4})(?<Filler>.{481})");
        }
        public static Regex RapsBatch()
        {
            return new Regex(@"BBB(?<SequenceNumber>.{7})(?<PlanNumber>.{5})(?<Filler>.{497})");
        }
        public static Regex RapsDetail()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CCC");
            sb.Append("(?<DetailSequence>.{7})");
            sb.Append("(?<SequenceErrorCode>.{3})");
            sb.Append("(?<PatientControlNumber>.{40})");
            sb.Append("(?<HICN>.{25})");
            sb.Append("(?<HICNErrorCode>.{3})");
            sb.Append("(?<PatientDOB>.{8})");
            sb.Append("(?<DOBErrorCode>.{3})");
            sb.Append("(?<ProviderType0>.{2})");
            sb.Append("(?<FromDate0>.{8})");
            sb.Append("(?<ThroughtDate0>.{8})");
            sb.Append("(?<DeleteIndicator0>.{1})");
            sb.Append("(?<DiagnosisCode0>.{7})");
            sb.Append("(?<DiagnosisError01>.{3})");
            sb.Append("(?<DiagnosisError02>.{3})");
            sb.Append("(?<ProviderType1>.{2})");
            sb.Append("(?<FromDate1>.{8})");
            sb.Append("(?<ThroughtDate1>.{8})");
            sb.Append("(?<DeleteIndicator1>.{1})");
            sb.Append("(?<DiagnosisCode1>.{7})");
            sb.Append("(?<DiagnosisError11>.{3})");
            sb.Append("(?<DiagnosisError12>.{3})");
            sb.Append("(?<ProviderType2>.{2})");
            sb.Append("(?<FromDate2>.{8})");
            sb.Append("(?<ThroughtDate2>.{8})");
            sb.Append("(?<DeleteIndicator2>.{1})");
            sb.Append("(?<DiagnosisCode2>.{7})");
            sb.Append("(?<DiagnosisError21>.{3})");
            sb.Append("(?<DiagnosisError22>.{3})");
            sb.Append("(?<ProviderType3>.{2})");
            sb.Append("(?<FromDate3>.{8})");
            sb.Append("(?<ThroughtDate3>.{8})");
            sb.Append("(?<DeleteIndicator3>.{1})");
            sb.Append("(?<DiagnosisCode3>.{7})");
            sb.Append("(?<DiagnosisError31>.{3})");
            sb.Append("(?<DiagnosisError32>.{3})");
            sb.Append("(?<ProviderType4>.{2})");
            sb.Append("(?<FromDate4>.{8})");
            sb.Append("(?<ThroughtDate4>.{8})");
            sb.Append("(?<DeleteIndicator4>.{1})");
            sb.Append("(?<DiagnosisCode4>.{7})");
            sb.Append("(?<DiagnosisError41>.{3})");
            sb.Append("(?<DiagnosisError42>.{3})");
            sb.Append("(?<ProviderType5>.{2})");
            sb.Append("(?<FromDate5>.{8})");
            sb.Append("(?<ThroughtDate5>.{8})");
            sb.Append("(?<DeleteIndicator5>.{1})");
            sb.Append("(?<DiagnosisCode5>.{7})");
            sb.Append("(?<DiagnosisError51>.{3})");
            sb.Append("(?<DiagnosisError52>.{3})");
            sb.Append("(?<ProviderType6>.{2})");
            sb.Append("(?<FromDate6>.{8})");
            sb.Append("(?<ThroughtDate6>.{8})");
            sb.Append("(?<DeleteIndicator6>.{1})");
            sb.Append("(?<DiagnosisCode6>.{7})");
            sb.Append("(?<DiagnosisError61>.{3})");
            sb.Append("(?<DiagnosisError62>.{3})");
            sb.Append("(?<ProviderType7>.{2})");
            sb.Append("(?<FromDate7>.{8})");
            sb.Append("(?<ThroughtDate7>.{8})");
            sb.Append("(?<DeleteIndicator7>.{1})");
            sb.Append("(?<DiagnosisCode7>.{7})");
            sb.Append("(?<DiagnosisError71>.{3})");
            sb.Append("(?<DiagnosisError72>.{3})");
            sb.Append("(?<ProviderType8>.{2})");
            sb.Append("(?<FromDate8>.{8})");
            sb.Append("(?<ThroughtDate8>.{8})");
            sb.Append("(?<DeleteIndicator8>.{1})");
            sb.Append("(?<DiagnosisCode8>.{7})");
            sb.Append("(?<DiagnosisError81>.{3})");
            sb.Append("(?<DiagnosisError82>.{3})");
            sb.Append("(?<ProviderType9>.{2})");
            sb.Append("(?<FromDate9>.{8})");
            sb.Append("(?<ThroughtDate9>.{8})");
            sb.Append("(?<DeleteIndicator9>.{1})");
            sb.Append("(?<DiagnosisCode9>.{7})");
            sb.Append("(?<DiagnosisError91>.{3})");
            sb.Append("(?<DiagnosisError92>.{3})");
            sb.Append("(?<CorrectedHICN>.{25})");
            sb.Append("(?<Filler>.{75})");
            return new Regex(sb.ToString());
        }
        public static Regex BatchTrailer()
        {
            return new Regex("YYY(?<>.{SequenceNumber})(?<PlanNumber>.{5})(?<TotalDetails>.{7})(?<Filler>.{490})");
        }
        public static Regex FileTrailer()
        {
            return new Regex("ZZZ(?<SubmitterId>/{6})(?<InterchangeControlNumber>.{10})(?<TotalBatches>.{7})(?<Filler>.{486})");
        }
    }
}
