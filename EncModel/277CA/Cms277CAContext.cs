using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel._277CA
{
    public class Cms277CAContext : DbContext
    {
        public Cms277CAContext() : base("name=CMS277CAConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Response");
            modelBuilder.Entity<_277CABillProv>().ToTable("277CABillProv");
            modelBuilder.Entity<_277CAFile>().ToTable("277CAFile");
            modelBuilder.Entity<_277CALine>().ToTable("277CALine");
            modelBuilder.Entity<_277CAPatient>().ToTable("277CAPatient");
            modelBuilder.Entity<_277CAStc>().ToTable("277CAStc");
        }
        public virtual DbSet<_277CABillProv> Table277CABillProv { get; set; }
        public virtual DbSet<_277CAFile> Table277CAFile { get; set; }
        public virtual DbSet<_277CALine> Table277CALine { get; set; }
        public virtual DbSet<_277CAPatient> Table277CAPatient { get; set; }
        public virtual DbSet<_277CAStc> Table277CAStc { get; set; }
    }
}
