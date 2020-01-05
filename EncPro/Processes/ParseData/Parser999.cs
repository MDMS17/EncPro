using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel._999;

namespace EncPro.ParseData
{
    public static partial class Parser
    {
        public static void Parser999Line(string line, ref _999File processingFile, ref List<_999Transaction> transactions,
            ref List<_999Error> errors, ref List<_999Element> elements, ref string loopName)
        {
            string[] segments = line.Split('*');
            switch (segments[0])
            {
                case "AK2":
                    loopName = "2000";
                    _999Transaction transaction = new _999Transaction
                    {
                        FileId = processingFile.FileId,
                        TransactionControlNumber = segments[2]
                    };
                    transactions.Add(transaction);
                    break;
                case "IK3":
                    loopName = "2100";
                    _999Error error = new _999Error
                    {
                        FileId = processingFile.FileId,
                        TransactionControlNumber = transactions.Last().TransactionControlNumber,
                        SegmentCode = segments[1],
                        PositionInTransaction = segments[2],
                        LoopCode = segments[3],
                        ErrorCode = segments[4]
                    };
                    errors.Add(error);
                    break;
                case "IK4":
                    loopName = "2110";
                    _999Element element = new _999Element
                    {
                        FileId = processingFile.FileId,
                        TransactionControlNumber = transactions.Last().TransactionControlNumber,
                        PositionInTransaction = errors.Last().PositionInTransaction,
                        PositionInSegment = segments[1],
                        ElementReferenceInSegment = segments[2],
                        ElementErrorCode = segments[3],
                        ElementBadDataCopy = segments[4]
                    };
                    elements.Add(element);
                    break;
                case "CTX":
                    if (loopName == "2100")
                    {
                        if (segments[1] != "SITUATIONAL TRIGGER")
                        {
                            errors.Last().BusinessUnitName = segments[1].Split(':')[0];
                            errors.Last().BusinessUnitCode = segments[1].Split(':')[1];
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(errors.Last().CtxSegmentCode))
                            {
                                _999Error error2 = new _999Error
                                {
                                    FileId = processingFile.FileId,
                                    TransactionControlNumber = transactions.Last().TransactionControlNumber,
                                    SegmentCode = errors[errors.Count - 2].SegmentCode,
                                    PositionInTransaction = errors[errors.Count - 2].PositionInTransaction,
                                    LoopCode = errors[errors.Count - 2].LoopCode,
                                    ErrorCode = errors[errors.Count - 2].ErrorCode,
                                    CtxSegmentCode = segments[2],
                                    CtxPositionInTransaction = segments[3],
                                    CtxLoopCode = segments.Length > 4 ? segments[4] : null,
                                    CtxPositionInSegment = segments.Length > 5 ? segments[5] : null,
                                    CtxReferenceInSegment = segments.Length > 6 ? segments[6] : null
                                };
                                errors.Add(error2);
                            }
                            else
                            {
                                errors.Last().CtxSegmentCode = segments[2];
                                errors.Last().CtxPositionInTransaction = segments[3];
                                if (segments.Length > 4) errors.Last().CtxLoopCode = segments[4];
                                if (segments.Length > 5) errors.Last().CtxPositionInSegment = segments[5];
                                if (segments.Length > 6) errors.Last().CtxReferenceInSegment = segments[6];
                            }
                        }
                    }
                    else if (loopName == "2110")
                    {
                        if (!string.IsNullOrEmpty(elements.Last().ElementSegmentCode))
                        {
                            _999Element element2 = new _999Element
                            {
                                FileId = processingFile.FileId,
                                TransactionControlNumber = transactions.Last().TransactionControlNumber,
                                PositionInTransaction = errors.Last().PositionInTransaction,
                                PositionInSegment = elements.Last().PositionInSegment,
                                ElementReferenceInSegment = elements.Last().ElementReferenceInSegment,
                                ElementErrorCode = elements.Last().ElementErrorCode,
                                ElementBadDataCopy = elements.Last().ElementBadDataCopy,
                                ElementSegmentCode = segments[2],
                                ElementSegmentPositionInTransaction = segments[3],
                                ElementLoopCode = segments.Length > 4 ? segments[4] : null,
                                ElementPositionInSegment = segments.Length > 5 ? segments[5] : null,
                                ElementReferenceNumber = segments.Length > 6 ? segments[6] : null
                            };
                            elements.Add(element2);
                        }
                        else
                        {
                            elements.Last().ElementSegmentCode = segments[2];
                            elements.Last().ElementSegmentPositionInTransaction = segments[3];
                            if (segments.Length > 4) elements.Last().ElementLoopCode = segments[4];
                            if (segments.Length > 5) elements.Last().ElementPositionInSegment = segments[5];
                            if (segments.Length > 6) elements.Last().ElementReferenceInSegment = segments[6];
                        }
                    }

                    break;
                case "IK5":
                    transactions.Last().TransactionAckCode = segments[1];
                    if (segments.Length > 2) transactions.Last().TransactionError1 = segments[2];
                    if (segments.Length > 3) transactions.Last().TransactionError2 = segments[3];
                    if (segments.Length > 4) transactions.Last().TransactionError3 = segments[4];
                    if (segments.Length > 5) transactions.Last().TransactionError4 = segments[5];
                    if (segments.Length > 6) transactions.Last().TransactionError5 = segments[6];
                    break;
                case "AK9":
                    processingFile.FileAckCode = segments[1];
                    processingFile.TransactionsIncluded = segments[2];
                    processingFile.TransactionsReceived = segments[3];
                    processingFile.TransactionsAccepted = segments[4];
                    if (segments.Length > 5) processingFile.FileError1 = segments[5];
                    if (segments.Length > 6) processingFile.FileError2 = segments[6];
                    if (segments.Length > 7) processingFile.FileError3 = segments[7];
                    if (segments.Length > 8) processingFile.FileError4 = segments[8];
                    if (segments.Length > 9) processingFile.FileError5 = segments[9];
                    break;
            }
        }
    }
}
