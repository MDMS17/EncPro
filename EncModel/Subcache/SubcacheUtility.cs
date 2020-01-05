using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncModel.SubHistory;

namespace EncModel.Subcache
{
    public class SubcacheUtility
    {
        public static async Task TruncateStagingTables()
        {
            using (var context = new SubcacheContext())
            {
                context.Database.CommandTimeout = 1800;
                await context.Database.ExecuteSqlCommandAsync("truncate table subcache.claimcas;truncate table subcache.claimheaders;truncate table subcache.claimhis;truncate table subcache.claimlinesvds;truncate table subcache.claimntes;truncate table subcache.claimproviders;truncate table subcache.claimsbrs;truncate table subcache.claimsecondaryidentifications;truncate table subcache.servicelines;");
            }
        }
        public static void SaveClaims(ref List<Claim> claims)
        {
            using (var context = new SubcacheContext())
            {
                context.ClaimHeaders.AddRange(claims.Select(x => x.Header).ToList());
                context.ClaimCAS.AddRange(claims.SelectMany(x => x.Cases).ToList());
                context.ClaimCRCs.AddRange(claims.SelectMany(x => x.CRCs).ToList());
                context.ClaimHIs.AddRange(claims.SelectMany(x => x.His).ToList());
                context.ClaimK3s.AddRange(claims.SelectMany(x => x.K3s).ToList());
                context.ClaimLineFRMs.AddRange(claims.SelectMany(x => x.FRMs).ToList());
                context.ClaimLineLQs.AddRange(claims.SelectMany(x => x.LQs).ToList());
                context.ClaimLineMEAs.AddRange(claims.SelectMany(x => x.Meas).ToList());
                context.ClaimLineSVDs.AddRange(claims.SelectMany(x => x.SVDs).ToList());
                context.ClaimNtes.AddRange(claims.SelectMany(x => x.Notes).ToList());
                context.ClaimPatients.AddRange(claims.SelectMany(x => x.Patients).ToList());
                context.ClaimProviders.AddRange(claims.SelectMany(x => x.Providers).ToList());
                context.ClaimPWKs.AddRange(claims.SelectMany(x => x.PWKs).ToList());
                context.ClaimSBRs.AddRange(claims.SelectMany(x => x.Subscribers).ToList());
                context.ClaimSecondaryIdentifications.AddRange(claims.SelectMany(x => x.SecondaryIdentifications).ToList());
                context.ProviderContacts.AddRange(claims.SelectMany(x => x.ProviderContacts).ToList());
                context.ServiceLines.AddRange(claims.SelectMany(x => x.Lines).ToList());
                context.ToothStatus.AddRange(claims.SelectMany(x => x.ToothStatuses).ToList());
                context.SaveChanges();
            }
        }

    }
}
