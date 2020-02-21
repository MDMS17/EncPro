using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncModel.MAO001
{
    public class Mao001Utility
    {
        public static void SaveBatch(ref List<Mao001Detail> details)
        {
            using (var context = new Mao001Context())
            {
                context.Mao001Details.AddRange(details);
                context.SaveChanges();
            }
            details.Clear();
        }
        public static List<string> GetProcessedFiles()
        {
            List<string> result = null;
            using (var context = new Mao001Context())
            {
                result = context.Mao001Headers.Select(x => x.FileName).ToList();
            }
            return result;
        }
    }
}
