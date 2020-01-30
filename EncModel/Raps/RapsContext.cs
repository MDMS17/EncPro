using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.Raps
{
    public class RapsContext : DbContext
    {
        public RapsContext() : base("name=RapsConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<RapsFile>().ToTable("RapsFile");
            modelBuilder.Entity<RapsBatch>().ToTable("RapsBatch");
            modelBuilder.Entity<RapsDetail>().ToTable("RapsDetail");
        }

        public virtual DbSet<RapsFile> RapsFiles { get; set; }
        public virtual DbSet<RapsBatch> RapsBatches { get; set; }
        public virtual DbSet<RapsDetail> RapsDetails { get; set; }
    }
}

