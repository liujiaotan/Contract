using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class TenancyCheckLogMap : EntityTypeConfiguration<TenancyCheckLog>
    {
        public TenancyCheckLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Action)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TenancyCheckLog", "Log");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TenancyID).HasColumnName("TenancyID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.TaskID).HasColumnName("TaskID");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasRequired(t => t.Tenancy)
                .WithMany(t => t.TenancyCheckLogs)
                .HasForeignKey(d => d.TenancyID);
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.TenancyCheckLogs)
                .HasForeignKey(d => d.EmployeeID);
            this.HasRequired(t => t.Task)
                .WithMany(t => t.TenancyCheckLogs)
                .HasForeignKey(d => d.TaskID);

        }
    }
}
