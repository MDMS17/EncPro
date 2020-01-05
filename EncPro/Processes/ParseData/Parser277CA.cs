using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel._277CA;

namespace EncPro.ParseData
{
    public static partial class Parser
    {
        public static void Parser277CALine(string line, ref _277CAFile processingFile, ref List<_277CABillProv> billProvs,
            ref List<_277CAPatient> patients, ref List<_277CALine> lines, ref List<_277CAStc> stcs, ref string loopName, ref char elementDelimiter)
        {
            string[] segments = line.Split('*');
            switch (segments[0])
            {
                case "HL":
                    switch (segments[3])
                    {
                        case "20":
                            loopName = "2000A"; //receiver
                            break;
                        case "21":
                            loopName = "2000B"; //sender
                            break;
                        case "19":
                            loopName = "2000C"; //billing provider
                            break;
                        case "PT":
                            loopName = "2000D"; //patient
                            break;
                    }

                    break;
                case "STC":
                    _277CAStc stc = new _277CAStc();
                    switch (loopName)
                    {
                        case "2000B":
                            stc.StcType = "File";
                            stc.FileId = processingFile.FileId;
                            break;
                        case "2000C":
                            stc.StcType = "BillProv";
                            stc.FileId = processingFile.FileId;
                            stc.BillProvId = billProvs.Last().BillProvId;
                            stc.ClaimId = billProvs.Last().ClaimId;
                            break;
                        case "2000D":
                            stc.StcType = "Patient";
                            stc.FileId = processingFile.FileId;
                            stc.BillProvId = billProvs.Last().BillProvId;
                            stc.ClaimId = patients.Last().ClaimId;
                            stc.PatientId = patients.Last().PatientId;
                            break;
                        case "2220D":
                            stc.StcType = "Line";
                            stc.FileId = processingFile.FileId;
                            stc.BillProvId = billProvs.Last().BillProvId;
                            stc.ClaimId = patients.Last().ClaimId;
                            stc.PatientId = patients.Last().PatientId;
                            break;
                    }

                    string[] elements = segments[1].Split(elementDelimiter);
                    stc.ClaimStatusCategory1 = elements[0];
                    stc.ClaimStatusCode1 = elements[1];
                    if (elements.Length > 2) stc.EntityIdentifier1 = elements[2];
                    stc.StatusInfoEffDate = segments[2];
                    stc.ActionCode = segments[3];
                    if (segments.Length > 4) stc.ChargeAmount = segments[4];
                    if (segments.Length > 10)
                    {
                        elements = segments[10].Split(elementDelimiter);
                        stc.ClaimStatusCategory2 = elements[0];
                        stc.ClaimStatusCode2 = elements[1];
                        if (elements.Length > 2) stc.EntityIdentifier2 = elements[2];
                    }

                    if (segments.Length > 11)
                    {
                        elements = segments[11].Split(elementDelimiter);
                        stc.ClaimStatusCategory3 = elements[0];
                        stc.ClaimStatusCode3 = elements[1];
                        if (elements.Length > 2) stc.EntityIdentifier3 = elements[2];
                    }
                    stcs.Add(stc);
                    break;
                case "QTY":
                    if (loopName == "2000B")
                    {
                        if (segments[1] == "90") processingFile.TotalAcceptedQuantity = segments[2];
                        if (segments[1] == "AA") processingFile.TotalRejectedQuantity = segments[2];
                    }
                    else if (loopName == "2000C")
                    {
                        if (segments[1] == "QA") billProvs.Last().BillProvAcceptedQuantity = segments[2];
                        if (segments[1] == "QC") billProvs.Last().BillProvRejectedQuantity = segments[2];
                    }

                    break;
                case "AMT":
                    if (loopName == "2000B")
                    {
                        if (segments[1] == "YU") processingFile.TotalAcceptedAmount = segments[2];
                        if (segments[1] == "YY") processingFile.TotalRejectedAmount = segments[2];
                    }
                    else if (loopName == "2000C")
                    {
                        if (segments[1] == "YU") billProvs.Last().BillProvAcceptedAmount = segments[2];
                        if (segments[1] == "YY") billProvs.Last().BillProvRejectedAmount = segments[2];
                    }

                    break;
                case "NM1":
                    if (loopName == "2000C")
                    {
                        _277CABillProv billProv = new _277CABillProv()
                        {
                            FileId = processingFile.FileId,
                            BillProvName = segments[3],
                            BillProvIdQual = segments[8],
                            BillProvId = segments[9]
                        };
                        billProvs.Add(billProv);
                    }
                    else if (loopName == "2000D")
                    {
                        _277CAPatient patient = new _277CAPatient
                        {
                            FileId = processingFile.FileId,
                            BillProvId = billProvs.Last().BillProvId,
                            PatientLastName = segments[3],
                            PatientFirstName = segments[4],
                            PatientMI = segments[5],
                            PatientIdQual = segments[8],
                            PatientId = segments[9]
                        };
                        patients.Add(patient);
                    }

                    break;
                case "TRN":
                    if (loopName == "2000C" && segments[1] == "1")
                    {
                        billProvs.Last().ClaimId = segments[2];
                    }
                    else if (loopName == "2000D" && segments[1] == "2")
                    {
                        patients.Last().ClaimId = segments[2];
                    }

                    break;
                case "REF":
                    if (loopName == "2000C")
                    {
                        if (string.IsNullOrEmpty(billProvs.Last().BillProvSecondIdQual1))
                        {
                            billProvs.Last().BillProvSecondIdQual1 = segments[1];
                            billProvs.Last().BillProvSecondId1 = segments[2];
                        }
                        else if (string.IsNullOrEmpty(billProvs.Last().BillProvSecondIdQual2))
                        {
                            billProvs.Last().BillProvSecondIdQual2 = segments[1];
                            billProvs.Last().BillProvSecondId2 = segments[2];
                        }
                        else if (string.IsNullOrEmpty(billProvs.Last().BillProvSecondIdQual3))
                        {
                            billProvs.Last().BillProvSecondIdQual3 = segments[1];
                            billProvs.Last().BillProvSecondId3 = segments[2];
                        }
                    }
                    else if (loopName == "2000D")
                    {
                        switch (segments[1])
                        {
                            case "1K":
                                patients.Last().PayerClaimControlNumber = segments[2];
                                break;
                            case "D9":
                                patients.Last().ClearingHouseTraceNumber = segments[2];
                                break;
                            case "BLT":
                                patients.Last().BillType = segments[2];
                                break;
                        }
                    }
                    else if (loopName == "2220D")
                    {
                        if (segments[1] == "FJ")
                        {
                            lines.Last().LineItemControlNumber = segments[2];
                        }
                    }

                    break;
                case "DTP":
                    if (loopName == "2000D")
                    {
                        if (segments[1] == "472")
                        {
                            if (segments[2] == "RD8")
                            {
                                patients.Last().ServiceDateFrom = segments[3].Split('-')[0];
                                patients.Last().ServiceDateTo = segments[3].Split('-')[1];
                            }
                            else if (segments[2] == "D8")
                            {
                                patients.Last().ServiceDateFrom = segments[3];
                            }
                        }
                    }
                    else if (loopName == "2220D")
                    {
                        if (segments[1] == "472")
                        {
                            if (segments[2] == "RD8")
                            {
                                lines.Last().ServiceDateFrom = segments[3].Split('-')[0];
                                lines.Last().ServiceDateTo = segments[3].Split('-')[1];
                            }
                            else if (segments[2] == "D8")
                            {
                                lines.Last().ServiceDateFrom = segments[3];
                            }
                        }
                    }

                    break;
                case "SVC":
                    loopName = "2220D";
                    string[] tempArray = segments[1].Split(elementDelimiter);
                    _277CALine line2 = new _277CALine
                    {
                        FileId = processingFile.FileId,
                        ClaimId = patients.Last().ClaimId,
                        ProcedureQual = tempArray[0],
                        ProcedureCode = tempArray[1],
                        Modifier1 = tempArray.Length > 2 ? tempArray[2] : null,
                        Modifier2 = tempArray.Length > 3 ? tempArray[3] : null,
                        Modifier3 = tempArray.Length > 4 ? tempArray[4] : null,
                        Modifier4 = tempArray.Length > 5 ? tempArray[5] : null,
                        LineChargeAmount = segments[2],
                        RevenueCode = segments.Length > 4 ? segments[4] : null,
                        UnitCount = segments.Length > 7 ? segments[7] : null
                    };
                    lines.Add(line2);
                    break;
            }
        }
    }
}
