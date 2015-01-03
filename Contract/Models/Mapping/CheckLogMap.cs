using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class CheckLogMap : EntityTypeConfiguration<CheckLog>
    {
        public CheckLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CheckLog", "Log");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TenancyID).HasColumnName("TenancyID");
            this.Property(t => t.TaskID).HasColumnName("TaskID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
        }
    }
}
