using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel._835
{
    public class Context835 : DbContext
    {
        public Context835() : base("name=CN835") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim835>().ToTable("Claim835");
            modelBuilder.Entity<File835>().ToTable("File835");
        }
        public virtual DbSet<Claim835> Claim835s { get; set; }
        public virtual DbSet<File835> File835s { get; set; }
    }
}
