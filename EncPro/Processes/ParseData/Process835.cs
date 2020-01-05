using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel._835;

namespace EncPro.ParseData
{
    public class Process835
    {
        public static void Process835Line(string s835Line, char elementDelimiter, ref File835 processingFile, ref List<Claim835> claims, ref string LoopNumber)
        {
            string[] segments = s835Line.Split('*');
            switch (segments[0])
            {
                case "REF":
                    if (LoopNumber == "0000")
                    {
                        if (segments[1] == "EV")
                        {
                            processingFile.ReceiverReferenceId = segments[2];
                        }
                    }
                    else if (LoopNumber == "1000B")
                    {
                        if (segments[1] == "PQ")
                        {
                            processingFile.PayeeAdditionalIdQualifier = segments[1];
                            processingFile.PayeeAdditionalId = segments[2];
                        }
                        else if (segments[1] == "TJ")
                        {
                            processingFile.PayeeAdditionalIdQualifier2 = segments[1];
                            processingFile.PayeeAdditionalId2 = segments[2];
                        }
                    }
                    else if (LoopNumber == "2110")
                    {
                        if (segments[1] == "6R") claims.Last().LineItemControlNumber = segments[2];
                        else if (segments[1] == "HPI") claims.Last().RenderingProviderNpi = segments[2];
                        else if (segments[1] == "TJ") claims.Last().RenderingProviderTaxId = segments[2];
                        else claims.Last().ProviderReferenceNumber = segments[2];
                    }
                    break;
                case "DTM":
                    if (LoopNumber == "2100")
                    {
                        if (segments[1] == "036") claims.Last().ExpirationDate = segments[2];
                        if (segments[1] == "050") claims.Last().ClaimReceivedDate = segments[2];
                    }
                    else if (LoopNumber == "2110")
                    {
                        if (segments[1] == "150") claims.Last().ServiceStartDate = segments[2];
                        if (segments[1] == "151") claims.Last().ServiceEndDate = segments[2];
                        if (segments[1] == "472") claims.Last().ServiceDate = segments[2];
                    }
                    break;
                case "N1":
                    if (LoopNumber == "0000" && segments[1] == "PR")
                    {
                        LoopNumber = "1000A";
                        processingFile.PayerIdCode = segments[1];
                        processingFile.PayerName = segments[2];
                        if (segments.Length > 3) processingFile.PayerIdQualifier = segments[3];
                        if (segments.Length > 4) processingFile.PayerId = segments[4];
                    }
                    else if (LoopNumber == "1000A" && segments[1] == "PE")
                    {
                        LoopNumber = "1000B";
                        processingFile.PayeeIdCode = segments[1];
                        processingFile.PayeeName = segments[2];
                        processingFile.PayeeIdQualifier = segments[3];
                        processingFile.PayeeId = segments[4];
                    }
                    break;
                case "N3":
                    if (LoopNumber == "1000A")
                    {
                        processingFile.PayerAddress = segments[1];
                        if (segments.Length > 2) processingFile.PayerAddress2 = segments[2];
                    }
                    else if (LoopNumber == "1000B")
                    {
                        processingFile.PayeeAddress = segments[1];
                        if (segments.Length > 2) processingFile.PayeeAddress2 = segments[2];
                    }
                    break;
                case "N4":
                    if (LoopNumber == "1000A")
                    {
                        processingFile.PayerCity = segments[1];
                        processingFile.PayerState = segments[2];
                        processingFile.PayerZip = segments[3];
                    }
                    else if (LoopNumber == "1000B")
                    {
                        processingFile.PayeeCity = segments[1];
                        processingFile.PayeeState = segments[2];
                        processingFile.PayeeZip = segments[3];
                    }
                    break;
                case "PER":
                    if (LoopNumber == "1000A")
                    {
                        if (segments[1] == "CX")
                        {
                            processingFile.ContactFunctionCode = segments[1];
                            if (segments.Length > 2) processingFile.ContactName = segments[2];
                            if (segments.Length > 3) processingFile.ContactCommunicationQualifier = segments[3];
                            if (segments.Length > 4) processingFile.ContactCommunicationNumber = segments[4];
                        }
                        else if (segments[1] == "BL")
                        {
                            processingFile.TechFunctionCode = segments[1];
                            if (segments.Length > 2) processingFile.TechName = segments[2];
                            if (segments.Length > 3) processingFile.TechCommunicationQualifier1 = segments[3];
                            if (segments.Length > 4) processingFile.TechCommunicationNumber1 = segments[4];
                            if (segments.Length > 5) processingFile.TechCommunicationQualifier2 = segments[5];
                            if (segments.Length > 6) processingFile.TechCommunicationNumber2 = segments[6];
                        }
                        else if (segments[1] == "IC")
                        {
                            processingFile.WebFunctionCode = segments[1];
                            if (segments.Length > 2) processingFile.WebName = segments[2];
                            if (segments.Length > 3) processingFile.WebCommunicationQualifier = segments[3];
                            if (segments.Length > 4) processingFile.WebCommunicationNumber = segments[4];
                        }
                    }
                    break;
                case "LX":
                    LoopNumber = "2000";
                    break;
                case "CLP":
                    LoopNumber = "2100";
                    Claim835 claim = new Claim835();
                    claim.FileId = processingFile.FileId;
                    claim.PatientControlNumber = segments[1];
                    claim.ClaimStatus = segments[2];
                    claim.TotalChargeAmount = segments[3];
                    claim.TotalPaidAmount = segments[4];
                    claim.PatientResponsibilityAmount = segments[5];
                    claim.ClaimFilingIndicator = segments[6];
                    claim.PayerClaimcCntrolNumber = segments[7];
                    claim.FacilityTypeCode = segments[8];
                    if (segments.Length > 9) claim.ClaimFrequencyCode = segments[9];
                    if (segments.Length > 10) claim.PatientStatusCode = segments[10];
                    if (segments.Length > 11) claim.DrgCode = segments[11];
                    if (segments.Length > 12) claim.DrgWeight = segments[12];
                    if (segments.Length > 13) claim.DischargePercent = segments[13];
                    claims.Add(claim);
                    break;
                case "NM1":
                    if (LoopNumber == "2100")
                    {
                        if (segments[1] == "QC")
                        {
                            claims.Last().PatientCode = segments[1];
                            claims.Last().PatientEntityType = segments[2];
                            claims.Last().PatientLastName = segments[3];
                            claims.Last().PatientFirstName = segments[4];
                            claims.Last().PatientMiddleInitial = segments[5];
                            claims.Last().PatientPrefix = segments[6];
                            claims.Last().PatientSuffix = segments[7];
                            claims.Last().PatientIdQualifier = segments[8];
                            claims.Last().PatientId = segments[9];
                        }
                        else if (segments[1] == "82")
                        {
                            claims.Last().ProviderCode = segments[1];
                            claims.Last().ProviderEntityType = segments[2];
                            claims.Last().ProviderLastName = segments[3];
                            claims.Last().ProviderFirstName = segments[4];
                            claims.Last().ProviderMiddleInitial = segments[5];
                            claims.Last().ProviderPrefix = segments[6];
                            claims.Last().ProviderSuffix = segments[7];
                            claims.Last().ProviderIdQualifier = segments[8];
                            claims.Last().ProviderId = segments[9];
                        }
                    }
                    break;
                case "SVC":
                    LoopNumber = "2110";
                    string[] elements = segments[1].Split(elementDelimiter);
                    claims.Last().ServiceTypeCode = elements[0];
                    claims.Last().ProcedureCode = elements[1];
                    if (elements.Length > 2) claims.Last().Modifier1 = elements[2];
                    if (elements.Length > 3) claims.Last().Modifier2 = elements[3];
                    if (elements.Length > 4) claims.Last().Modifier3 = elements[4];
                    if (elements.Length > 5) claims.Last().Modifier4 = elements[5];
                    if (elements.Length > 6) claims.Last().ProcedureDescription = elements[6];
                    claims.Last().LineChargeAmount = segments[2];
                    claims.Last().LinePaidAmount = segments[3];
                    claims.Last().RevenueCode = segments[4];
                    claims.Last().PaidUnitCount = segments[5];
                    if (segments.Length > 6)
                    {
                        elements = segments[6].Split(elementDelimiter);
                        if (elements.Length > 0) claims.Last().DiffServiceTypeCode = elements[0];
                        if (elements.Length > 1) claims.Last().DiffProcedureCode = elements[1];
                        if (elements.Length > 2) claims.Last().DiffModifier1 = elements[2];
                        if (elements.Length > 3) claims.Last().DiffModifier2 = elements[3];
                        if (elements.Length > 4) claims.Last().DiffModifier3 = elements[4];
                        if (elements.Length > 5) claims.Last().DiffModifier4 = elements[5];
                        if (elements.Length > 6) claims.Last().DiffProcedureDescription = elements[6];
                        claims.Last().ChargeUnitCount = segments[7];
                    }
                    break;
                case "CAS":
                    if (LoopNumber == "2100")
                    {
                        claims.Last().ClaimAdjustmentGroupCode = segments[1];
                        claims.Last().AdjustmentReasoncCode1 = segments[2];
                        claims.Last().AdjustmentAmount1 = segments[3];
                        if (segments.Length > 4) claims.Last().AdjustmentQuantity1 = segments[4];
                        if (segments.Length > 5) claims.Last().AdjustmentReasonCode2 = segments[5];
                        if (segments.Length > 6) claims.Last().AdjustmentAmount2 = segments[6];
                        if (segments.Length > 7) claims.Last().AdjustmentQuantity2 = segments[7];
                        if (segments.Length > 8) claims.Last().AdjustmentReasonCode3 = segments[8];
                        if (segments.Length > 9) claims.Last().AdjustmentAmount3 = segments[9];
                        if (segments.Length > 10) claims.Last().AdjustmentQuantity3 = segments[10];
                        if (segments.Length > 11) claims.Last().AdjustmentReasonCode4 = segments[11];
                        if (segments.Length > 12) claims.Last().AdjustmentAmount4 = segments[12];
                        if (segments.Length > 13) claims.Last().AdjustmentQuantity4 = segments[13];
                        if (segments.Length > 14) claims.Last().AdjustmentReasonCode5 = segments[14];
                        if (segments.Length > 15) claims.Last().AdjustmentAmount5 = segments[15];
                        if (segments.Length > 16) claims.Last().AdjustmentQuantity5 = segments[16];
                        if (segments.Length > 17) claims.Last().AdjustmentReasonCode6 = segments[17];
                        if (segments.Length > 18) claims.Last().AdjustmentAmount6 = segments[18];
                        if (segments.Length > 19) claims.Last().AdjustmentQuantity6 = segments[19];
                    }
                    else if (LoopNumber == "2110")
                    {
                        claims.Last().LineAdjustmentGroupCode = segments[1];
                        claims.Last().LineAdjustmentReasonCode1 = segments[2];
                        claims.Last().LineAdjustmentAmount1 = segments[3];
                        if (segments.Length > 4) claims.Last().LineAdjustmentQuantity1 = segments[4];
                        if (segments.Length > 5) claims.Last().LineAdjustmentReasonCode2 = segments[5];
                        if (segments.Length > 6) claims.Last().LineAdjustmentAmount2 = segments[6];
                        if (segments.Length > 7) claims.Last().LineAdjustmentQuantity2 = segments[7];
                        if (segments.Length > 8) claims.Last().LineAdjustmentReasonCode3 = segments[8];
                        if (segments.Length > 9) claims.Last().LineAdjustmentAmount3 = segments[9];
                        if (segments.Length > 10) claims.Last().LineAdjustmentQuantity3 = segments[10];
                        if (segments.Length > 11) claims.Last().LineAdjustmentReasonCode4 = segments[11];
                        if (segments.Length > 12) claims.Last().LineAdjustmentAmount4 = segments[12];
                        if (segments.Length > 13) claims.Last().LineAdjustmentQuantity4 = segments[13];
                        if (segments.Length > 14) claims.Last().LineAdjustmentReasonCode5 = segments[14];
                        if (segments.Length > 15) claims.Last().LineAdjustmentAmount5 = segments[15];
                        if (segments.Length > 16) claims.Last().LineAdjustmentQuantity5 = segments[16];
                        if (segments.Length > 17) claims.Last().LineAdjustmentReasonCode6 = segments[17];
                        if (segments.Length > 18) claims.Last().LineAdjustmentAmount6 = segments[18];
                        if (segments.Length > 19) claims.Last().LineAdjustmentQuantity6 = segments[19];

                    }
                    break;
                case "AMT":
                    if (LoopNumber == "2100")
                    {
                        claims.Last().SupplementalAmountQualifier = segments[1];
                        claims.Last().SupplementalAmount = segments[2];
                    }
                    else if (LoopNumber == "2110")
                    {
                        claims.Last().LineAllowedAmount = segments[2];
                    }
                    break;
                case "LQ":
                    if (LoopNumber == "2110")
                    {
                        claims.Last().RemarkCode = segments[2];
                    }
                    break;
                case "PLB":
                    if (segments.Length > 1) processingFile.ProviderAdjustmentId = segments[1];
                    if (segments.Length > 2) processingFile.ProviderFiscalDate = segments[2];
                    if (segments.Length > 3) processingFile.ProviderAdjustmentId1 = segments[3].Split(elementDelimiter)[0];
                    if (segments.Length > 4) processingFile.ProviderAdjustmentAmount1 = segments[4];
                    if (segments.Length > 5) processingFile.ProviderAdjustmentId2 = segments[5].Split(elementDelimiter)[0];
                    if (segments.Length > 6) processingFile.ProviderAdjustmentAmount2 = segments[6];
                    if (segments.Length > 7) processingFile.ProviderAdjustmentId3 = segments[7].Split(elementDelimiter)[0];
                    if (segments.Length > 8) processingFile.ProviderAdjustmentAmount3 = segments[8];
                    if (segments.Length > 9) processingFile.ProviderAdjustmentId4 = segments[9].Split(elementDelimiter)[0];
                    if (segments.Length > 10) processingFile.ProviderAdjustmentAmount4 = segments[10];
                    if (segments.Length > 11) processingFile.ProviderAdjustmentId5 = segments[11].Split(elementDelimiter)[0];
                    if (segments.Length > 12) processingFile.ProviderAdjustmentAmount5 = segments[12];
                    if (segments.Length > 13) processingFile.ProviderAdjustmentId6 = segments[13].Split(elementDelimiter)[0];
                    if (segments.Length > 14) processingFile.ProviderAdjustmentAmount6 = segments[14];

                    break;
            }
        }
    }
}
