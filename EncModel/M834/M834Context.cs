using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EncModel.M834
{
    public class M834Context : DbContext
    {
        public M834Context() : base("name=CN834") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M834AdditionalName>().ToTable("M834AdditionalName");
            modelBuilder.Entity<M834Detail>().ToTable("M834Detail");
            modelBuilder.Entity<M834DisabilityInfo>().ToTable("M834DisabilityInfo");
            modelBuilder.Entity<M834EmploymentClass>().ToTable("M834EmploymentClass");
            modelBuilder.Entity<M834File>().ToTable("M834File");
            modelBuilder.Entity<M834HCCOBInfo>().ToTable("M834HCCOBInfo");
            modelBuilder.Entity<M834HCProviderInfo>().ToTable("M834HCProviderInfo");
            modelBuilder.Entity<M834HealthCoverage>().ToTable("M834HealthCoverage");
            modelBuilder.Entity<M834Language>().ToTable("M834Language");
            modelBuilder.Entity<M834MemberLevelDate>().ToTable("M834MemberLevelDate");
            modelBuilder.Entity<M834PolicyAmount>().ToTable("M834PolicyAmount");
            modelBuilder.Entity<M834ReportingCategory>().ToTable("M834ReportingCategory");
            modelBuilder.Entity<M834SubId>().ToTable("M834SubId");
        }
        public virtual DbSet<M834AdditionalName> M834AdditionalNames { get; set; }
        public virtual DbSet<M834Detail> M834Details { get; set; }
        public virtual DbSet<M834DisabilityInfo> M834DisabilityInfos { get; set; }
        public virtual DbSet<M834EmploymentClass> M834EmploymentClasses { get; set; }
        public virtual DbSet<M834File> M834Files { get; set; }
        public virtual DbSet<M834HCCOBInfo> M834HCCOBInfos { get; set; }
        public virtual DbSet<M834HCProviderInfo> M834HCProviderInfos { get; set; }
        public virtual DbSet<M834HealthCoverage> M834HealthCoverages { get; set; }
        public virtual DbSet<M834Language> M834Languages { get; set; }
        public virtual DbSet<M834MemberLevelDate> M834MemberLevelDates { get; set; }
        public virtual DbSet<M834PolicyAmount> M834PolicyAnounts { get; set; }
        public virtual DbSet<M834ReportingCategory> M834ReportingCategories { get; set; }
        public virtual DbSet<M834SubId> M834SubIds { get; set; }
    }
}
