using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.NoteType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ProcessLogic)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Task", "WorkFlow");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProcessID).HasColumnName("ProcessID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NoteType).HasColumnName("NoteType");
            this.Property(t => t.ProcessLogic).HasColumnName("ProcessLogic");
            this.Property(t => t.AssignedRole).HasColumnName("AssignedRole");
            this.Property(t => t.DueDate).HasColumnName("DueDate");

            // Relationships
            this.HasRequired(t => t.Role)
                .WithMany(t => t.Tasks)
                .HasForeignKey(d => d.AssignedRole);
            this.HasRequired(t => t.Process)
                .WithMany(t => t.Tasks)
                .HasForeignKey(d => d.ProcessID);

        }
    }
}
