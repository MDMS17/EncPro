using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.Misc;

namespace EncModel.Meditrac
{
    public class MeditracUtility
    {
        public static async Task<int> GetMeditracCounts(string GroupNumbers, string ClaimType, string StartDate, string EndDate, string StatusCodes)
        {
            object result = 0;
            using (var context = new MeditracContext())
            {
                context.Database.CommandTimeout = 1800;
                //result = await context.Database.SqlQuery<int>("select count(*) from claims (nolock) a inner join groups (nolock) b on a.GroupId=b.GroupId cross apply (select top 1 DateCreated from records r1 inner join checks r2 on r1.CheckId=r2.CheckId where r1.ReferenceNumber=a.ClaimId order by recordid desc) r3  where a.ProcessingStatus='CLS' and a.Status in (" + StatusCodes + ") and left(b.GroupNumber,3) in ("+GroupNumbers +") and a.FormType='"+ClaimType +"' and r3.DateCreated between '"+StartDate+"' and '"+EndDate +"'").SingleOrDefaultAsync();
                result = await context.Database.SqlQuery<int>("select count(*) from claims (nolock) a inner join groups (nolock) b on a.GroupId=b.GroupId where a.ProcessingStatus='CLS' and a.Status in (" + StatusCodes + ") and left(b.GroupNumber,3) in (" + GroupNumbers + ") and a.FormType='" + ClaimType + "' and a.LastUpdatedAt between '" + StartDate + "' and '" + EndDate + "'").SingleOrDefaultAsync();
            }
            return (int)result;
        }

