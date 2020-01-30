using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.Raps
{
    public class RapsUtility
    {
        public static void SaveRapsBatch(ref List<RapsDetail> details)
        {
            using (var context = new RapsContext())
            {
                context.RapsDetails.AddRange(details);
                context.SaveChanges();
            }
            details = new List<RapsDetail>();
        }
    }
}
