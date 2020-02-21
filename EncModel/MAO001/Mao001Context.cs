using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.MAO001
{
    public class Mao001Context : DbContext
    {
        public Mao001Context() : base("name=Mao001ConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Mao001Header>().ToTable("Mao001Header");
            modelBuilder.Entity<Mao001Detail>().ToTable("Mao001Detail");
        }

        public virtual DbSet<Mao001Header> Mao001Headers { get; set; }
        public virtual DbSet<Mao001Detail> Mao001Details { get; set; }
    }
}
