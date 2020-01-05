using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.MAO2;

namespace EncPro.ParseData
{
    public static partial class Parser
    {
        public static void ParserMao2Line(string line, ref MAO2File processingFile, ref List<MAO2Detail> details)
        {
            string[] segments = line.Split('*');
            if (segments[0] == "0") //header
            {
                processingFile.TransactionDate = segments[3];
                processingFile.SenderId = segments[6].Substring(0, 6);
                processingFile.ICN = segments[6].Substring(6, 9);
                processingFile.RecordType = segments[7];
                processingFile.ProductionFlag = segments[8];
            }
            else if (segments[0] == "1") //detail
            {
                MAO2Detail detail = new MAO2Detail
                {
                    FileId = processingFile.FileId,
                    ClaimId = segments[3].Trim(),
                    InternalControlNumber = segments[4],
                    LineNumber = segments[5],
                    EncounterStatus = segments[6],
                    ErrorCode = segments[7],
                    ErrorDescription = segments[8]
                };
                details.Add(detail);
            }
            else if (segments[0] == "9") //trailer
            {
                processingFile.TotalErrors = segments[2];
                processingFile.TotalLinesAccepted = segments[3];
                processingFile.TotalLinesRejected = segments[4];
                processingFile.TotalLinesSubmitted = segments[5];
                processingFile.TotalEncountersAccepted = segments[6];
                processingFile.TotalEncountersRejected = segments[7];
                processingFile.TotalEncountersSubmitted = segments[8];
            }
        }
    }
}
