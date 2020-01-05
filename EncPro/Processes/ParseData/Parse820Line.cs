using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.Premium820;

namespace EncPro.ParseData
{
    public class Parser820
    {
        public static void Parse820Line(string line, ref string loopName, ref File820 processingFile, ref List<Member820> premiums, ref bool firstRMR)
        {
            string[] segments = line.Split('*');
            switch (segments[0])
            {
                case "ST":
                    loopName = "1000A";
                    break;
                case "ENT":
                    loopName = "2000B";
                    Member820 premium = new Member820();
                    premium.FileId = processingFile.FileId;
                    premium.EntityIdQualifier = segments[3];
                    premium.EntityId = segments[4];
                    premiums.Add(premium);
                    firstRMR = true;
                    break;
                case "NM1":
                    if (loopName == "2000B")
                    {
                        premiums.Last().MemberLastName = segments[3];
                        premiums.Last().MemberFirstName = segments[4];
                        premiums.Last().MemberMiddleName = segments[5];
                        premiums.Last().MemberIdQualifier = segments[8];
                        premiums.Last().MemberId = segments[9];
                    }
                    break;
                case "N1":
                    if (loopName == "1000A" && segments[1] == "PR")
                    {
                        loopName = "1000B";
                        processingFile.PayerName = segments[2];
                    }
                    else if (loopName == "1000A" && segments[1] == "PE")
                    {
                        processingFile.PayeeLastName = segments[2];
                    }
                    break;
                case "N3":
                    if (loopName == "1000A")
                    {
                        processingFile.PayeeAddress = segments[1];
                    }
                    else if (loopName == "1000B")
                    {
                        processingFile.PayerAddress = segments[1];
                    }
                    break;
                case "N4":
                    if (loopName == "1000A")
                    {
                        processingFile.PayeeCity = segments[1];
                        processingFile.PayeeState = segments[2];
                        processingFile.PayeeZip = segments[3];
                    }
                    else if (loopName == "1000B")
                    {
                        processingFile.PayerCity = segments[1];
                        processingFile.PayerState = segments[2];
                        processingFile.PayerZip = segments[3];
                    }
                    break;
                case "RMR":
                    loopName = "2300B";
                    if (firstRMR)
                    {
                        premiums.Last().InsuranceRemittanceReferenceNumber = segments[2];
                        premiums.Last().DetailPremiumPaymentAmount = segments[4];
                        if (segments.Length > 5) premiums.Last().BilledPremiumAmount = segments[5];
                        firstRMR = false;
                    }
                    else
                    {
                        Member820 premium2 = new Member820();
                        premium2.FileId = processingFile.FileId;
                        premium2.EntityIdQualifier = premiums.Last().EntityIdQualifier;
                        premium2.EntityId = premiums.Last().EntityId;
                        premium2.MemberLastName = premiums.Last().MemberLastName;
                        premium2.MemberFirstName = premiums.Last().MemberFirstName;
                        premium2.MemberMiddleName = premiums.Last().MemberMiddleName;
                        premium2.MemberIdQualifier = premiums.Last().MemberIdQualifier;
                        premium2.MemberId = premiums.Last().MemberId;
                        premium2.InsuranceRemittanceReferenceNumber = segments[2];
                        premium2.DetailPremiumPaymentAmount = segments[4];
                        if (segments.Length > 5) premium2.BilledPremiumAmount = segments[5];
                        premiums.Add(premium2);
                    }
                    break;
                case "REF":
                    if (loopName == "1000A")
                    {
                        processingFile.PayeeIdQualifier = segments[1];
                        processingFile.PayeeId = segments[2];
                    }
                    else if (loopName == "2300B")
                    {
                        if (segments[1] == "18") premiums.Last().CountyCode = segments[2];
                        else if (segments[1] == "ZZ" && segments[2].Length == 2) premiums.Last().OrganizationalReferenceId = segments[2];
                        else if (segments[1] == "ZZ" && segments[2].Length > 2) premiums.Last().OrganizationalDescription = segments[2];
                    }
                    break;
                case "DTM":
                    if (loopName == "2300B")
                    {
                        premiums.Last().CapitationFromDate = segments[6].Split('-')[0];
                        premiums.Last().CapitationThroughDate = segments[6].Split('-')[1];
                    }
                    else if (loopName == "1000A")
                    {
                        processingFile.CoverageFirstDate = segments[2].Split('-')[0];
                        processingFile.CoverageLastDate = segments[2].Split('-')[1];
                    }
                    break;
                case "ADX":
                    if (loopName == "2300B")
                    {
                        premiums.Last().AdjustmentAmount = segments[1];
                        premiums.Last().AdjustmentReasonCode = segments[2];
                    }
                    break;
            }
        }
    }
}
