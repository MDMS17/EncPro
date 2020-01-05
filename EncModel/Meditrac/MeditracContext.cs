using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.Meditrac
{
    public class MeditracContext : DbContext
    {
        public MeditracContext() : base("name=MeditracConnectionString") { }
    }
}
