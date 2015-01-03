using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class FunctionMap : EntityTypeConfiguration<Function>
    {
        public FunctionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(40);

            this.Property(t => t.Icon)
                .HasMaxLength(20);

            this.Property(t => t.Controller)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Function", "Configuration");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.IsRoot).HasColumnName("IsRoot");
            this.Property(t => t.IsTag).HasColumnName("IsTag");
            this.Property(t => t.IsSystem).HasColumnName("IsSystem");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
        }
    }
}
