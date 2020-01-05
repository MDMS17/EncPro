using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel._999
{
    public class Cms999Context : DbContext
    {
        public Cms999Context() : base("name=CMS999ConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Response");
            modelBuilder.Entity<_999File>().ToTable("999File");
            modelBuilder.Entity<_999Transaction>().ToTable("999Transaction");
            modelBuilder.Entity<_999Error>().ToTable("999Error");
            modelBuilder.Entity<_999Element>().ToTable("999Element");
        }

        public virtual DbSet<_999File> Table999File { get; set; }
        public virtual DbSet<_999Transaction> Table999Transaction { get; set; }
        public virtual DbSet<_999Error> Table999Error { get; set; }
        public virtual DbSet<_999Element> Table999Element { get; set; }
    }
}
