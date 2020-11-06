namespace PruebaMock.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PruebaMock.Entities;

    public partial class EmpresaContext : DbContext
    {
        public EmpresaContext()
            : base("name=EmpresaContext")
        {
        }

        public virtual DbSet<DEPARTMENTS> DEPARTMENTS { get; set; }
        public virtual DbSet<EMPLOYEES> EMPLOYEES { get; set; }
        public virtual DbSet<JOBS> JOBS { get; set; }
        public virtual DbSet<LOCATIONS> LOCATIONS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPARTMENTS>()
                .Property(e => e.DEPARTMENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENTS>()
                .Property(e => e.DEPARTMENT_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENTS>()
                .HasMany(e => e.EMPLOYEES)
                .WithOptional(e => e.DEPARTMENTS)
                .HasForeignKey(e => e.DEPARTMENT_ID);

            modelBuilder.Entity<EMPLOYEES>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEES>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEES>()
                .Property(e => e.SALARY)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EMPLOYEES>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEES>()
                .HasMany(e => e.EMPLOYEES1)
                .WithOptional(e => e.EMPLOYEES2)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<JOBS>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<JOBS>()
                .Property(e => e.JOB_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<JOBS>()
                .HasMany(e => e.EMPLOYEES)
                .WithOptional(e => e.JOBS)
                .HasForeignKey(e => e.JOB_ID);

            modelBuilder.Entity<LOCATIONS>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATIONS>()
                .HasMany(e => e.DEPARTMENTS)
                .WithRequired(e => e.LOCATIONS)
                .HasForeignKey(e => e.LOCATION_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
