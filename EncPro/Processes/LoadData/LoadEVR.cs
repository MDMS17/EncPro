using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.Misc;

namespace EncPro.LoadData
{
    public class LoadEVR
    {
        private const int Every10Lines = 10;
        private const string DetailColumnSchema = @"{0, -15}{1,-21}{2,-5}{3,-15}{4,-40}{5, -16}{6,-197}";
        public static readonly string[] ExemptInProgress = { "63" };
        public static readonly string[] ExemptDuplicated = { "52", "53" };
        public static readonly string[] ExemptMemberNotEligible = { "90" };

        public static string EVRReport(CalculatedCounts counts)
        {
            var sb = new StringBuilder();
            sb.AppendLine(EVRHeader(counts));

            sb.AppendLine(EVRSummary(counts));

            sb.AppendLine(EVRDetails(counts.ValidationErrors));

            return sb.ToString();
        }

        public static string EVRHeader(CalculatedCounts counts)
        {
            return
                $@"
Processed Date: {counts.Now}  File Name: {counts.TransmissionmName}
";
        }

        public static string EVRDetails(IEnumerable<ClaimValidationError> claimsInError)
        {
            var sb = new StringBuilder();

            sb.AppendLine(ForColumnLabels());
            sb.AppendLine(ForRowPartition());

            // Build ValidationError and Claims rows
            var rowIndex = 0;
            var cachedClaim = "";
            foreach (var error in claimsInError)
            {
                var isCachedClaim = error.ClaimId.Equals(cachedClaim);

                if (IsTenLines(rowIndex, isCachedClaim))
                    sb.AppendLine(ForRowPartition());

                sb.AppendLine(ForValidation(error));

                if (isCachedClaim)
                    continue;

                ++rowIndex;

                cachedClaim = error.ClaimId;
            }

            return sb.ToString();
        }

        public static bool IsTenLines(int rowIndex, bool isCachedClaim)
        {
            return (rowIndex % Every10Lines == 0) && (rowIndex > 0) && !isCachedClaim;
        }

        private static string ForColumnLabels()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format(DetailColumnSchema
                    , "Record"
                    , "Claim ID"
                    , "No"
                    , "Loop"
                    , "Element Name"
                    , "Error Severity"
                    , "Message"
                )
            );

            return sb.ToString();
        }

        public static string ForRowPartition()
        {
            var sb = new StringBuilder();
            var rowPartitions = string.Format(DetailColumnSchema
                , "--------------"
                , "----------------"
                , "----"
                , "--------------"
                , "---------------------------------------"
                , "---------------"
                ,
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------"
            );

            sb.Append(rowPartitions);

            return sb.ToString();
        }

        private static string ForValidation(ClaimValidationError error)
        {
            error.ErrorSeverityName = "Invalid";

            if (ExemptDuplicated.Contains(error.ErrorId))
                error.ErrorSeverityName = "Duplicate";

            if (ExemptMemberNotEligible.Contains(error.ErrorId))
                error.ErrorSeverityName = "NotElig";

            var sb = new StringBuilder();
            sb.Append(string.Format(DetailColumnSchema,
                error.Record,
                error.ClaimId,
                error.ErrorSequencePerEncounter.ToString().PadLeft(3, ' '),
                error.LoopNumber.PadRight(15).Substring(0, 14).Replace("_Loop", ""),
                error.ElementName.PadRight(40).Substring(0, 39),
                error.ErrorSeverityName,
                error.ErrorDescription
            ));

            return sb.ToString();
        }
        public static string EVRSummary(CalculatedCounts counts)
        {
            return $@"
 Stage 1 - File Level (999 Acknowledgement Transaction Sets)
+=================================================================================================
|                  Record Count |    {counts.RecordCount,5} |                           
+-------------------------------+----------+------------------------------------------------------
|                      Rejected |    {counts.RejectedCount,5} |   Individual Encounters in Non-compliant ST/SE Sets 
+-------------------------------+----------+------------------------------------------------------      
|                      Accepted |    {counts.ProcessedCount,5} |   Individual Encounters in Compliant ST/SE Sets      
+-------------------------------+----------+------------------------------------------------------      

 Stage 2 - Encounter Level
+=================================================================================================
|                     Duplicate |    {counts.ExemptDuplicateCount,5} |  
+-------------------------------+----------+------------------------------------------------------    
|           Member Not Eligible |    {counts.ExemptMemberNotEligibleCount,5} |              
+-------------------------------+----------+------------------------------------------------------
|  Accepted For IEHP Validation |    {counts.EligibileForIehpEditChecks,5} |   
+-------------------------------+----------+------------------------------------------------------
|                   In Progress |    {counts.ExemptInProgressCount,5} |     
+-------------------------------+----------+------------------------------------------------------      
|       Total Records Processed |    {counts.ProcessedCount,5} |  
+-------------------------------+----------+------------------------------------------------------       

 Stage 3 - Validity 
+=================================================================================================
|                       Invalid |    {counts.InvalidCount,5} |   Encounter(s) Failed IEHP Validation        
+-------------------------------+----------+------------------------------------------------------
|                         Valid |    {counts.ValidCount,5} |   Encounter(s) Passed IEHP Validation            
+-------------------------------+----------+------------------------------------------------------
|       Total Records Validated |    {counts.EligibileForIehpEditChecks,5} |   
+-------------------------------+----------+------------------------------------------------------      

+=================================================================================================
|                      Validity |   {counts.Validity,4:0.0} % |   Valid / Accepted For IEHP Validation   
+=================================================================================================
";
        }

    }
}