        public static async Task<List<MeditracHeader>> GetMeditracHeaders(string GroupNumbers, string ClaimType, string StartDate, string EndDate, string StatusCodes, int PageNumber)
        {
            List<MeditracHeader> result = null;
            using (var context = new MeditracContext())
            {
                context.Database.CommandTimeout = 3600;
                StringBuilder sb = new StringBuilder();
                sb.Append("select p1.ProviderSpecialtyPrimaryTaxonomyCode as BillingTaxonomyCode,");
                sb.Append("p1.ProviderLastName as BillingLastName,");
                sb.Append("p1.ProviderFirstName as BillingFirstName,");
                sb.Append("p1.ProviderMiddleInitial as BillingMiddleInitial,");
                sb.Append("p1.ProviderNPI as BillingNPI,");
                sb.Append("p1.OfficeAddress1 as BillingAddress,");
                sb.Append("p1.OfficeAddress2 as BillingAddress2,");
                sb.Append("p1.OfficeCity as BillingCity,");
                sb.Append("p1.OfficeState as BillingState,");
                sb.Append("p1.OfficeZip as BillingZip,");
                sb.Append("p1.CorporationEIN as BillingTaxId,");
                sb.Append("i.ClaimFilingIndicatorCode as ClaimFilingInd,");
                sb.Append("m.LastName as SubscriberLastName,");
                sb.Append("m.FirstName as SubscriberFirstName,");
                sb.Append("m.middlename as SubscriberMiddleInitial,");
                sb.Append("'MI' as SubscriberIdQual,");
                sb.Append("m.Policynumber as CIN,");
                sb.Append("m.HICN,");
                sb.Append("m.Address1 as SubscriberAddress,");
                sb.Append("m.Address2 as SubscriberAddress2,");
                sb.Append("m.City as SubscriberCity,");
                sb.Append("m.State as SubscriberState,");
                sb.Append("m.Zip as SubscriberZip,");
                sb.Append("convert(varchar(8),m.DateOfBirth,112) as SubscriberDateOfBirth,");
                sb.Append("m.Gender as SubscriberGender,");
                sb.Append("a.ClaimId,");
                sb.Append("b.TotalCharges as ChargeAmount,");
                sb.Append("case when a.formtype='HCF' then PlaceOfService else left(b.TypeOfBill,2) end as FacilityCode,");
                sb.Append("case when a.formtype='HCF' then 'B' else 'A' end as ClaimType,");
                sb.Append("case when a.formtype='HCF' then '1' else right(b.TypeOfBill,1) end as ClaimFrequencyCode,");
                sb.Append("ProviderSignature as ProviderSignatureInd,");
                sb.Append("AcceptAssignment as ProviderAssignmentInd,");
                sb.Append("b.AssignmentBenefits as BenefitAssignmentInd,");
                sb.Append("isnull(ReleaseInformation,'Y') as ReleaseOfInformationInd,");
                sb.Append("PatientSignature as PatientSignatureInd,");
                sb.Append("DelayReason as DelayReasonCode,");
                sb.Append("convert(varchar(8),AdmissionDate,112) as AdmissionDate,");
                sb.Append("case when a.status='CLD' then '09' when COBPayerPaidAmount=0 then '05' else '02' end as ContractTypeCode,");
                sb.Append("ContractAmount,");
                sb.Append("PatientLiabilityAmount as PatientPaidAmount,");
                sb.Append("a.ExternalClaimNumber as ExternalClaimId,");
                sb.Append("ClaimSubmissionNumber as MeditracSubmissionNumber,");
                sb.Append("AuthorizationNumber,");
                sb.Append("null as PayerControlNumber,");
                sb.Append("MedicalRecordNumber,");
                sb.Append("p2.ProviderSpecialtyPrimaryTaxonomyCode as ReferringTaxonomyCode,");
                sb.Append("p2.ProviderLastName as ReferringLastName,");
                sb.Append("p2.ProviderFirstName as ReferringFirstName,");
                sb.Append("p2.ProviderMiddleInitial as ReferringMiddleInitial,");
                sb.Append("p2.ProviderNPI as ReferringNPI,");
                sb.Append("p2.OfficeAddress1 as ReferringAddress,");
                sb.Append("p2.OfficeAddress2 as ReferringAddress2,");
                sb.Append("p2.OfficeCity as ReferringCity,");
                sb.Append("p2.OfficeState as ReferringState,");
                sb.Append("p2.OfficeZip as ReferringZip,");
                sb.Append("p2.CorporationEIN as ReferringTaxId,");
                sb.Append("p3.ProviderLastName as RenderingLastName,");
                sb.Append("p3.ProviderFirstName as RenderingFirstName,");
                sb.Append("p3.ProviderMiddleInitial as RenderingMiddleInitial,");
                sb.Append("p3.ProviderMiddleInitial as RenderingNPI,");
                sb.Append("p3.ProviderSpecialtyPrimaryTaxonomyCode as RenderingTaxonomyCode,");
                sb.Append("p3.OfficeAddress1 as RenderingAddress,");
                sb.Append("p3.OfficeAddress2 as RenderingAddress2,");
                sb.Append("p3.OfficeCity as RenderingCity,");
                sb.Append("p3.OfficeState as RenderingState,");
                sb.Append("p3.OfficeZip as RenderingZip,");
                sb.Append("p3.CorporationEIN as RenderingTaxId,");
                sb.Append("d.FacilityName as ServiceFacilityLastName,");
                sb.Append("d.FacilityAddress1 as ServiceFAcilityAddress,");
                sb.Append("d.FacilityAddress2 as ServiceFacilityAddress2,");
                sb.Append("d.FacilityCity as ServiceFacilityCity,");
                sb.Append("d.FacilityState as ServiceFacilityState,");
                sb.Append("d.FacilityZip as ServiceFacilityZip,");
                sb.Append("COBPayerPaidAmount, ");
                sb.Append("COBTotalNonCoveredAmount,");
                sb.Append("amtRemainingPAtientLiability as RemainingPatientLiabilityAmount,");
                sb.Append("DischargeHour,");
                sb.Append("convert(varchar(8),StatementCoversFrom,112) as StatementDateFrom,");
                sb.Append("convert(varchar(8),StatementCoversTo,112) as StatementDateTo,");
                sb.Append("b.TypeOfAdmission as AdmissionTypeCode,");
                sb.Append("b.SourceOfAdmission as AdmissionSourceCode,");
                sb.Append("PatientStatus as PatientStatusCode,");
                sb.Append("p4.ProviderLastName as AttLastName,");
                sb.Append("p4.ProviderFirstName as  AttFirstName,");
                sb.Append("p4.ProviderMiddleInitial as AttMiddleInitial,");
                sb.Append("p4.ProviderNPI as AttNPI,");
                sb.Append("p4.ProviderSpecialtyPrimaryTaxonomyCode as AttTaxonomyCode,");
                sb.Append("p4.OfficeAddress1 as AttAddress,");
                sb.Append("p4.OfficeAddress2 as AttAddress2,");
                sb.Append("p4.OfficeCity as AttCity,");
                sb.Append("p4.OfficeState as AttState,");
                sb.Append("p4.OfficeZip as AttZip,");
                sb.Append("p4.CorporationEIN as AttTaxId,");
                sb.Append("p5.ProviderLastName as OprLastName,");
                sb.Append("p5.ProviderFirstName as OprFirstName,");
                sb.Append("p5.ProviderMiddleInitial as OprMiddleInitial,");
                sb.Append("p5.ProviderNPI as OprNPI,");
                sb.Append("p6.ProviderLastName as OthLastName,");
                sb.Append("p6.ProviderFirstName as OthFirstName,");
                sb.Append("p6.ProviderMiddleInitial as OthMiddleInitial,");
                sb.Append("p6.ProviderNPI as OthNPI,");
                sb.Append("left(c.GroupNumber,3) as GroupNumber,");
                sb.Append("o.MedicaidID ");
                sb.Append("from claims (nolock) a ");
                sb.Append("inner join claim_master (nolock) b on a.claimid=b.claimid and a.AdjustmentVersion=b.AdjustmentVersion ");
                sb.Append("inner join Groups (nolock) c on a.GroupId=c.GroupId ");
                sb.Append("left join claim_master_data (nolock) d on d.claimid=a.claimid and d.AdjustmentVersion=a.AdjustmentVersion ");
                sb.Append("left join claimcobdata (nolock) i on i.claimid=a.claimid and i.AdjustmentVersion=a.AdjustmentVersion ");
                sb.Append("cross apply(select sum(isnull(AmtToPay,0)) as COBPayerPaidAmount,sum(isnull(AmtNotCovered,0)) as COBTotalNonCoveredAmount,sum(isnull(AmtPatientLiability,0)) as PatientLiabilityAmount,sum(isnull(amtEligible,0)) as ContractAmount from claim_results (nolock) where claimid=a.claimid and AdjustmentVersion=a.AdjustmentVersion) j ");
                sb.Append("cross apply(select min(placeofservice) as PlaceOfService from claim_details (nolock) where claimid=a.claimid and AdjustmentVersion=a.AdjustmentVersion) k ");
                sb.Append("outer apply (select top 1 ClaimSubmissionnumber from claimsubmissions (nolock) where claimid=a.claimid and InputAdjustmentVersion=a.AdjustmentVersion order by ClaimSubmissionId desc) l ");
                sb.Append("inner join hsp_supplemental.meditrac.member (nolock) m on m.MemberID=a.MemberId ");
                sb.Append("left join HSP_Supplemental.diamond.Member o on o.MemberNumber=m.MemberNumber ");
                sb.Append("outer apply (select top 1 ProviderSpecialtyPrimaryTaxonomyCode,ProviderLastName,ProviderFirstName,ProviderMiddleInitial,ProviderNPI,CorporationEIN,OfficeAddress1,OfficeAddress2,OfficeCity,OfficeState,OfficeZip from hsp_supplemental.meditrac.providerdata (nolock) where providerid=a.providerid and PanelDescription<>'TRM' order by PanelDescription desc) p1 ");
                sb.Append("outer apply (select top 1 ProviderSpecialtyPrimaryTaxonomyCode,ProviderLastName,ProviderFirstName,ProviderMiddleInitial,ProviderNPI,CorporationEIN,OfficeAddress1,OfficeAddress2,OfficeCity,OfficeState,OfficeZip from hsp_supplemental.meditrac.providerdata (nolock) where ProviderId=b.ReferringProviderId and PanelDescription<>'TRM' order by PanelDescription desc) p2 ");
                sb.Append("outer apply (select top 1 ProviderLastName,ProviderFirstName,ProviderMiddleInitial,ProviderNPI,ProviderSpecialtyPrimaryTaxonomyCode,CorporationEIN,OfficeAddress1,OfficeAddress2,OfficeCity,OfficeState,OfficeZip from hsp_supplemental.meditrac.providerdata (nolock) where providerid=(select top 1 renderingproviderid from Claim_Details where claimid=a.claimid and RenderingProviderId<>a.ProviderId) and PanelDescription<>'TRM' order by PanelDescription desc) p3 ");
                sb.Append("outer apply (select top 1 ProviderLastName,ProviderFirstName,ProviderMiddleInitial,ProviderNPI,ProviderSpecialtyPrimaryTaxonomyCode,CorporationEIN,OfficeAddress1,OfficeAddress2,OfficeCity,OfficeState,OfficeZip from hsp_supplemental.meditrac.providerdata (nolock) where providerid=b.AttendingProviderId and PanelDescription<>'TRM' order by PanelDescription desc) p4 ");
                sb.Append("outer apply (select top 1 ProviderLastName,ProviderFirstName,ProviderMiddleInitial,ProviderNPI from hsp_supplemental.meditrac.providerdata (nolock) where providerid=b.OperatingProviderId and PanelDescription<>'TRM' order by PanelDescription desc) p5 ");
                sb.Append("outer apply (select top 1 ProviderLastName,ProviderFirstName,ProviderMiddleInitial,ProviderNPI from HSP_Supplemental.meditrac.providerdata (nolock) where providerid=b.OtherProviderId and PanelDescription<>'TRM' order by PanelDescription desc) p6 ");
                //sb.Append("cross apply (select top 1 DateCreated from records r1 inner join checks r2 on r1.CheckId=r2.CheckId where r1.ReferenceNumber=a.ClaimId order by recordid desc) r3 ");
                sb.Append("where a.ProcessingStatus='CLS' ");
                sb.Append("and a.Status in (" + StatusCodes + ") ");
                sb.Append("and left(c.GroupNumber,3) in (" + GroupNumbers + ") ");
                sb.Append("and a.FormType='" + ClaimType + "' ");
                //sb.Append("and r3.DateCreated between '"+StartDate+"' and '"+EndDate +"' ");
                sb.Append("and a.LastUpdatedAt between '" + StartDate + "' and '" + EndDate + "' ");
                sb.Append("order by a.claimid offset " + (PageNumber * 10000).ToString() + " rows fetch next 10000 rows only");
                result = await context.Database.SqlQuery<MeditracHeader>(sb.ToString()).ToListAsync();
            }
            return result;

        }
        public static async Task<List<MeditracLine>> GetMeditracLines(string GroupNumbers, string ClaimType, string StartDate, string EndDate, string StatusCodes, int PageNumber)
        {
            List<MeditracLine> result = null;
            using (var context = new MeditracContext())
            {
                context.Database.CommandTimeout = 3600;
                StringBuilder sb = new StringBuilder();
                sb.Append("select d.ClaimId");
                sb.Append(",d.LineNumber");
                sb.Append(",case FormType when 'HCF' then d.ProcedureCode else d.HCPCSRates end as ProcedureCode");
                sb.Append(",d.Modifier as Modifier1");
                sb.Append(",d.Modifier2");
                sb.Append(",d.Modifier3");
                sb.Append(",d.Modifier4");
                sb.Append(",d.Description as ProcedureDescription");
                sb.Append(",e.AmtCharged as LineChargeAmount");
                sb.Append(",d.UnitType as UnitOfMeasure");
                sb.Append(",d.ServiceUnits as Quantity");
                sb.Append(",d.PlaceOfService");
                sb.Append(",d.DiagnosisPtr1");
                sb.Append(",d.DiagnosisPtr2");
                sb.Append(",d.DiagnosisPtr3");
                sb.Append(",d.DiagnosisPtr4");
                sb.Append(",d.EMG as EmergencyInd");
                sb.Append(",d.EPSDTPlan as EDSDTInd");
                sb.Append(",convert(varchar(8),d.ServiceDateFrom,112) as ServiceDateFrom");
                sb.Append(",convert(varchar(8),d.ServiceDateTo,112) as ServiceDateTo");
                sb.Append(",d.ProductCode as NationalDrugCode");
                sb.Append(",d.ProductQuantity as DrugQuantity");
                sb.Append(",d.ProductUnitOfMeasure as DrugUnit");
                sb.Append(",e.AmtToPay as LinePaidAmount");
                sb.Append(",convert(varchar(8),e.LastUpdatedAt,112) as PaidDate");
                sb.Append(",e.AmtDeductible as LineDeductAmount");
                sb.Append(",e.AmtCoinsurance as LineCoinsuranceAmount");
                sb.Append(",e.AmtCopay as LineCopayAmount");
                sb.Append(",e.AmtCOB as LineCOBPaidAmount");
                sb.Append(",d.ProcedureCode as RevenueCode ");
                sb.Append("from  claim_details (nolock) d ");
                sb.Append("inner join claim_results (nolock) e on e.claimid=d.claimid and e.AdjustmentVersion=d.AdjustmentVersion and e.LineNumber=d.LineNumber ");
                sb.Append("left join ClaimCOBDataDetails (nolock) f on f.ClaimID=d.ClaimID and f.AdjustmentVersion=d.AdjustmentVersion and f.LineNumber=d.LineNumber ");
                sb.Append("inner join (select claimid,adjustmentversion,FormType from claims (nolock) a inner join groups (nolock) c on a.groupid=c.groupid ");
                //sb.Append("cross apply (select top 1 DateCreated from records r1 inner join checks r2 on r1.CheckId=r2.CheckId where r1.ReferenceNumber=a.ClaimId order by recordid desc) r3 ");
                sb.Append("where a.ProcessingStatus='CLS' ");
                sb.Append("and a.Status in (" + StatusCodes + ") ");
                sb.Append("and left(c.GroupNumber,3) in (" + GroupNumbers + ") ");
                sb.Append("and a.FormType='" + ClaimType + "' ");
                //sb.Append("and r3.DateCreated between '" + StartDate+"' and '"+EndDate+"' ");
                sb.Append("and a.LastUpdatedAt between '" + StartDate + "' and '" + EndDate + "' ");
                sb.Append("order by a.claimid offset " + (PageNumber * 10000).ToString() + " rows fetch next 10000 rows only");
                sb.Append(") t on t.claimid=d.ClaimID and t.AdjustmentVersion=d.AdjustmentVersion");
                result = await context.Database.SqlQuery<MeditracLine>(sb.ToString()).ToListAsync();
            }
            return result;
        }
        public static async Task<List<MeditracCode>> GetMeditracCodes(string GroupNumbers, string ClaimType, string StartDate, string EndDate, string StatusCodes, int PageNumber)
        {
            List<MeditracCode> result = null;
            using (var context = new MeditracContext())
            {
                context.Database.CommandTimeout = 3600;
                StringBuilder sb = new StringBuilder();
                sb.Append("select b.ClaimId,Sequence,CodeType,Code,convert(varchar(8),daterecorded,112) as DateRecorded,convert(varchar(8),datethrough,112) as DateThrough,Amount,DiagnosisCodeQualifier, POAIndicator ");
                sb.Append("from Claim_Codes (nolock) b ");
                sb.Append("inner join (select claimid,adjustmentversion from claims (nolock) a inner join groups (nolock) c on a.groupid=c.groupid ");
                //sb.Append("cross apply (select top 1 DateCreated from records r1 inner join checks r2 on r1.CheckId=r2.CheckId where r1.ReferenceNumber=a.ClaimId order by recordid desc) r3 ");
                sb.Append("where a.ProcessingStatus='CLS' ");
                sb.Append("and a.Status in (" + StatusCodes + ") ");
                sb.Append("and left(c.GroupNumber,3) in (" + GroupNumbers + ") ");
                sb.Append("and a.FormType='" + ClaimType + "' ");
                //sb.Append("and r3.DateCreated between '" + StartDate + "' and '" + EndDate + "' ");
                sb.Append("and a.LastUpdatedAt between '" + StartDate + "' and '" + EndDate + "' ");
                sb.Append("order by a.claimid offset " + (PageNumber * 10000).ToString() + " rows fetch next 10000 rows only");
                sb.Append(") t on t.claimid=b.ClaimID and t.AdjustmentVersion=b.AdjustmentVersion");
                result = await context.Database.SqlQuery<MeditracCode>(sb.ToString()).ToListAsync();
            }
            return result;
        }
        public static async Task<List<MemberDetail>> GetMemberDetails(string memberNumber, string ServiceDate)
        {
            List<MemberDetail> result = null;
            using (var context = new MeditracContext())
            {
                result = await context.Database.SqlQuery<MemberDetail>($"HSP_Supplemental.Meditrac.usp_GetMemberDetailsForEDPS @MemberIdentifier='{memberNumber }',@DateOfService='{ServiceDate }'").ToListAsync();
            }
            return result;
        }
        public static async Task<List<MemberDetail>> GetMemberDetailsByBatch(string MemberNumber, string ServiceDate)
        {
            List<MemberDetail> result = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(";with cte as (");
            sb.Append("select c1.MemberId,c1.MemberNumber,c1.Gender,c2.GroupNumber,c1.HICN,c3.MedicaidID,c1.PolicyNumber,c1.MBI,c1.DateOfBirth,c2.EffectiveDate,c2.ExpirationDate,c1.SocialSecurityNumber ");
            sb.Append("from meditrac.member c1 ");
            sb.Append("cross apply(select top 1 * from meditrac.MemberBenefitCoverage where memberid=c1.memberid order by groupnumber desc) c2 ");
            sb.Append("left join diamond.member c3 on c3.membernumber=c1.membernumber)");
            sb.Append("select left(isnull(coalesce(m1.membernumber,m2.membernumber,m3.membernumber),isnull(m4.membernumber,m5.membernumber)),12) as SubNumber,");
            sb.Append("right(isnull(coalesce(m1.membernumber,m2.membernumber,m3.membernumber),isnull(m4.membernumber,m5.membernumber)),2) as PersNumber,");
            sb.Append("isnull(coalesce(m1.Gender,m2.Gender,m3.Gender),isnull(m4.Gender,m5.Gender)) as Gender,");
            sb.Append("CASE WHEN (LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) = 'H53') THEN 'CMC' ");
            sb.Append("WHEN (LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) = '305') THEN 'MED' ");
            sb.Append("WHEN (LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) = '306') THEN 'MED' ");
            sb.Append("WHEN (LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) = '810') THEN 'CCI' ");
            sb.Append("WHEN (LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) = '812') THEN 'CCI' ");
            sb.Append("ELSE 'EXX' END AS LineOfBusiness,");
            sb.Append("left(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)),3) as HCP,");
            sb.Append("isnull(coalesce(m1.hicn,m2.hicn,m3.hicn),isnull(m4.hicn,m5.hicn)) as HIC,");
            sb.Append("isnull(coalesce(m1.MedicaidID,m3.medicaidid,m3.medicaidid),isnull(m4.MedicaidID,m5.MedicaidID)) as MedsId,");
            sb.Append("case WHEN LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) IN ('305', '810') THEN '33' ");
            sb.Append("WHEN LEFT(isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)), 3) IN ('306', '812') THEN '36' ");
            sb.Append("ELSE NULL END AS FacilityCounty,");
            sb.Append("left(isnull(coalesce(m1.policynumber,m2.policynumber,m3.policynumber),isnull(m4.policynumber,m5.policynumber)),9) as CIN,");
            sb.Append("isnull(coalesce(m1.MBI,m2.mbi,m3.mbi),isnull(m4.mbi,m5.mbi)) as MBI,");
            sb.Append("isnull(coalesce(m1.DateOfBirth,m2.dateofbirth,m3.dateofbirth),isnull(m4.dateofbirth,m5.dateofbirth)) as DateOfBirth,");
            sb.Append("isnull(coalesce(m1.GroupNumber,m2.groupnumber,m3.groupnumber),isnull(m4.groupnumber,m5.groupnumber)) as GroupNumber");
            sb.Append("from (select @MemberNumber as MemberNumber,@ServiceDate as ServiceDate)y ");
            sb.Append("left join cte m1 on LEFT(m1.MemberNumber, 12) = LEFT(y.MemberNumber, 12) AND y.ServiceDate BETWEEN m1.EffectiveDate AND m1.ExpirationDate ");
            sb.Append("left join cte m2 on LEFT(m2.PolicyNumber, 9) = LEFT(y.MemberNumber, 9) AND y.ServiceDate BETWEEN m2.EffectiveDate AND m2.ExpirationDate ");
            sb.Append("left join cte m3 on m3.HICN = y.MemberNumber AND y.ServiceDate BETWEEN m3.EffectiveDate AND m3.ExpirationDate ");
            sb.Append("left join cte m4 on m4.MBI = y.MemberNumber AND y.ServiceDate BETWEEN m4.EffectiveDate AND m4.ExpirationDate ");
            sb.Append("left join cte m5 on m5.SocialSecurityNumber = y.MemberNumber AND y.ServiceDate BETWEEN m5.EffectiveDate AND m5.ExpirationDate");
            using (var context = new MeditracContext())
            {
                context.Database.CommandTimeout = 3600;
                result = await context.Database.SqlQuery<MemberDetail>(sb.ToString() + $" @MemberNumber={MemberNumber}, @ServiceDate={ServiceDate}").ToListAsync();
            }
            return result;
        }
    }
}
