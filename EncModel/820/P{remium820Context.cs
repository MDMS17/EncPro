using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.Premium820
{
    public class Premium820Context : DbContext
    {
        public Premium820Context() : base("name=Premium820ConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<File820>().ToTable("File820");
            modelBuilder.Entity<Member820>().ToTable("Member820");
        }

        public virtual DbSet<File820> Premium820File { get; set; }
        public virtual DbSet<Member820> Premium820Member { get; set; }

    }
}
