using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.DHCS
{
    public class DHCSContext : DbContext
    {
        public DHCSContext() : base("name=DHCSConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Response");
            modelBuilder.Entity<DHCSFile>().ToTable("DHCSFile");
            modelBuilder.Entity<DHCSTransaction>().ToTable("DHCSTransaction");
            modelBuilder.Entity<DHCSEncounter>().ToTable("DHCSEncounter");
            modelBuilder.Entity<DHCSEncounterResponse>().ToTable("DHCSEncounterResponse");
            modelBuilder.Entity<DHCSServiceLine>().ToTable("DHCSServiceLine");
        }

        public virtual DbSet<DHCSFile> TableDHCSFile { get; set; }
        public virtual DbSet<DHCSTransaction> TableDHCSTransaction { get; set; }
        public virtual DbSet<DHCSEncounter> TableDHCSEncounter { get; set; }
        public virtual DbSet<DHCSEncounterResponse> TableDHCSEncounterResponse { get; set; }
        public virtual DbSet<DHCSServiceLine> TableDHCSServiceLine { get; set; }
    }
}
