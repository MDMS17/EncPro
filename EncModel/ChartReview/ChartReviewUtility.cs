using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.Meditrac;
using EncModel.X12;

namespace EncModel.ChartReview
{
    public static class ChartReviewUtility
    {
        public static string GetChartReview837PHeader(string flag, ref int SegmentCount, ref string icn)
        {
            StringBuilder sb = new StringBuilder();
            string transactionDate = DateTime.Today.ToString("yyyyMMdd");
            string transactionTime = DateTime.Now.ToString("HHmm");
            icn = (DateTime.Today.DayOfYear + 100).ToString() + DateTime.Now.ToString("HHmmssfff").Substring(1, 6);
            ISA isa = new ISA();
            isa.InterchangeSenderID = "DCA006";
            isa.InterchangeReceiverID = "80889";
            isa.InterchangeDate = transactionDate.Substring(2, 6);
            isa.InterchangeTime = transactionTime;
            isa.InterchangeControlNumber = icn;
            isa.ProductionFlag = flag == "P" ? "P" : "T";
            sb.Append(isa.ToX12String());
            GS gs = new GS();
            gs.FunctionalIDCode = "HC";
            gs.SenderID = "DCA006";
            gs.ReceiverID = "80889";
            gs.TransactionDate = transactionDate;
            gs.TransactrionTime = transactionTime;
            gs.GroupControlNumber = "1";
            gs.ResponsibleAgencyCode = "X";
            gs.VersionID = "005010X222A1";
            sb.Append(gs.ToX12String());
            ST st = new ST();
            st.TransactionControlNumber = "0000001";
            st.VersionNumber = "005010X222A1";
            sb.Append(st.ToX12String());
            SegmentCount++;
            BHT bht = new BHT();
            bht.TransactionID = "0001";
            bht.TransactionDate = transactionDate;
            bht.TransactionTime = transactionTime;
            bht.TransactionTypeCode = "CH";
            sb.Append(bht.ToX12String());
            SegmentCount++;
            NM1 nm1 = new NM1();
            nm1.NameQualifier = "41";
            nm1.NameType = "2";
            nm1.LastName = "IEHP";
            nm1.IDQualifer = "46";
            nm1.IDCode = "DCA006";
            sb.Append(nm1.ToX12String());
            SegmentCount++;
            PER per = new PER();
            PERItem peritem = new PERItem();
            peritem.ContactName = "AUDREY KELLEY";
            peritem.Phone = "9513743376";
            peritem.Email = "KELLEY-A@IEHP.ORG";
            per.Pers.Add(peritem);
            sb.Append(per.ToX12String());
            SegmentCount++;
            nm1 = new NM1();
            nm1.NameQualifier = "40";
            nm1.NameType = "2";
            nm1.LastName = "EDSCMS";
            nm1.IDQualifer = "46";
            nm1.IDCode = "80889";
            sb.Append(nm1.ToX12String());
            SegmentCount++;

            return sb.ToString();
        }

        public static string GetChartReview837PTrailer(ref int SegmentCount, ref string icn)
        {
            StringBuilder sb = new StringBuilder();
            SE se = new SE();
            SegmentCount++;
            se.SegmentCount = SegmentCount.ToString();
            se.TransactionControlNumber = "0000001";
            sb.Append(se.ToX12String());
            GE ge = new GE();
            ge.GroupControlNumber = "1";
            ge.NumberofTransactionSets = "1";
            sb.Append(ge.ToX12String());
            IEA iea = new IEA();
            iea.NumberofFunctionalGroups = "1";
            iea.InterchangeControlNumber = icn;
            sb.Append(iea.ToX12String());
            return sb.ToString();
        }

