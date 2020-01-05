using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.EdiManagement
{
    public class EdiManagementContext : DbContext
    {
        public EdiManagementContext() : base("name=EdiManagementConnectionString") { }
    }
}
