using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class ProcessMap : EntityTypeConfiguration<Process>
    {
        public ProcessMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Process", "WorkFlow");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