        public static string GetChartReview837PClaimSegments(string ClaimId, ChartReviewRecord record, ref int SegmentCount, ref int HLID, ref int HL_Subscriber_Parent_ID)
        {
            StringBuilder sb = new StringBuilder();
            List<ChartReviewData> result;
            using (var context = new MeditracContext())
            {
                result = context.Database.SqlQuery<ChartReviewData>($"select top 1 ProviderLastName as LastName,ProviderFirstName as FistName,OfficeAddress1 as Address,OfficeAddress2 as Address2,OfficeCity as City,officestate as State,OfficeZip as Zip,CorporationEIN as LastItem from hsp_supplemental.meditrac.providerdata where providernpi='{record.ProviderNPI}' union all select top 1 LastName,FirstName,Address1 as Address,Address2,city,State,Zip,Gender as LastItem from hsp_supplemental.meditrac.providerdata where hicn='{record.MemberHICN}'").ToList();
                HL hl = new HL();
                hl.LoopName = "2000A";
                hl.HLID = HLID.ToString();
                HL_Subscriber_Parent_ID = HLID;
                HLID++;
                hl.LevelCode = "20";
                hl.ChildCode = "1";
                sb.Append(hl.ToX12String());
                SegmentCount++;
                NM1 nm1 = new NM1();
                nm1.NameQualifier = "85";
                nm1.NameType = string.IsNullOrEmpty(result[0].FirstName) ? "2" : "1";
                nm1.LastName = result[0].LastName;
                nm1.FirstName = result[0].FirstName;
                nm1.IDQualifer = "XX";
                nm1.IDCode = record.ProviderNPI;
                sb.Append(nm1.ToX12String());
                SegmentCount++;
                N3 n3 = new N3();
                n3.Address = result[0].Address;
                n3.Address2 = result[0].Address2;
                sb.Append(n3.ToX12String());
                SegmentCount++;
                N4 n4 = new N4();
                n4.City = result[0].City;
                n4.State = result[0].State;
                n4.Zipcode = result[0].Zip;
                sb.Append(n4.ToX12String());
                SegmentCount++;
                REF rref = new REF();
                REFItem refitem = new REFItem();
                refitem.ProviderQualifier = "EI";
                refitem.ProviderID = result[0].LastItem;
                rref.Refs.Add(refitem);
                sb.Append(rref.ToX12String());
                SegmentCount += rref.Refs.Count;
                hl = new HL();
                hl.LoopName = "2000B";
                hl.HLID = HLID.ToString();
                HLID++;
                hl.ParentID = HL_Subscriber_Parent_ID.ToString();
                hl.LevelCode = "22";
                hl.ChildCode = "0";
                sb.Append(hl.ToX12String());
                SegmentCount++;
                SBR sbr = new SBR();
                sbr.SubscriberSequenceNumber = "P";
                sbr.SubscriberRelationshipCode = "18";
                sbr.OtherInsuredGroupName = "CMC";
                sbr.ClaimFilingCode = "MB";
                sb.Append(sbr.ToX12String());
                SegmentCount++;
                nm1 = new NM1();
                nm1.NameQualifier = "IL";
                nm1.NameType = string.IsNullOrEmpty(result[1].FirstName) ? "2" : "1";
                nm1.LastName = result[1].LastName;
                nm1.FirstName = result[1].FirstName;
                nm1.IDQualifer = "MI";
                nm1.IDCode = record.MemberHICN;
                sb.Append(nm1.ToX12String());
                SegmentCount++;
                if (!string.IsNullOrEmpty(result[1].Address))
                {
                    n3 = new N3();
                    n3.Address = result[1].Address;
                    n3.Address2 = result[1].Address2;
                    sb.Append(n3.ToX12String());
                    SegmentCount++;
                }
                if (!string.IsNullOrEmpty(result[1].City))
                {
                    n4 = new N4();
                    n4.City = result[1].City;
                    n4.State = result[1].State;
                    n4.Zipcode = result[1].Zip;
                    sb.Append(n4.ToX12String());
                    SegmentCount++;
                }
                if (!string.IsNullOrEmpty(record.MemberDOB) && !string.IsNullOrEmpty(result[1].LastItem))
                {
                    DMG dmg = new DMG();
                    dmg.BirthDate = record.MemberDOB;
                    dmg.Gender = result[1].LastItem;
                    sb.Append(dmg.ToX12String());
                    SegmentCount++;
                }
                nm1 = new NM1();
                nm1.NameQualifier = "PR";
                nm1.NameType = "2";
                nm1.LastName = "CMC";
                nm1.IDQualifer = "PI";
                nm1.IDCode = "80889";
                sb.Append(nm1.ToX12String());
                SegmentCount++;
                rref = new REF();
                refitem = new REFItem();
                refitem.ProviderQualifier = "2U";
                refitem.ProviderID = "H5355";
                rref.Refs.Add(refitem);
                refitem = new REFItem();
                refitem.ProviderQualifier = "G2";
                refitem.ProviderID = "H5355";
                rref.Refs.Add(refitem);
                sb.Append(rref.ToX12String());
                SegmentCount += rref.Refs.Count;

                CLM_P clm = new CLM_P();
                clm.ClaimID = ClaimId;
                clm.ClaimAmount = "0";
                clm.ClaimPOS = "11";
                clm.ClaimType = "B";
                clm.ClaimFrequencyCode = "1";
                clm.ClaimProviderSignature = "Y";
                clm.ClaimProviderAssignment = "A";
                clm.ClaimBenefitAssignment = "Y";
                clm.ClaimReleaseofInformationCode = "Y";
                clm.ClaimPatientSignatureSourceCode = "P";
                sb.Append(clm.ToX12String());
                SegmentCount++;
                PWK pwk = new PWK();
                PWKItem pwkitem = new PWKItem();
                if (record.DeleteIndicator == "D")
                {
                    pwkitem.ReportTypeCode = "EA";
                    pwkitem.ReportTransmissionCode = "8";
                }
                else
                {
                    pwkitem.ReportTypeCode = "09";
                    pwkitem.ReportTransmissionCode = "AA";
                }
                pwk.Pwks.Add(pwkitem);
                sb.Append(pwk.ToX12String());
                SegmentCount += pwk.Pwks.Count;
                HI_P hip = new HI_P();
                HIItem hiitem = new HIItem();
                hiitem.HIQual = "ABK";
                hiitem.HICode = record.DiagnosisCode;
                hip.His.Add(hiitem);
                sb.Append(hip.ToX12String());
                SegmentCount += hip.HiCount;
                LX lx = new LX();
                lx.ServiceLineNumber = "1";
                sb.Append(lx.ToX12String());
                SegmentCount++;
                SV1 sv1 = new SV1();
                sv1.ServiceIDQualifier = "HC";
                sv1.ProcedureCode = record.ProcedureCode;
                sv1.LineItemChargeAmount = "0";
                sv1.LineItemUnit = "UN";
                sv1.ServiceUnitQuantity = "1";
                sv1.DiagPointer1 = "1";
                sv1.FamilyPlanningIndicator = "0";
                sb.Append(sv1.ToX12String());
                SegmentCount++;
                DTP dtp = new DTP();
                dtp.DateCode = "472";
                dtp.DateQualifier = string.IsNullOrEmpty(record.DosToDate) ? "D8" : "RD8";
                dtp.StartDate = record.DosFromDate;
                dtp.EndDate = record.DosToDate;
                sb.Append(dtp.ToX12String());
                SegmentCount++;
                rref = new REF();
                refitem = new REFItem();
                refitem.ProviderQualifier = "6R";
                refitem.ProviderID = "1";
                rref.Refs.Add(refitem);
                refitem = new REFItem();
                sb.Append(rref.ToX12String());
                SegmentCount += rref.Refs.Count;
                NTE note = new NTE();
                note.NoteCode = "ADD";
                note.NoteText = "RP";
                sb.Append(note.ToX12String());
                SegmentCount++;

            }
            return sb.ToString();
        }
        public static string GetChartReview837IHeader(string flag, ref int SegmentCount, ref string icn)
        {
            StringBuilder sb = new StringBuilder();
            string transactionDate = DateTime.Today.ToString("yyyyMMdd");
            string transactionTime = DateTime.Now.ToString("HHmm");
            icn = (DateTime.Today.DayOfYear + 100).ToString() + DateTime.Now.ToString("HHmmssfff").Substring(1, 6);
            ISA isa = new ISA();
            isa.InterchangeSenderID = "DCA006";
            isa.InterchangeReceiverID = "80888";
            isa.InterchangeDate = transactionDate.Substring(2, 6);
            isa.InterchangeTime = transactionTime;
            isa.InterchangeControlNumber = icn;
            isa.ProductionFlag = flag == "P" ? "P" : "T";
            sb.Append(isa.ToX12String());
            GS gs = new GS();
            gs.FunctionalIDCode = "HC";
            gs.SenderID = "DCA006";
            gs.ReceiverID = "80888";
            gs.TransactionDate = transactionDate;
            gs.TransactrionTime = transactionTime + "00";
            gs.GroupControlNumber = "1";
            gs.ResponsibleAgencyCode = "X";
            gs.VersionID = "005010X223A2";
            sb.Append(gs.ToX12String());
            ST st = new ST();
            st.TransactionControlNumber = "0000001";
            st.VersionNumber = "005010X223A2";
            sb.Append(st.ToX12String());
            SegmentCount++;
            BHT bht = new BHT();
            bht.TransactionID = transactionDate + transactionTime;
            bht.TransactionDate = transactionDate;
            bht.TransactionTime = transactionTime;
            bht.TransactionTypeCode = "CH";
            sb.Append(bht.ToX12String());
            SegmentCount++;
            NM1 nm1 = new NM1();
            nm1.NameQualifier = "41";
            nm1.NameType = "2";
            nm1.LastName = "IEHP";
            nm1.IDQualifer = "46";
            nm1.IDCode = "DCA006";
            sb.Append(nm1.ToX12String());
            SegmentCount++;
            PER per = new PER();
            PERItem peritem = new PERItem();
            peritem.ContactName = "AUDREY KELLEY";
            peritem.Phone = "9513743376";
            peritem.Email = "edisupport@IEHPhealthplan.com";
            per.Pers.Add(peritem);
            sb.Append(per.ToX12String());
            SegmentCount++;
            nm1 = new NM1();
            nm1.NameQualifier = "40";
            nm1.NameType = "2";
            nm1.LastName = "EDSCMS";
            nm1.IDQualifer = "46";
            nm1.IDCode = "80888";
            sb.Append(nm1.ToX12String());
            SegmentCount++;

            return sb.ToString();
        }
        public static string GetChartReview837ITrailer(ref int SegmentCount, ref string icn)
        {
            StringBuilder sb = new StringBuilder();
            SE se = new SE();
            SegmentCount++;
            se.SegmentCount = SegmentCount.ToString();
            se.TransactionControlNumber = "0000001";
            sb.Append(se.ToX12String());
            GE ge = new GE();
            ge.GroupControlNumber = "1";
            ge.NumberofTransactionSets = "1";
            sb.Append(ge.ToX12String());
            IEA iea = new IEA();
            iea.NumberofFunctionalGroups = "1";
            iea.InterchangeControlNumber = icn;
            sb.Append(iea.ToX12String());

            return sb.ToString();
        }
        public static string GetChartReview837IClaimSegments(string ClaimId, ChartReviewRecord record, ref int SegmentCount, ref int HLID, ref int HL_Subscriber_Parent_ID)
        {
            StringBuilder sb = new StringBuilder();
            List<ChartReviewData> result;
            using (var context = new MeditracContext())
            {
                result = context.Database.SqlQuery<ChartReviewData>($"select top 1 ProviderLastName as LastName,ProviderFirstName as FistName,OfficeAddress1 as Address,OfficeAddress2 as Address2,OfficeCity as City,officestate as State,OfficeZip as Zip,CorporationEIN as LastItem from hsp_supplemental.meditrac.providerdata where providernpi='{record.ProviderNPI}' union all select top 1 LastName,FirstName,Address1 as Address,Address2,city,State,Zip,Gender as LastItem from hsp_supplemental.meditrac.providerdata where hicn='{record.MemberHICN}'").ToList();
                HL hl = new HL();
                hl.LoopName = "2000A";
                hl.HLID = HLID.ToString();
                HL_Subscriber_Parent_ID = HLID;
                HLID++;
                hl.LevelCode = "20";
                hl.ChildCode = "1";
                sb.Append(hl.ToX12String());
                SegmentCount++;
                NM1 nm1 = new NM1();
                nm1.NameQualifier = "85";
                nm1.NameType = string.IsNullOrEmpty(result[0].FirstName) ? "2" : "1";
                nm1.LastName = result[0].LastName;
                nm1.FirstName = result[0].FirstName;
                nm1.IDQualifer = "XX";
                nm1.IDCode = record.ProviderNPI;
                sb.Append(nm1.ToX12String());
                SegmentCount++;
                N3 n3 = new N3();
                n3.Address = result[0].Address;
                n3.Address2 = result[0].Address2;
                sb.Append(n3.ToX12String());
                SegmentCount++;
                N4 n4 = new N4();
                n4.City = result[0].City;
                n4.State = result[0].State;
                n4.Zipcode = result[0].Zip;
                sb.Append(n4.ToX12String());
                SegmentCount++;
                REF rref = new REF();
                REFItem refitem = new REFItem();
                refitem.ProviderQualifier = "EI";
                refitem.ProviderID = result[0].LastItem;
                rref.Refs.Add(refitem);
                sb.Append(rref.ToX12String());
                SegmentCount += rref.Refs.Count;
                hl = new HL();
                hl.LoopName = "2000B";
                hl.HLID = HLID.ToString();
                HLID++;
                hl.ParentID = HL_Subscriber_Parent_ID.ToString();
                hl.LevelCode = "22";
                hl.ChildCode = "0";
                sb.Append(hl.ToX12String());
                SegmentCount++;
                SBR sbr = new SBR();
                sbr.SubscriberSequenceNumber = "P";
                sbr.SubscriberRelationshipCode = "18";
                sbr.OtherInsuredGroupName = "CMC";
                sbr.ClaimFilingCode = "MA";
                sb.Append(sbr.ToX12String());
                SegmentCount++;
                nm1 = new NM1();
                nm1.NameQualifier = "IL";
                nm1.NameType = string.IsNullOrEmpty(result[1].FirstName) ? "2" : "1";
                nm1.LastName = result[1].LastName;
                nm1.FirstName = result[1].FirstName;
                nm1.IDQualifer = "MI";
                nm1.IDCode = record.MemberHICN;
                sb.Append(nm1.ToX12String());
                SegmentCount++;
                if (!string.IsNullOrEmpty(result[1].Address))
                {
                    n3 = new N3();
                    n3.Address = result[1].Address;
                    n3.Address2 = result[1].Address2;
                    sb.Append(n3.ToX12String());
                    SegmentCount++;
                }
                if (!string.IsNullOrEmpty(result[1].City))
                {
                    n4 = new N4();
                    n4.City = result[1].City;
                    n4.State = result[1].State;
                    n4.Zipcode = result[1].Zip;
                    sb.Append(n4.ToX12String());
                    SegmentCount++;
                }
                if (!string.IsNullOrEmpty(record.MemberDOB) && !string.IsNullOrEmpty(result[1].LastItem))
                {
                    DMG dmg = new DMG();
                    dmg.BirthDate = record.MemberDOB;
                    dmg.Gender = result[1].LastItem;
                    sb.Append(dmg.ToX12String());
                    SegmentCount++;
                }
                nm1 = new NM1();
                nm1.NameQualifier = "PR";
                nm1.NameType = "2";
                nm1.LastName = "CMC";
                nm1.IDQualifer = "PI";
                nm1.IDCode = "80889";
                sb.Append(nm1.ToX12String());
                SegmentCount++;
                rref = new REF();
                refitem = new REFItem();
                refitem.ProviderQualifier = "2U";
                refitem.ProviderID = "H5355";
                rref.Refs.Add(refitem);
                refitem = new REFItem();
                refitem.ProviderQualifier = "G2";
                refitem.ProviderID = "H5355";
                rref.Refs.Add(refitem);
                sb.Append(rref.ToX12String());
                SegmentCount += rref.Refs.Count;

                CLM_I clm = new CLM_I();
                clm.ClaimID = ClaimId;
                clm.ClaimAmount = "0";
                clm.ClaimPOS = "11";
                clm.ClaimType = "A";
                clm.ClaimFrequencyCode = "1";
                clm.ClaimProviderAssignment = "A";
                clm.ClaimBenefitAssignment = "Y";
                clm.ClaimReleaseofInformationCode = "Y";
                sb.Append(clm.ToX12String());
                SegmentCount++;
                PWK pwk = new PWK();
                PWKItem pwkitem = new PWKItem();
                if (record.DeleteIndicator == "D")
                {
                    pwkitem.ReportTypeCode = "EA";
                    pwkitem.ReportTransmissionCode = "8";
                }
                else
                {
                    pwkitem.ReportTypeCode = "09";
                    pwkitem.ReportTransmissionCode = "AA";
                }
                pwk.Pwks.Add(pwkitem);
                sb.Append(pwk.ToX12String());
                SegmentCount += pwk.Pwks.Count;
                HI_I hii = new HI_I();
                HIItem hiitem = new HIItem();
                hiitem.HIQual = "ABK";
                hiitem.HICode = record.DiagnosisCode;
                hii.His.Add(hiitem);
                sb.Append(hii.ToX12String());
                SegmentCount += hii.HiCounts;
                LX lx = new LX();
                lx.ServiceLineNumber = "1";
                sb.Append(lx.ToX12String());
                SegmentCount++;
                SV2 sv2 = new SV2();
                sv2.RevenueCode = record.RevenueCode;
                sv2.LineItemChargeAmount = "0";
                sv2.LineItemUnit = "UN";
                sv2.ServiceUnitQuantity = "1";
                sb.Append(sv2.ToX12String());
                SegmentCount++;
                DTP dtp = new DTP();
                dtp.DateCode = "472";
                dtp.DateQualifier = string.IsNullOrEmpty(record.DosToDate) ? "D8" : "RD8";
                dtp.StartDate = record.DosFromDate;
                dtp.EndDate = record.DosToDate;
                sb.Append(dtp.ToX12String());
                SegmentCount++;
                rref = new REF();
                refitem = new REFItem();
                refitem.ProviderQualifier = "6R";
                refitem.ProviderID = "1";
                rref.Refs.Add(refitem);
                refitem = new REFItem();
                sb.Append(rref.ToX12String());
                SegmentCount += rref.Refs.Count;
                NTE note = new NTE();
                note.NoteCode = "ADD";
                note.NoteText = "RP";
                sb.Append(note.ToX12String());
                SegmentCount++;
            }

            return sb.ToString();
        }
    }
}
