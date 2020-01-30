using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.Log;
using EncModel.Raps;
using EncModel.ChartReview;

namespace EncPro
{
    public class GlobalVariables
    {
        public static List<string> DMEProcCodes { get; set; }
        public static string DestinationFolder { get; set; }
        public static List<List<LoadLog>> SchedulePages { get; set; }
        public static int TotalCCII { get; set; }
        public static int TotalCCIP { get; set; }
        public static int TotalCMCI { get; set; }
        public static int TotalCMCP { get; set; }
        public static int TotalDHCSI { get; set; }
        public static int TotalDHCSP { get; set; }
        public static List<RapsRecord> rapsRecords { get; set; }
        public static List<ChartReviewRecord> chartReviewRecords { get; set; }
    }
}
