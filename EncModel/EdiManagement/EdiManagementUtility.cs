using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.EdiManagement
{
    public class EdiManagementUtility
    {
        public static List<string> GetDMEProcedureCodes()
        {
            List<string> result = null;
            using (var context = new EdiManagementContext())
            {
                context.Database.CommandTimeout = 1800;
                result = context.Database.SqlQuery<string>("select ProcedureCode from EDPS_DME_Codes").ToList();
            }
            return result;
        }
    }
}
