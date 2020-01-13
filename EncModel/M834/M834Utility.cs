using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.M834
{
    public class M834Utility
    {
        public static void Save834Batch(ref Elig834 elig834)
        {
            using (var context = new M834Context())
            {
                context.M834AdditionalNames.AddRange(elig834.m834additionalnames);
                context.M834Details.AddRange(elig834.m834details);
                context.M834DisabilityInfos.AddRange(elig834.m834disabilityinfos);
                context.M834EmploymentClasses.AddRange(elig834.m834employmentclasses);
                context.M834HCCOBInfos.AddRange(elig834.m834hccobinfos);
                context.M834HCProviderInfos.AddRange(elig834.m834hcproviderinfos);
                context.M834HealthCoverages.AddRange(elig834.m834healthcoverages);
                context.M834Languages.AddRange(elig834.m834languages);
                context.M834MemberLevelDates.AddRange(elig834.m834memberleveldates);
                context.M834PolicyAnounts.AddRange(elig834.m834policyamounts);
                context.M834ReportingCategories.AddRange(elig834.m834reportingcategories);
                context.M834SubIds.AddRange(elig834.m834subids);
                context.SaveChanges();
            }
            elig834.m834additionalnames = new List<M834AdditionalName>();
            elig834.m834details = new List<M834Detail>();
            elig834.m834disabilityinfos = new List<M834DisabilityInfo>();
            elig834.m834employmentclasses = new List<M834EmploymentClass>();
            elig834.m834hccobinfos = new List<M834HCCOBInfo>();
            elig834.m834hcproviderinfos = new List<M834HCProviderInfo>();
            elig834.m834healthcoverages = new List<M834HealthCoverage>();
            elig834.m834languages = new List<M834Language>();
            elig834.m834memberleveldates = new List<M834MemberLevelDate>();
            elig834.m834policyamounts = new List<M834PolicyAmount>();
            elig834.m834reportingcategories = new List<M834ReportingCategory>();
            elig834.m834subids = new List<M834SubId>();
        }
    }
}
