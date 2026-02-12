using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.Data
{
    public class SMPPIDbContext : DbContext
    {
        public SMPPIDbContext(DbContextOptions<SMPPIDbContext> options)
            : base(options)
        {
        }

        public DbSet<AcademicStaff> AcademicStaff { get; set; }
        public DbSet<ResearchProject> ResearchProjects { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<GrantFinancial> GrantFinancials { get; set; }
        public DbSet<IntellectualProperty> IntellectualProperties { get; set; }
        public DbSet<GraduateResearcher> GraduateResearchers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure AcademicStaff
            modelBuilder.Entity<AcademicStaff>(entity =>
            {
                entity.HasKey(e => e.StaffID);
                entity.HasIndex(e => e.UMSPER).IsUnique();
                entity.HasIndex(e => e.Faculty);
                entity.HasIndex(e => e.Position);
                entity.HasIndex(e => e.ResearchDomain);
            });

            // Configure ResearchProject
            modelBuilder.Entity<ResearchProject>(entity =>
            {
                entity.HasKey(e => e.ProjectID);
                entity.HasIndex(e => e.ProjectCode).IsUnique();
                entity.HasIndex(e => e.GrantScheme);
                entity.HasIndex(e => e.Phase);
                entity.HasIndex(e => e.ProjectStatus);

                entity.HasOne(p => p.PrincipalInvestigator)
                    .WithMany(s => s.ResearchProjects)
                    .HasForeignKey(p => p.PrincipalInvestigatorID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Publication
            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.PublicationID);
                entity.HasIndex(e => e.PublicationType);
                entity.HasIndex(e => e.PublicationYear);
                entity.HasIndex(e => e.IsIndexed);

                entity.HasOne(p => p.LinkedProject)
                    .WithMany(rp => rp.Publications)
                    .HasForeignKey(p => p.LinkedProjectID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure GrantFinancial
            modelBuilder.Entity<GrantFinancial>(entity =>
            {
                entity.HasKey(e => e.GrantID);
                entity.HasIndex(e => e.GrantCode).IsUnique();
                entity.HasIndex(e => e.GrantScheme);
                entity.HasIndex(e => e.Phase);
                entity.HasIndex(e => e.FiscalYear);
            });

            // Configure IntellectualProperty
            modelBuilder.Entity<IntellectualProperty>(entity =>
            {
                entity.HasKey(e => e.IPID);
                entity.HasIndex(e => e.ApplicationNumber).IsUnique();
                entity.HasIndex(e => e.IPType);
                entity.HasIndex(e => e.IPStatus);

                entity.HasOne(ip => ip.LinkedProject)
                    .WithMany(rp => rp.IntellectualProperties)
                    .HasForeignKey(ip => ip.LinkedProjectID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure GraduateResearcher
            modelBuilder.Entity<GraduateResearcher>(entity =>
            {
                entity.HasKey(e => e.ResearcherID);
                entity.HasIndex(e => e.StudentID).IsUnique();
                entity.HasIndex(e => e.ProgramLevel);
                entity.HasIndex(e => e.ResearcherStatus);

                entity.HasOne(gr => gr.Supervisor)
                    .WithMany(s => s.GraduateResearchers)
                    .HasForeignKey(gr => gr.SupervisorID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(gr => gr.LinkedProject)
                    .WithMany(rp => rp.GraduateResearchers)
                    .HasForeignKey(gr => gr.LinkedProjectID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure AuditLog
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.AuditID);
                entity.HasIndex(e => e.UserName);
                entity.HasIndex(e => e.ActionType);
                entity.HasIndex(e => e.DatePerformed);
            });
        }
    }
}
