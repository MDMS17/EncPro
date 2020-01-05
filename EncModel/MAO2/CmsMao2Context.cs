using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.MAO2
{
    public class CmsMao2Context : DbContext
    {
        public CmsMao2Context() : base("name=CMSMAO2ConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Response");
            modelBuilder.Entity<MAO2File>().ToTable("MAO2File");
            modelBuilder.Entity<MAO2Detail>().ToTable("MAO2Detail");
        }

        public virtual DbSet<MAO2File> TableMao2File { get; set; }
        public virtual DbSet<MAO2Detail> TableMao2Detail { get; set; }
    }
}
